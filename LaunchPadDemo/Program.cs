﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Midi;

namespace LaunchPadDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Launchpad launchPad = null;
            InputDevice i = null;
            OutputDevice o = null;

            foreach (InputDevice x in InputDevice.InstalledDevices)
            {
                if (x.Name == "Launchpad Mini")
                {
                    Console.WriteLine("Launchpad Found!");
                    i = x;
                }
            }
            foreach (OutputDevice x in OutputDevice.InstalledDevices)
            {
                if (x.Name == "Launchpad Mini")
                {
                    Console.WriteLine("Launchpad Found!");
                    o = x;
                }
            }
            if (i != null && o != null)
            {
                launchPad = new Launchpad(i, o, new Midi.Clock(60));
                Console.WriteLine("Device found and locked!!!");
                DateTime time = DateTime.Now;
                while (DateTime.Now < time.AddSeconds(3))
                {
                }
                //launchPad.Clear();
            }
            Console.ReadKey();
            launchPad.Clear();
            Console.ReadKey();
            if (launchPad != null)
            {
                launchPad.Close();
            }
        }
    }
}
