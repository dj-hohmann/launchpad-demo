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
        int[,] grid = new int[7, 7];

        Midi.InputDevice inputDevice;
        Midi.OutputDevice outputDevice;
        Midi.Clock clock;

        const int amber = 127;
        const int green = 100;
        const int red = 2;

        public Launchpad(InputDevice inputDevice, OutputDevice outputDevice, Clock clock)
        {
            this.inputDevice = inputDevice;
            this.outputDevice = outputDevice;
            this.clock = clock;

            this.inputDevice.Open();
            this.inputDevice.NoteOn += new InputDevice.NoteOnHandler(NoteOn);
            this.inputDevice.NoteOff += new InputDevice.NoteOffHandler(NoteOff);
            this.inputDevice.StartReceiving(null);

            this.outputDevice.Open();
            this.ShowColours();
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
            PitchToXY(msg.Pitch);
            this.outputDevice.SendNoteOn(Channel.Channel1, msg.Pitch, amber);
        }

        public void NoteOff(NoteOffMessage msg)
        {
            this.outputDevice.SendNoteOn(Channel.Channel1, msg.Pitch, red);
            Console.WriteLine("Note Off " + msg.Pitch);
        }

        public void Send(int x, int y, int colour, int velocity)
        {

        }

        private void PitchToXY(Pitch pitch)
        {
            int p = (int)pitch;
            int x, y;

            if (p > 8)
            {
                x = p % 16;
                y = p / 16;
            }
            else
            {
                x = p;
                y = 0;
            }
        }

        private Pitch XYToPitch(int X, int Y)
        {
            int z;
            //Pitch p;

            z = (Y * 16) + X;
            return (Pitch)z;
        }
    }
}
