using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class TwitterPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;
        private static string baseUrl = "https://twitter.com";

        public string TwitterAccount { get; set; }
        public int FailDelay { get; set; }
        public bool Resolved { get; set; }

        public override void Action()
        {
            System.Diagnostics.Process.Start("chrome.exe", String.Format("{0}/{1}", baseUrl, this.TwitterAccount));
            Resolved = true;
        }

        public override void Poll()
        {
            if (Resolved)
            {
                this.status = LaunchPadStatus.OK;
            }
            else if (FailDelay > 0 && dt.AddSeconds(FailDelay) < DateTime.Now)
            {
                this.status = LaunchPadStatus.ALERT;
            }
        }
    }
}
