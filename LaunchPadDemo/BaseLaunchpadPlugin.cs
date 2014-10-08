using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public abstract class BaseLaunchpadPlugin: ILaunchpadPlugin
    {
        private String name;
        private String status;
        private int count;

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

        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

        public void Monitor()
        {
            throw new NotImplementedException();
        }

        public void Action()
        {
            throw new NotImplementedException();
        }


        LaunchPadStatus ILaunchpadPlugin.Status
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
