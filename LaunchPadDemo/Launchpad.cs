using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using Midi;

namespace LaunchPadDemo
{
    public class Launchpad
    {
        ILaunchpadPlugin[,] grid = new ILaunchpadPlugin[8, 8];

        bool demo = false;

        Midi.InputDevice inputDevice;
        Midi.OutputDevice outputDevice;
        Midi.Clock clock;

        Pitch lastPitch = Pitch.A0;
        DateTime lastPressed = DateTime.Now;

        public Launchpad(InputDevice inputDevice, OutputDevice outputDevice, Clock clock)
        {
            this.inputDevice = inputDevice;
            this.outputDevice = outputDevice;
            this.clock = clock;
            if (this.inputDevice.IsOpen) { this.inputDevice.Close(); }
            if (this.outputDevice.IsOpen) { this.outputDevice.Close(); }

            this.inputDevice.Open();
            this.inputDevice.NoteOn += new InputDevice.NoteOnHandler(NoteOn);
            this.inputDevice.StartReceiving(null);

            this.outputDevice.Open();
            this.ShowColours();
        }

        public void Update()
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (this.grid[x, y] == null)
                    {
                        this.outputDevice.SendNoteOn(Channel.Channel1, XYToPitch(x,y),(int)LaunchPadColour.BLANK);
                    }
                    else
                    {
                        this.grid[x,y].Poll();
                        switch(this.grid[x,y].Status)
                        {
                            case LaunchPadStatus.OK: this.outputDevice.SendNoteOn(Channel.Channel1, XYToPitch(x,y),(int)LaunchPadColour.GREEN);
                                                        break;
                            case LaunchPadStatus.ALERT: this.outputDevice.SendNoteOn(Channel.Channel1, XYToPitch(x,y),(int)LaunchPadColour.RED);
                                                        break;
                            default: this.outputDevice.SendNoteOn(Channel.Channel1, XYToPitch(x,y),(int)LaunchPadColour.BLANK);
                                            break;
                        }
                    }
                }
            }
        }

        private void ShowColours()
        {
            for (int i = 0; i < 127; i++)
            {
                outputDevice.SendNoteOn(Channel.Channel1, (Pitch)i, i);
            }
        }

        public void Clear()
        {
            for (int i = 0; i < 127; i++)
            {
                outputDevice.SendNoteOn(Channel.Channel1, (Pitch)i, 0);
            }
        }

        public void Close()
        {
            this.Clear();
            this.inputDevice.Close();
            this.outputDevice.Close();
        }

        public void NoteOn(NoteOnMessage msg)
        {
            if (msg.Pitch != lastPitch || lastPressed.AddMilliseconds(500) < DateTime.Now) // Prevent double tap
            {
                lastPressed = DateTime.Now;
                lastPitch = msg.Pitch;

                if ((int)msg.Pitch == 8)
                {
                    DemoSetup();
                }
                else
                {
                    GridPosition pos = PitchToXY(msg.Pitch);
                    Send(pos.x, pos.y);
                }
            }
            //this.outputDevice.SendNoteOn(Channel.Channel1, msg.Pitch, (int)LaunchPadColour.RED);
        }

        private void Send(int x, int y)
        {
            if (this.grid[x, y] != null)
            {
                this.grid[x, y].Action();
            }
        }

        private GridPosition PitchToXY(Pitch pitch)
        {
            GridPosition pos = new GridPosition();
            int p = (int)pitch;
            
            if (p > 8)
            {
                pos.x = p % 16;
                pos.y = p / 16;
            }
            else
            {
                pos.x = p;
                pos.y = 0;
            }
            return pos;
        }

        private Pitch XYToPitch(int X, int Y)
        {
            int z;
            //Pitch p;

            z = (Y * 16) + X;
            return (Pitch)z;
        }

        private void DemoSetup()
        {
            if (demo == false)
            {
                demo = true;
                this.grid = new ILaunchpadPlugin[8, 8];
                this.grid[2, 2] = new JenkinsPlugin() { Job = "aggregation-integration-builder", Build = "lastFailedBuild" };
                this.grid[5, 2] = new BlankPlugin() { Name = "Fe"};
                this.grid[3, 4] = new BlankPlugin() { Name = "Fi" };
                this.grid[4, 4] = new BlankPlugin() { Name = "Fo" };
                this.grid[2, 5] = new BlankPlugin() { Name = "Fum" };
                this.grid[5, 5] = new BlankPlugin() { Name = "Cake" };
                Console.WriteLine("Demo Mode Active...");
            }
        }
    }
}
