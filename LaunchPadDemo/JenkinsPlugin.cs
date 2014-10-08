using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class JenkinsPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;
        private static string baseUrl = "http://jenkins.msm.cakesolutions.net/";

        public string Job { get; set; }
        public string Build { get; set; }

        public override void Action()
        {
            System.Diagnostics.Process.Start("chrome.exe", String.Format("{0}/{1}/{2}", baseUrl, Job, Build));
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

