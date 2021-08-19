using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerInvestmentGame
{
    public enum Events { injury = 1, CarRepair, PayingBills, WinngingScratchOff, GettingPaid, ShoppingSpree, Inheritance,
        Lottery, Lawsuit, LawsuitBad, NautralDiaster, Famine, Diease, Pandemic, TaxFraud, Scam, DeathInTheFamily, College, Wedding, House}

    public class BadAndGoodEvents
    {
        public BadAndGoodEvents(Events eventTitle)
        {
            EventTitle = eventTitle;
        }

        // Dictionary of points
        Dictionary<Events, int> Event = new Dictionary<Events, int>
        {
            {Events.injury,-5000},
            {Events.CarRepair, -10000},
            {Events.PayingBills,-2500 },
            {Events.WinngingScratchOff, 10000},
            {Events.GettingPaid, 15000 },
            {Events.ShoppingSpree, -2000 },
            {Events.Inheritance, 40000 },
            {Events.Lottery, 500000 },
            {Events.Lawsuit, 85000  },
            {Events.LawsuitBad, -20000 },
            {Events.NautralDiaster, -4500 },
            {Events.Famine, -2000 },
            {Events.Diease, -5000 },
            {Events.Pandemic, -10000 },
            {Events.TaxFraud, -8000 },
            {Events.Scam, -5000 },
            {Events.DeathInTheFamily, -1000 },
            {Events.College, -20000 },
            {Events.Wedding, -3000 },
            {Events.House, -60000 },

        };

        // Dictionary of Sayings
        Dictionary<Events, string> EventMessage = new Dictionary<Events, string>
        {
            {Events.injury, "You broke your leg trying to prove to your friends you can still dunk!"},
            {Events.CarRepair, "The engine light is on but its alot worse because you put it off for over a year!!"},
            {Events.PayingBills, "Time to give away your hard earned money"},
            {Events.WinngingScratchOff, "Holy S*** I won 10,000 bucks!"},
            {Events.GettingPaid, "MONEY MONEY MONEY....MONNEEYYYY" },
            {Events.ShoppingSpree, "For some reason you have the sudden urge to treat yourself ... when you know you have bills coming up" },
            {Events.Inheritance, "That one realitive that you barley knew passed away, and now you  boatload of money"},
            {Events.Lottery, "Who ever said money didn't bring happieness... they're probaly broke." },
            {Events.Lawsuit, "You've found a shrimp tail in your ceral.... and that really ruined your day."},
            {Events.LawsuitBad, "You 'acidentally' ran someone over"},
            {Events.NautralDiaster,"GLOBAL WARMING IS A REAL THING!!!"},
            {Events.Famine, "There NOTHING to eat."},
            {Events.Diease, "Does anybody really know how this works?"},
            {Events.Pandemic,"You should've SOCIAL DISTANCE.... AND GOT VACCINATED!" },
            {Events.TaxFraud,"You commited tax fraud. I can't blame you for trying..." },
            {Events.Scam,"You got scammed..? Did you really think the person on the phone was the prince of Istanbul" },
            {Events.College,"The suits came looking for your college debt money so you had to pay up." },
            {Events.DeathInTheFamily, "Sadly someone in your family passed and now you have to plan out the funeral" },
            {Events.Wedding, "Your daughter just got married so you had to cough up the cash to pay for it. And got none of the family." },
            {Events.House, "You just bought a house with class. At least now you have a nonliquid asset." },
            
        };

        public Events EventTitle { get; set; }
        public int Points
        {
            get
            {
                return Event[EventTitle];
            }
        }
        public string Message
        {
            get
            {
                return EventMessage[EventTitle];
            }
        }
    }












    /*
    public class Injury : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("You broke your leg trying to prove to your friends you can still dunk!");
        }
    }
    public class CarRepair : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("The engine light is on but its alot worse because you put it" +
                " off for over a year!!");
        }
    }
    public class PayingBills : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("Time to give away your hard earned money");
        }
    }
    public class WinningScratchOff : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("Holy S*** I won 25 bucks!");
        }
    }
    public class GettingPaid : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("MONEY MONEY MONEY....MONNEEYYYY");
        }
    }
    public class ShoppingSpree : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("For some reason you have the sudden urge to treat yourself ..." +
                " when you know you have bills coming up");
        }
    }
    public class Inheritance : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("That one realitive that you barley knew passed away, and now you  boatload of money");
        }
    }
    public class Lottery : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("Who ever said money didn't bring happieness... they're probaly broke.");
        }
    }
    public class Lawsuit : BadAndGoodEvents
    {
        public override void Message()
        {
            Console.WriteLine("You've found a shrimp tail in your ceral.... and that really ruined your day.");
        }
    }

    public class LawsuitBad : BadAndGoodEvents 
    {
        public override void Message()
        {
            Console.WriteLine("You 'acidentally' ran someone over");
        }
    }
    */
}

