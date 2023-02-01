using System;

namespace EventApp
{
    public interface IWedding
    {
        void PrintEventData();
    }
    public interface IGraduation
    {
        void PrintEventData();
    }
    public class EventInfo
    {
        int id;
        string discription;
        double cost;
        public EventInfo(int newID, string newDisc, double newCost)
        {
            id = newID;
            discription = newDisc;
            cost = newCost;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Discription
        {
            get { return discription; }
            set { discription = value; }
        }
        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
        public override string ToString()
        {
            return "ID: " + ID.ToString() + " Discription: " + Discription.ToString() + " Cost: " + Cost.ToString();
        }
    }

    public class Event : IWedding, IGraduation
    {
        private EventInfo TheEvent;
        public Event (int newID, string newDisc, double newCost)
        {
            TheEvent = new EventInfo(newID, newDisc, newCost);
        }
        void IWedding.PrintEventData()
        {
            Console.WriteLine("Event Type 1: Wedding");
        }
        void IGraduation.PrintEventData()
        {
            Console.WriteLine("Event Type 2: Graduation");
        }
         public void PrintEventData()
        {
            Console.WriteLine("Event Type 3: Standard Event");
        }
        public override string ToString()
        {
            return TheEvent.ToString();
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            IWedding WeddingEvent = new Event(1, "Wedding", 1000);
            IGraduation GraduationEvent = new Event(2, "Graduation", 500);
            Event StandardEvent = new Event(3, "Standard Event", 100);
            WeddingEvent.PrintEventData();
            GraduationEvent.PrintEventData();
            StandardEvent.PrintEventData();
            Console.WriteLine(WeddingEvent);
            Console.WriteLine(GraduationEvent);
            Console.WriteLine(StandardEvent);
            Console.ReadLine();
        }
    }
}
