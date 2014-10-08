using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public abstract class BaseLaunchpadPlugin: ILaunchpadPlugin
    {
        protected String name;
        protected LaunchPadStatus status = LaunchPadStatus.OK;
        protected int count = 1;
        protected bool monitor;

        public void SetPollCounter(int seconds)
        {
            this.count = seconds;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public abstract void Action();

        public abstract void Poll();

        LaunchPadStatus ILaunchpadPlugin.Status
        {
            get
            {
                return this.status;
            }
        }

        public bool Monitor
        {
            get
            {
                return this.monitor;
            }
            set
            {
                this.monitor = value;
            }
        }
    }
}
