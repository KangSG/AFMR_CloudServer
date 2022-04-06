using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Data
{
    public class MobileData
    {
        public Mode ControlMode { get; set; }
        public Level ThrusterLevel { get; set; }
        public OnOff AutoHeading { get; set; }
        public OnOff AutoDepth { get; set; }
        public ThrusterHorizontal ThrusterHorizontal { get; set; }
        public ThrusterVertical ThrusterVertical { get; set; }
        public ThrusterRotation ThrusterRotation { get; set; }
        public Level ToolLevel { get; set; }
        public ToolControl ToolControl { get; set; }
        public Level Light1Level { get; set; }
        public Level Light2Level { get; set; }
        public int Rid { get; set; }

        public MobileData()
        {

        }
    }
    public enum OnOff { OFF = 0, ON, NONE };
    public enum Mode { MANUAL = 0, AUTO, NONE };
    public enum ToolControl { OFF = 0, CLOSE, OPEN, NONE };
    public enum Level { OFF = 0, LOW, MID, HIGH, NONE };
    public enum ThrusterHorizontal { OFF = 0, GO, RIGHT_GO, RIGHT, RIGHT_BACK, BACK, LEFT_BACK, LEFT, LEFT_GO, NONE };
    public enum ThrusterVertical { OFF = 0, DOWN, UP, NONE };
    public enum ThrusterRotation { OFF = 0, LEFT, RIGHT, NONE };
}
