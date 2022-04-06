using System;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AFMR_CloudServer.Comm;
using AFMR_CloudServer.Data;
using AFMR_CloudServer.Properties;

namespace AFMR_CloudServer
{
    public partial class MonitoringForm : Form
    {
        private Stopwatch[] mobileStopwatch = new Stopwatch[4];
        private Stopwatch[] stationStopwatch = new Stopwatch[4];
        private bool isReceivedMobile = false;
        private bool isReceivedStation = false;
        private Point mouseDownPoint = new Point(0, 0);

        public MonitoringForm()
        {
            InitializeComponent();
            Initialize();
            InitialzeForm();
        }

        private void MonitoringForm_Load(object sender, EventArgs e)
        {
            CommTower.Instance.Init();
            CommTower.Instance.CommTimeoutNotify += CommModemTimeoutNotify;
            CommTower.Instance.CommOverlapNotify += CommModemOverlapNotify;
            CommTower.Instance.CommReceiveNotify += CommModemReceiveNotify;
        }

        private void MonitoringForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CommTower.Instance.Finish();

            foreach (var stopwatch in mobileStopwatch)
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
            }

            foreach (var stopwatch in stationStopwatch)
            {
                if (stopwatch.IsRunning)
                    stopwatch.Stop();
            }            
        }
        private void Initialize()
        {
            for (int iStopwatch = 0; iStopwatch < 4; iStopwatch++)
            {
                mobileStopwatch[iStopwatch] = new Stopwatch();
                stationStopwatch[iStopwatch] = new Stopwatch();
            }
        }
        private void InitialzeForm()
        {
            cbMsRovId.SelectedIndex = 0;
            cbSsRovId.SelectedIndex = 0;

            lbMsIp.Text = CommSetting.Default.Mobile_Ip;
            lbMsPort.Text = String.Format("{0}", CommSetting.Default.Mobile_Port);

            lbSsIp.Text = CommSetting.Default.Station_Ip;
            lbSsPort.Text = String.Format("{0}", CommSetting.Default.Station_Port);
        }
        private void ReceiveAlertTimer_Tick(object sender, EventArgs e)
        {
            if (isReceivedMobile)
            {
                btnMobileAlert.BackColor = Color.Green;
                isReceivedMobile = false;
            }
            else
            {
                btnMobileAlert.BackColor = Color.Red;
            }

            if (isReceivedStation)
            {
                btnStationAlert.BackColor = Color.Green;
                isReceivedStation = false;
            }
            else
            {
                btnStationAlert.BackColor = Color.Red;
            }
        }
        public void CommModemTimeoutNotify(object sender, CommEventArgs e)
        {
            if (lbMsCommPeriod.InvokeRequired)
            {
                lbMsCommPeriod.Invoke(new MethodInvoker(delegate ()
                {
                    if (e.CommSource == ModemType.MobileModem)
                    {
                        int rovId = (int)e.Data;

                        if (rovId == int.Parse(cbMsRovId.Text))
                        {
                            lbMsCommPeriod.Text = "Time Out";
                        }
                    }
                    else if (e.CommSource == ModemType.StationModem)
                    {
                        int rovId = (int)e.Data;

                        if (rovId == int.Parse(cbSsRovId.Text))
                        {
                            lbSsCommPeriod.Text = "Time Out";
                        }
                    }
                }));
            }
        }
        public void CommModemOverlapNotify(object sender, CommEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    StringBuilder message = new StringBuilder();

                    if (e.CommSource == ModemType.MobileModem)
                    {
                        int rovId = (int)e.Data;

                        if (rovId == 0)
                        {
                            message.Append(String.Format("비정상적인 ROV ID({0})의 Mobile SW로부터 연결이 시도되어 연결을 차단합니다.", rovId));
                        }
                        else
                        {
                            message.Append(String.Format("이미 연결된 ROV ID({0})와 동일한 ROV ID({1})의 Mobile SW로부터 연결이 시도되어 연결을 차단합니다.", rovId, rovId));
                        }
                    }
                    else if (e.CommSource == ModemType.StationModem)
                    {
                        int rovId = (int)e.Data;

                        if (rovId == 0)
                        {
                            message.Append(String.Format("비정상적인 ROV ID({0})의 Station SW로부터 연결이 시도되어 연결을 차단합니다.", rovId));
                        }
                        else
                        {
                            message.Append(String.Format("이미 연결된 ROV ID({0})와 동일한 ROV ID({1})의 Station SW로부터 연결이 시도되어 연결을 차단합니다.", rovId, rovId));
                        }                        
                    }
                    else
                    {
                        message.Append("Error CommSource");
                    }

                    new AlertForm(this.Size, this.Location, message.ToString()).Show();
                }));
            }
        }
        public void CommModemReceiveNotify(object sender, CommEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    if (e.CommSource == ModemType.MobileModem)
                    {
                        var mobileData = (MobileData)e.Data;
                        long elapsedTime = 0;

                        if (!mobileStopwatch[mobileData.Rid].IsRunning)
                        {
                            mobileStopwatch[mobileData.Rid].Start();
                        }
                        else
                        {
                            elapsedTime = mobileStopwatch[mobileData.Rid].ElapsedMilliseconds;
                            mobileStopwatch[mobileData.Rid].Restart();
                        }

                        if (mobileData.Rid == int.Parse(cbMsRovId.Text))
                        {
                            updateMobileCommPeriod(elapsedTime);
                            UpdateMobileData(mobileData);
                            isReceivedMobile = true;
                        }
                    }
                    else if (e.CommSource == ModemType.StationModem)
                    {
                        var stationData = (StationData)e.Data;
                        long elapsedTime = 0;

                        if (!stationStopwatch[stationData.Rid].IsRunning)
                        {
                            stationStopwatch[stationData.Rid].Start();
                        }
                        else
                        {
                            elapsedTime = stationStopwatch[stationData.Rid].ElapsedMilliseconds;
                            stationStopwatch[stationData.Rid].Restart();
                        }

                        if (stationData.Rid == int.Parse(cbSsRovId.Text))
                        {
                            updateStationCommPeriod(elapsedTime);
                            UpdateStationData(stationData);
                            isReceivedStation = true;
                        }
                    }
                }));
            }
        }
        private void updateMobileCommPeriod(long elapsedMilliseconds)
        {
            double commPeriod;

            if (elapsedMilliseconds != 0)
            {
                commPeriod = 1000.0 / elapsedMilliseconds;
            }
            else
            {
                commPeriod = 0;
            }

            lbMsCommPeriod.Text = String.Format("{0}Hz", (int)Math.Round(commPeriod));
        }
        private void updateStationCommPeriod(long elapsedMilliseconds)
        {
            double commPeriod;
            if (elapsedMilliseconds != 0)
            {
                commPeriod = 1000.0 / elapsedMilliseconds;
            }
            else
            {
                commPeriod = 0;
            }

            lbSsCommPeriod.Text = String.Format("{0}Hz", (int)Math.Round(commPeriod));
        }
        private void UpdateMobileData(MobileData mobileData)
        {
            switch (mobileData.ControlMode)
            {
                case Mode.MANUAL:
                    lbMsAutoManual.Text = "수동";
                    break;
                case Mode.AUTO:
                    lbMsAutoManual.Text = "자동";
                    break;
                default:
                    lbMsAutoManual.Text = "X";
                    break;
            }

            switch (mobileData.ThrusterLevel)
            {
                case Level.OFF:
                    lbMsThrusterLevel.Text = "꺼짐";
                    break;
                case Level.LOW:
                    lbMsThrusterLevel.Text = "약";
                    break;
                case Level.MID:
                    lbMsThrusterLevel.Text = "중";
                    break;
                case Level.HIGH:
                    lbMsThrusterLevel.Text = "강";
                    break;
                default:
                    lbMsThrusterLevel.Text = "X";
                    break;
            }

            switch (mobileData.ThrusterHorizontal)
            {
                case ThrusterHorizontal.OFF:
                    switch (mobileData.ThrusterRotation)
                    {
                        case ThrusterRotation.OFF:
                            lbMsThrusterHorizontal.Text = "정지";
                            break;
                        case ThrusterRotation.LEFT:
                            lbMsThrusterHorizontal.Text = "좌회전";
                            break;
                        case ThrusterRotation.RIGHT:
                            lbMsThrusterHorizontal.Text = "우회전";
                            break;
                        default:
                            lbMsThrusterHorizontal.Text = "X";
                            break;
                    }
                    break;
                case ThrusterHorizontal.GO:
                    lbMsThrusterHorizontal.Text = "전진";
                    break;
                case ThrusterHorizontal.RIGHT_GO:
                    lbMsThrusterHorizontal.Text = "우전진";
                    break;
                case ThrusterHorizontal.RIGHT:
                    lbMsThrusterHorizontal.Text = "우이동";
                    break;
                case ThrusterHorizontal.RIGHT_BACK:
                    lbMsThrusterHorizontal.Text = "우후진";
                    break;
                case ThrusterHorizontal.BACK:
                    lbMsThrusterHorizontal.Text = "후진";
                    break;
                case ThrusterHorizontal.LEFT_BACK:
                    lbMsThrusterHorizontal.Text = "좌후진";
                    break;
                case ThrusterHorizontal.LEFT:
                    lbMsThrusterHorizontal.Text = "좌이동";
                    break;
                default:
                    lbMsThrusterHorizontal.Text = "X";
                    break;
            }

            switch (mobileData.ThrusterVertical)
            {
                case ThrusterVertical.OFF:
                    lbMsThrusterVertical.Text = "정지";
                    break;
                case ThrusterVertical.UP:
                    lbMsThrusterVertical.Text = "상승";
                    break;
                case ThrusterVertical.DOWN:
                    lbMsThrusterVertical.Text = "하강";
                    break;
                default:
                    lbMsThrusterVertical.Text = "X";
                    break;
            }            

            switch (mobileData.AutoHeading)
            {
                case OnOff.OFF:
                    lbMsAutoHeading.Text = "끔";
                    break;
                case OnOff.ON:
                    lbMsAutoHeading.Text = "켬";
                    break;
                default:
                    lbMsAutoHeading.Text = "X";
                    break;
            }

            switch (mobileData.AutoDepth)
            {
                case OnOff.OFF:
                    lbMsAutoDepth.Text = "끔";
                    break;
                case OnOff.ON:
                    lbMsAutoDepth.Text = "켬";
                    break;
                default:
                    lbMsAutoDepth.Text = "X";
                    break;
            }

            switch (mobileData.ToolLevel)
            {
                case Level.OFF:
                    lbMsToolLevel.Text = "꺼짐";
                    break;
                case Level.LOW:
                    lbMsToolLevel.Text = "약";
                    break;
                case Level.MID:
                    lbMsToolLevel.Text = "중";
                    break;
                case Level.HIGH:
                    lbMsToolLevel.Text = "강";
                    break;
                default:
                    lbMsToolLevel.Text = "X";
                    break;
            }

            switch (mobileData.ToolControl)
            {
                case ToolControl.OFF:
                    lbMsToolControl.Text = "꺼짐";
                    break;
                case ToolControl.CLOSE:
                    lbMsToolControl.Text = "닫기";
                    break;
                case ToolControl.OPEN:
                    lbMsToolControl.Text = "열기";
                    break;
                default:
                    lbMsToolControl.Text = "X";
                    break;
            }

            switch (mobileData.Light1Level)
            {
                case Level.OFF:
                    lbMsLight1.Text = "꺼짐";
                    break;
                case Level.LOW:
                    lbMsLight1.Text = "약";
                    break;
                case Level.MID:
                    lbMsLight1.Text = "중";
                    break;
                case Level.HIGH:
                    lbMsLight1.Text = "강";
                    break;
                default:
                    lbMsLight1.Text = "X";
                    break;
            }

            switch (mobileData.Light2Level)
            {
                case Level.OFF:
                    lbMsLight2.Text = "꺼짐";
                    break;
                case Level.LOW:
                    lbMsLight2.Text = "약";
                    break;
                case Level.MID:
                    lbMsLight2.Text = "중";
                    break;
                case Level.HIGH:
                    lbMsLight2.Text = "강";
                    break;
                default:
                    lbMsLight2.Text = "X";
                    break;
            }
        }
        private void UpdateStationData(StationData stationData)
        {
            lbSsPressure.Text = String.Format("{0:N2}Bar", stationData.Pressure);
            lbSsVoltage.Text = String.Format("{0:N2}V", stationData.Voltage);
            lbSsCurrent.Text = String.Format("{0:N2}A", stationData.Current);
            lbSsRoll.Text = String.Format("{0:N2}˚", stationData.Roll);
            lbSsPitch.Text = String.Format("{0:N2}˚", stationData.Pitch);
            lbSsYaw.Text = String.Format("{0:N2}˚", stationData.Yaw);
            lbSsTemperature.Text = String.Format("{0:N2}℃", stationData.Temperature);
            lbSsL1Rpm.Text = String.Format("{0}rpm", stationData.L1Rpm);
            lbSsL2Rpm.Text = String.Format("{0}rpm", stationData.L2Rpm);
            lbSsL3Rpm.Text = String.Format("{0}rpm", stationData.L3Rpm);
            lbSsR1Rpm.Text = String.Format("{0}rpm", stationData.R1Rpm);
            lbSsR2Rpm.Text = String.Format("{0}rpm", stationData.R2Rpm);
            lbSsR3Rpm.Text = String.Format("{0}rpm", stationData.R3Rpm);
            lbSsCoordiX.Text = String.Format("{0:N2}m/s²", stationData.CoordiX);
            lbSsCoordiY.Text = String.Format("{0:N2}m/s²", stationData.CoordiY);
            lbSsCoordiZ.Text = String.Format("{0:N2}m/s²", stationData.CoordiZ);
            lbSsObstacle.Text = String.Format("{0:N2}rad/s²", stationData.Obstacle);
        }

        private void nuiPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPoint.X = e.X;
            mouseDownPoint.Y = e.Y;
        }

        private void nuiPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(Left - (mouseDownPoint.X - e.X), Top - (mouseDownPoint.Y - e.Y));
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
