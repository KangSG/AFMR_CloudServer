using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Data
{
    public class StationData
    {
        public double Pressure { get; set; }
        public double Voltage { get; set; }
        public double Current { get; set; }
        public double Roll { get; set; }
        public double Pitch { get; set; }
        public double Yaw { get; set; }
        public double Temperature { get; set; }
        public int L1Rpm { get; set; }
        public int L2Rpm { get; set; }
        public int L3Rpm { get; set; }
        public int R1Rpm { get; set; }
        public int R2Rpm { get; set; }
        public int R3Rpm { get; set; }
        public double CoordiX { get; set; }
        public double CoordiY { get; set; }
        public double CoordiZ { get; set; }
        public double Obstacle { get; set; }
        public int Rid { get; set; }
        public StationData()
        {

        }
    }
}
