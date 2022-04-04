using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Comm
{
    public delegate void UpdateReceiveHandler(String receivePacket);

    public abstract class Modem
    {
        private AsyncTcpServer asyncTcpServer;
        protected ModemType modemType;
        public event EventHandler<CommEventArgs> CommReceiveEventHandler = null;
        public event EventHandler<CommEventArgs> CommTimeoutEventHandler = null;
        public event EventHandler<CommEventArgs> CommOverlapEventHandler = null;

        public Modem(int port)
        {
            asyncTcpServer = new AsyncTcpServer(port);
            asyncTcpServer.TimeoutAction += this.ReceiveTimeoutEvent;
            asyncTcpServer.OverlapAction += this.OverlapedEvent;
            asyncTcpServer.ReceiveAction += this.ReceivePacketEvent;
        }
        public void ModemOn()
        {
            asyncTcpServer.StartListening();
        }
        public void ModemOff()
        {
            asyncTcpServer.FinishListening();
        }
        private void ReceiveTimeoutEvent(object rovId)
        {
            if (rovId is int)
            {
                CommTimeoutEventHandler?.Invoke(this, new CommEventArgs(modemType, rovId));
            }
        }
        private void OverlapedEvent(object rovId)
        {
            if (rovId is int)
            {
                CommOverlapEventHandler?.Invoke(this, new CommEventArgs(modemType, rovId));
            }
        }
        private void ReceivePacketEvent(object packet)
        {
            if (packet is String)
            {
                ParsingPacket(packet.ToString());
            }
        }
        public void SendPacket(int rovId, string packet)
        {
            asyncTcpServer.Send(rovId, packet);
        }
        protected abstract void ParsingPacket(String packet);
        protected void DoCommRecvNotify(ModemType modemType, object data, string packet)
        {
            CommReceiveEventHandler?.Invoke(this, new CommEventArgs(modemType, data, packet));
        }
    }
    public class CommEventArgs : EventArgs
    {
        public ModemType CommSource { get; private set; }

        public object Data { get; private set; }
        public String Packet { get; private set; }

        public CommEventArgs(ModemType commSource, object date)
        {
            CommSource = commSource;
            Data = date;
            Packet = String.Empty;
        }
        public CommEventArgs(ModemType commSource, object date, String packet)
        {
            CommSource = commSource;
            Data = date;
            Packet = packet;
        }
    }
    public enum ModemType
    {
        MobileModem = 0,
        StationModem,
    }
}