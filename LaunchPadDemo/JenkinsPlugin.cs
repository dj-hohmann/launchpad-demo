using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class JenkinsPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;
        private static string baseUrl = "http://jenkins.msm.cakesolutions.net";

        public string Job { get; set; }
        public string Build { get; set; }
        public int FailDelay { get; set; }


        public override void Action()
        {
            System.Diagnostics.Process.Start("chrome.exe", String.Format("{0}/job/{1}/{2}", baseUrl, Job, Build));
        }

        public override void Poll()
        {
            if (FailDelay > 0 && dt.AddSeconds(FailDelay) < DateTime.Now)
            {
                this.status = LaunchPadStatus.ALERT;
            }
        }
    }
}

