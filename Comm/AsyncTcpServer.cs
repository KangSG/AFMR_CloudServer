using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace AFMR_CloudServer.Comm
{
    public class StateObject
    {
        public const int RecvBufferSize = 1024;
        public byte[] recvBuffer = new byte[RecvBufferSize];
        public Socket clientSocket = null;
        public int RovId = 0;
        public bool Pairing = false;
    }

    public class AsyncTcpServer
    {
        private const int READ_TIMEOUT = 5000;
        public Action<object> TimeoutAction { get; set; }
        public Action<object> OverlapAction { get; set; }
        public Action<object> ReceiveAction { get; set; }
        private ManualResetEvent[] ReceiveDone = new ManualResetEvent[4];
        private Socket listener;
        private List<StateObject> listClient;
        private int port;

        public AsyncTcpServer(int port)
        {
            listClient = new List<StateObject>();
            this.port = port;

            ReceiveDone[0] = new ManualResetEvent(false);
            ReceiveDone[1] = new ManualResetEvent(false);
            ReceiveDone[2] = new ManualResetEvent(false);
            ReceiveDone[3] = new ManualResetEvent(false);
        }
        public void StartListening()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[1];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, this.port);

            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void AcceptCallback(IAsyncResult ar)
        {
            try
            {
                listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                Socket clientSocket = listener.EndAccept(ar);

                StateObject clientState = new StateObject();
                clientState.clientSocket = clientSocket;
                listClient.Add(clientState);

                clientSocket.BeginReceive(clientState.recvBuffer, 0, StateObject.RecvBufferSize, 0, new AsyncCallback(ReadCallback), clientState);
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            StateObject clientState = (StateObject)ar.AsyncState;
            Socket clientSocket = clientState.clientSocket;

            try
            {
                int bytesRead = clientSocket.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content = Encoding.ASCII.GetString(clientState.recvBuffer, 0, bytesRead).ToString();

                    if (IsValidPacket(content))
                    {
                        clientState.RovId = int.Parse(content.Substring(content.IndexOf('*') - 1, 1));

                        if ((!clientState.Pairing && IsOverlapedRovId(clientState)) || clientState.RovId == 0)
                        {
                            RemoveClientList(clientState.clientSocket);
                            DisposeClient(clientState.clientSocket);
                            OverlapAction?.Invoke(clientState.RovId);
                        }
                        else
                        {
                            ReceiveAction?.Invoke(content);
                            ReceiveDone[clientState.RovId].Set();

                            ReceiveDone[clientState.RovId].Reset();
                            clientSocket.BeginReceive(clientState.recvBuffer, 0, StateObject.RecvBufferSize, 0, new AsyncCallback(ReadCallback), clientState);

                            if (ReceiveDone[clientState.RovId].WaitOne(READ_TIMEOUT) == false)
                            {
                                RemoveClientList(clientState.clientSocket);
                                DisposeClient(clientState.clientSocket);
                                TimeoutAction?.Invoke(clientState.RovId);
                            }
                        }
                    }
                    else
                    {
                        clientSocket.BeginReceive(clientState.recvBuffer, 0, StateObject.RecvBufferSize, 0, new AsyncCallback(ReadCallback), clientState);
                    }
                }
            }
            catch (SocketException ex)
            {
                RemoveClientList(clientSocket);
                DisposeClient(clientSocket);
                Console.WriteLine(ex.Message.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void Send(int rovId, String data)
        {
            try
            {
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                int iClient = FindClientIndex(rovId);

                if (iClient != -1)
                {
                    listClient[iClient].Pairing = true;
                    listClient[iClient].clientSocket.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), listClient[iClient].clientSocket);
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;

            try
            {
                int bytesSent = clientSocket.EndSend(ar);
            }
            catch (SocketException ex)
            {
                RemoveClientList(clientSocket);
                DisposeClient(clientSocket);
                Console.WriteLine(ex.Message.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        private bool IsValidPacket(String content)
        {
            const int INDEX_ERROR = -1;
            int iStx = INDEX_ERROR;
            int iHeader = INDEX_ERROR;
            int iCrc = INDEX_ERROR;
            int iEtx = INDEX_ERROR;

            var arrPacket = content.ToCharArray();

            for (int iPacket = 0; iPacket < arrPacket.Length; iPacket++)
            {
                if (arrPacket[iPacket] == '$')
                {
                    iStx = iPacket;
                    break;
                }
            }
            for (int iPacket = iStx + 1; iPacket < arrPacket.Length; iPacket++)
            {
                if (arrPacket[iPacket] == ',')
                {
                    iHeader = iPacket;
                    break;
                }
            }
            for (int iPacket = iHeader + 1; iPacket < arrPacket.Length; iPacket++)
            {
                if (arrPacket[iPacket] == '*')
                {
                    iCrc = iPacket;
                    break;
                }
            }
            for (int iPacket = iCrc + 1; iPacket < arrPacket.Length - 1; iPacket++)
            {
                if (arrPacket[iPacket] == '\r' && arrPacket[iPacket + 1] == '\n')
                {
                    iEtx = iPacket;
                    break;
                }
            }

            if (iStx == INDEX_ERROR || iHeader == INDEX_ERROR || iCrc == INDEX_ERROR || iEtx == INDEX_ERROR)
            {
                return false;
            }

            byte lowCrc = (byte)arrPacket[iCrc + 2];
            byte highCrc = (byte)arrPacket[iCrc + 1];
            byte receiveCs = 0x00;
            byte calcCs = 0x00;            

            receiveCs = (byte)(Util.ASCII.ConvertToHex(highCrc) << 4);
            receiveCs |= Util.ASCII.ConvertToHex(lowCrc);

            for (int iCs = 1; iCs < arrPacket.Length - 5; iCs++)
            {
                calcCs ^= (byte)arrPacket[iCs];
            }

            return receiveCs == calcCs;
        }
        private bool IsOverlapedRovId(StateObject clientState)
        {
            foreach (var client in listClient)
            {
                if (((IPEndPoint)client.clientSocket.RemoteEndPoint).Port != ((IPEndPoint)clientState.clientSocket.RemoteEndPoint).Port)
                {
                    if (client.RovId == clientState.RovId)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private int FindClientIndex(int rovId)
        {
            for (int iListClient = 0; iListClient < listClient.Count; iListClient++)
            {
                if (listClient[iListClient].RovId == rovId)
                {
                    return iListClient;
                }
            }
            return -1;
        }
        private void RemoveClientList(Socket clientSocket)
        {
            for (int iListClient = 0; iListClient < listClient.Count; iListClient++)
            {
                if (((IPEndPoint)listClient[iListClient].clientSocket.RemoteEndPoint).Port == ((IPEndPoint)clientSocket.RemoteEndPoint).Port)
                {
                    listClient.RemoveAt(iListClient);
                }
            }
        }
        private void DisposeClient(Socket clientSocket)
        {
            try
            {
                clientSocket?.Shutdown(SocketShutdown.Both);
                clientSocket?.Close();
                clientSocket?.Dispose();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            catch (ObjectDisposedException ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
        public void FinishListening()
        {
            foreach (var client in listClient)
            {
                DisposeClient(client.clientSocket);
            }
            listener.Close();
            listener.Dispose();
        }
    }
}