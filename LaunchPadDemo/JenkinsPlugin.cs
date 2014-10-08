using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class JenkinsPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;

        public override void Action()
        {
            System.Diagnostics.Process.Start("chrome.exe");
        }

        public override void Poll()
        {
            if (dt.AddSeconds(5) < DateTime.Now)
            {
                this.status = LaunchPadStatus.ALERT;
            }
        }
    }
}

