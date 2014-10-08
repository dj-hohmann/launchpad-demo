using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class TwitterPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;

        public override void Action()
        {
            System.Diagnostics.Process.Start("chrome.exe", "https://twitter.com/MoneySupermkt");
            this.status = LaunchPadStatus.OK; // Reset the status
        }

        public override void Poll()
        {
            if (dt.AddSeconds(12) < DateTime.Now)
            {
                this.status = LaunchPadStatus.ALERT;
            }
        }
    }
}
