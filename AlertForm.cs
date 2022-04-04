using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFMR_CloudServer
{
    public partial class AlertForm : Form
    {
        public AlertForm(Size parentSize, Point parentLocation, String alertMessage)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(parentLocation.X + (parentSize.Width - this.Width) - 16, parentLocation.Y + 16);
            lbAlertMessage.Text = alertMessage;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
