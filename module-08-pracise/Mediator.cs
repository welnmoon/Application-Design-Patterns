using System;
using System.Collections.Generic;

namespace mediator
{
    public interface ITrafficMediator
    {
        void RegisterLight(TrafficLight light);
        void Notify(TrafficLight light, string state);
    }

    public abstract class TrafficLight
    {
        protected string color;
        protected ITrafficMediator trafficMediator;

        protected TrafficLight(ITrafficMediator trafficMediator)
        {
            this.trafficMediator = trafficMediator;
            this.trafficMediator.RegisterLight(this);
        }

        public abstract void ChangeLight(string color);
        public abstract void ReceiveNotification(string state);
    }

    // Пешеходный светофор
    public class PedestrianTraffic : TrafficLight
    {
        public PedestrianTraffic(ITrafficMediator trafficMediator) : base(trafficMediator)
        {
        }

        public override void ChangeLight(string color)
        {
            base.color = color;
            Console.WriteLine($"Пешеходный светофор: {color}");
            base.trafficMediator.Notify(this, color);
        }

        public override void ReceiveNotification(string state)
        {
            if (state == "Red")
            {
                Console.WriteLine("Стоп");
            }
            else if (state == "Green")
            {
                Console.WriteLine("Go");
            }
            else if (state == "Yellow")
            {
                Console.WriteLine("Готовься");
            }
        }
    }

    public class TrafficMediator : ITrafficMediator
    {
        private List<TrafficLight> trafficLights = new List<TrafficLight>();

        public void Notify(TrafficLight light, string state)
        {
            foreach (var item in trafficLights)
            {
                if (item != light)
                {
                    item.ReceiveNotification(state);
                }
            }
        }

        public void RegisterLight(TrafficLight light)
        {
            trafficLights.Add(light);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ITrafficMediator trafficMediator = new TrafficMediator();
            TrafficLight pedestrianTrafficLight = new PedestrianTraffic(trafficMediator);

            pedestrianTrafficLight.ChangeLight("Red");
            pedestrianTrafficLight.ChangeLight("Yellow");
            pedestrianTrafficLight.ChangeLight("Green");
        }
    }
}
