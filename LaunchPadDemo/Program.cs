using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Midi;

namespace LaunchPadDemo
{
    class Program
    {
        private static Launchpad launchPad;

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += AppDomain_ProcessExit; 
            launchPad = null;
            InputDevice i = null;
            OutputDevice o = null;

            Console.WriteLine("Starting up...");

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
                launchPad = new Launchpad(i, o, new Midi.Clock(120));
                Console.WriteLine("Device found and locked!!!");
                DateTime time = DateTime.Now;
                while (DateTime.Now < time.AddSeconds(1))
                {
                }
                launchPad.Clear();
                while (!Console.KeyAvailable && launchPad != null)
                {
                    launchPad.Update();
                }
            }
            else
            {
                Console.WriteLine("Device not found!!!");
            }
            
            Console.ReadKey();
            if (launchPad != null)
            {
                launchPad.Close();
            }
        }

        private static void AppDomain_ProcessExit(object sender, EventArgs e)
        {
            if (launchPad != null)
            {
                launchPad.Close();
            }
        } 
    }
}

