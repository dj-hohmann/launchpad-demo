using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public class BlankPlugin : BaseLaunchpadPlugin
    {
        private DateTime dt = DateTime.Now;

        public override void Action()
        {
            Console.WriteLine(this.Name);
        }

        public override void Poll()
        {
        }
    }
}
