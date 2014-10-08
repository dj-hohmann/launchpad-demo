using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class TestPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;

        public override void Action()
        {
            System.Diagnostics.Process.Start("chrome.exe", "http://jenkins.msm.cakesolutions.net/job/aggregation-integration-builder/lastFailedBuild/");
            this.status = LaunchPadStatus.OK; // Reset the status
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
