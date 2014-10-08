using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LaunchPadDemo
{
    public struct GridPosition
    {
        public int x;
        public int y;
    }

    public enum LaunchPadColour
    {
        BLANK = 0,
        RED = 11,
        GREEN = 60,
        AMBER = 62
    }

    public enum LaunchPadStatus
    {
        OK,
        ALERT
    }

    public interface ILaunchpadPlugin
    {
        string Name { get; set; }
        LaunchPadStatus Status { get; }
        bool Monitor { get; set; }
        void Action();
        void Poll();
    }
}
