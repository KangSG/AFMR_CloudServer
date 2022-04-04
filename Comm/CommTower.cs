using AFMR_CloudServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Comm
{
    public class CommTower
    {
        private CommTower() { }
        private static readonly Lazy<CommTower> instance = new Lazy<CommTower>(() => new CommTower());
        public static CommTower Instance { get { return instance.Value; } }
        public MobileCommModem mobileCommModem { get; private set; } = new MobileCommModem();
        public StationCommModem stationCommModem { get; private set; } = new StationCommModem();

        public event EventHandler<CommEventArgs> CommTimeoutNotify = null;
        public event EventHandler<CommEventArgs> CommOverlapNotify = null;
        public event EventHandler<CommEventArgs> CommReceiveNotify = null;

        public void Init()
        {
            mobileCommModem.CommTimeoutEventHandler += CommModemTimeoutNotify;
            mobileCommModem.CommOverlapEventHandler += CommModemOverlapNotify;
            mobileCommModem.CommReceiveEventHandler += CommModemReceiveNotify;

            stationCommModem.CommTimeoutEventHandler += CommModemTimeoutNotify;
            stationCommModem.CommOverlapEventHandler += CommModemOverlapNotify;
            stationCommModem.CommReceiveEventHandler += CommModemReceiveNotify;

            mobileCommModem.ModemOn();
            stationCommModem.ModemOn();
        }
        public void Finish()
        {
            mobileCommModem.ModemOff();
            stationCommModem.ModemOff();
        }
        private void CommModemTimeoutNotify(object sender, CommEventArgs e)
        {
            CommTimeoutNotify?.Invoke(this, e);
        }
        private void CommModemOverlapNotify(object sender, CommEventArgs e)
        {
            CommOverlapNotify?.Invoke(this, e);
        }
        private void CommModemReceiveNotify(object sender, CommEventArgs e)
        {
            CommReceiveNotify?.Invoke(this, e);

            if (e.CommSource == ModemType.MobileModem)
            {
                stationCommModem.SendPacket(((MobileData)e.Data).Rid, e.Packet);
            }
            else if (e.CommSource == ModemType.StationModem)
            {
                mobileCommModem.SendPacket(((StationData)e.Data).Rid, e.Packet);
            }
            else { }
        }
    }
}
