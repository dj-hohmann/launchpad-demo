using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public enum LaunchPadStatus
    {
        OK,
        ALERT
    }

    public interface ILaunchpadPlugin
    {
        string Name { get; set; }
        LaunchPadStatus Status { get; set; }
        int Count { get; set; }
        void Monitor();
        void Action();
    }
}
