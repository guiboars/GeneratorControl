using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Generator
{
    public class Generator
    {
        private const int MaxRetries = 5;
        private const int RunTime = 3000;  // 3000 ms.
        private Sensor.Sensor Fuel { get; set; }
        private Sensor.Sensor Vibration { get; set; }
        private Sensor.Sensor Choke { get; set; }

        public Generator()
        {
            Fuel = new Sensor.Sensor() {Status = true};  // new generators are full of fuel. 
            Vibration = new Sensor.Sensor() { Status = false };  // they are not running.
            Choke = new Sensor.Sensor() {Status = true};  // the choke is engaged.
        }

        public bool HasFuel
        {
            get { return Fuel.Status; }
        }

        public bool IsRunning
        {
            get { return Vibration.Status; }
        }

        public bool IsChoked
        {
            get { return Choke.Status; }
        }

        public void EngageChoke()
        {
            Choke.Status = true;
        }

        public void DisengageChoke()
        {
            Choke.Status = false;
        }

        public void DrainFuel()
        {
            Fuel.Status = false;
        }

        public void Refuel()
        {
            Fuel.Status = true; // put more fuel in.
        }
        
        /// <summary>
        /// Runs the starting sequence.
        /// </summary>
        public void Start()
        {
            if (IsRunning || !HasFuel) return;
            EngageChoke();
            for (int i = 0; i < MaxRetries && !IsRunning; i++)
            {
                CrankEngine();
            }
        }

        /// <summary>
        /// Shuts the engine off.
        /// </summary>
        public void Stop()
        {
            if (IsRunning)
            {
                Vibration.Status = false;
            }
        }

        /// <summary>
        /// Simulate engine running.  Consumes fuel, disengages choke, sets vibration status.
        /// </summary>
        private void Run()
        {
            Choke.Status = false; // turn choke off.
            Vibration.Status = true; // it's vibrating, which means that it's running.
            //Thread.Sleep(RunTime); // do something.
            Fuel.Status = false; // use up all the fuel.
        }

        /// <summary>
        /// Turn the engine over, run if it will start.
        /// </summary>
        private void CrankEngine()
        {
            var willStart = ((new Random().Next()%10) < 8 );  // ~20% chance of failure.

            if(willStart)
            {
                Run();
            }
            return;
        }
    }
}
