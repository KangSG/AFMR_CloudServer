using AFMR_CloudServer.Data;
using AFMR_CloudServer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Comm
{
    public class MobileCommModem : Modem
    {
        public MobileCommModem() : base(CommSetting.Default.Mobile_Port)
        {
            modemType = ModemType.MobileModem;
        }
        protected override void ParsingPacket(String protocol)
        {
            MobileData mobileData = new MobileData();

            var tokens = protocol.Split(new char[] { ',', '*' });
            int iToken = 1;

            if (tokens[iToken] == "0")
            {
                mobileData.ControlMode = Mode.MANUAL;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ControlMode = Mode.AUTO;
            }
            else
            {
                mobileData.ControlMode = Mode.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.ThrusterLevel = Level.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ThrusterLevel = Level.LOW;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.ThrusterLevel = Level.MID;
            }
            else if (tokens[iToken] == "3")
            {
                mobileData.ThrusterLevel = Level.HIGH;
            }
            else
            {
                mobileData.ThrusterLevel = Level.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.AutoHeading = OnOff.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.AutoHeading = OnOff.ON;
            }
            else
            {
                mobileData.AutoHeading = OnOff.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.AutoDepth = OnOff.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.AutoDepth = OnOff.ON;
            }
            else
            {
                mobileData.AutoDepth = OnOff.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.GO;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.RIGHT_GO;
            }
            else if (tokens[iToken] == "3")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.RIGHT;
            }
            else if (tokens[iToken] == "4")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.RIGHT_BACK;
            }
            else if (tokens[iToken] == "5")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.BACK;
            }
            else if (tokens[iToken] == "6")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.LEFT_BACK;
            }
            else if (tokens[iToken] == "7")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.LEFT;
            }
            else if (tokens[iToken] == "8")
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.LEFT_GO;
            }
            else
            {
                mobileData.ThrusterHorizontal = ThrusterHorizontal.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.ThrusterVertical = ThrusterVertical.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ThrusterVertical = ThrusterVertical.DOWN;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.ThrusterVertical = ThrusterVertical.UP;
            }
            else
            {
                mobileData.ThrusterVertical = ThrusterVertical.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.ThrusterTrim = ThrusterVertical.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ThrusterTrim = ThrusterVertical.DOWN;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.ThrusterTrim = ThrusterVertical.UP;
            }
            else
            {
                mobileData.ThrusterTrim = ThrusterVertical.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.ToolLevel = Level.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ToolLevel = Level.LOW;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.ToolLevel = Level.MID;
            }
            else if (tokens[iToken] == "3")
            {
                mobileData.ToolLevel = Level.HIGH;
            }
            else
            {
                mobileData.ToolLevel = Level.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.ToolControl = ToolControl.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.ToolControl = ToolControl.CLOSE;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.ToolControl = ToolControl.OPEN;
            }
            else
            {
                mobileData.ToolControl = ToolControl.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.Light1Level = Level.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.Light1Level = Level.LOW;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.Light1Level = Level.MID;
            }
            else if (tokens[iToken] == "3")
            {
                mobileData.Light1Level = Level.HIGH;
            }
            else
            {
                mobileData.Light1Level = Level.NONE;
            }
            iToken++;

            if (tokens[iToken] == "0")
            {
                mobileData.Light2Level = Level.OFF;
            }
            else if (tokens[iToken] == "1")
            {
                mobileData.Light2Level = Level.LOW;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.Light2Level = Level.MID;
            }
            else if (tokens[iToken] == "3")
            {
                mobileData.Light2Level = Level.HIGH;
            }
            else
            {
                mobileData.Light2Level = Level.NONE;
            }
            iToken++;

            if (tokens[iToken] == "1")
            {
                mobileData.Rid = 1;
            }
            else if (tokens[iToken] == "2")
            {
                mobileData.Rid = 2;
            }
            else if (tokens[iToken] == "3")
            {
                mobileData.Rid = 3;
            }
            else
            {
                mobileData.Rid = 0;
            }

            DoCommRecvNotify(ModemType.MobileModem, mobileData, protocol);
        }
    }
}
