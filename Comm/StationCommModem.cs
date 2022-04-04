using AFMR_CloudServer.Data;
using AFMR_CloudServer.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Comm
{
    public class StationCommModem : Modem
    {
        public StationCommModem() : base(CommSetting.Default.Station_Port)
        {
            modemType = ModemType.StationModem;
        }
        protected override void ParsingPacket(String protocol)
        {
            StationData stationData = new StationData();
            var tokens = protocol.Split(new char[] { ',', '*' });
            int iToken = 1;

            stationData.Pressure = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Voltage = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Current = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Roll = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Pitch = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Yaw = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Temperature = double.Parse(tokens[iToken]);
            iToken++;
            stationData.L1Rpm = int.Parse(tokens[iToken]);
            iToken++;
            stationData.L2Rpm = int.Parse(tokens[iToken]);
            iToken++;
            stationData.L3Rpm = int.Parse(tokens[iToken]);
            iToken++;
            stationData.R1Rpm = int.Parse(tokens[iToken]);
            iToken++;
            stationData.R2Rpm = int.Parse(tokens[iToken]);
            iToken++;
            stationData.R3Rpm = int.Parse(tokens[iToken]);
            iToken++;
            stationData.CoordiX = double.Parse(tokens[iToken]);
            iToken++;
            stationData.CoordiY = double.Parse(tokens[iToken]);
            iToken++;
            stationData.CoordiZ = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Obstacle = double.Parse(tokens[iToken]);
            iToken++;
            stationData.Rid = int.Parse(tokens[iToken]);

            DoCommRecvNotify(ModemType.StationModem, stationData, protocol);
        }
    }
}
