using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace AFMR_CloudServer
{
    public partial class SelectNetForm : Form
    {
        public SelectNetForm()
        {
            InitializeComponent();
            InitialzeForm();
        }
        private void InitialzeForm()
        {
            String hostName = String.Empty;
            var hostname = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostname);
            IPAddress[] addr = ipEntry.AddressList;

            lbTitle.Item.Text = String.Format(hostname + " 네트워크 목록");

            for (int i = 0; i < addr.Length; i++)
            {
                if (addr[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    lbNetList.Items.Add(addr[i].ToString());
                }                
            }
        }

        private void btnServerOn_Click(object sender, EventArgs e)
        {
            if (lbNetList.SelectedIndex != -1)
            {
                String selectedIpAddress = lbNetList.Items[lbNetList.SelectedIndex].ToString();

                Properties.CommSetting.Default.Mobile_Ip = selectedIpAddress;
                Properties.CommSetting.Default.Station_Ip = selectedIpAddress;

                new MonitoringForm().Show();
                this.Close();
            }
            else
            {
                new AlertForm(this.Size, this.Location, "선택된 네트워크가 없습니다. 다시 선택해 주십시오.").Show();
            }
        }

        private void lbFinishApp_MouseDown(object sender, MouseEventArgs e)
        {
            lbFinishApp.Text = "<font color=\'silver\'><b>X</b></font>";
        }

        private void lbFinishApp_MouseUp(object sender, MouseEventArgs e)
        {
            lbFinishApp.Text = "<font color=\'white\'><b>X</b></font>";
            Application.Exit();
        }
    }
}
