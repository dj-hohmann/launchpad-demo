using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class TestPlugin : ILaunchpadPlugin
    {

        public string Name
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

        public void Monitor()
        {
            throw new NotImplementedException();
        }


        public int Count
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

        public void Action()
        {
            throw new NotImplementedException();
        }
    }
}
