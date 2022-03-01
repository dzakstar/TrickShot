using System;

namespace TrickShot
{
    internal class Program
    {
        static void Main()
        {
            //outputs to console probe position based on initial inputs and time, and
            //whether or not it would hit target on each particular step of its journey.

            //TODO: implement user input and required logic surrounding that

            var trenchTopLeft = new Position(15, -4);
            var trenchBottomRight = new Position(25, -12);
            var trench = new Trench(trenchTopLeft, trenchBottomRight);
            
            var probeVelocity = new Velocity(7, -1);
            
            var probe = new Probe(probeVelocity, trench);

            Log(probe,0);
            for (int n = 1; n < 10; n++)
            {
                probe.NextStep();
                Log(probe,n);
            }
        }

        static void Log(Probe probe, int step)
        {
            Console.WriteLine($"CurrentStep: {step}, X:{probe.Position.X}, Y:{probe.Position.Y}, HasHitTarget:{probe.HasHitTarget}");
        }
    }
}
