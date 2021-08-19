using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerInvestmentGame.UI
{
    public class ProgramUI
    {
        private ScoresRepo _repo = new ScoresRepo();

        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            HighScores elon = new HighScores("Elon Musk", 200000000);
            HighScores dave = new HighScores("Homeless Dave", 30);
            HighScores karen = new HighScores("Karen", -23444);
            HighScores jordan = new HighScores("Jordan Belfort", 10000000);
            HighScores jordan2 = new HighScores("Jordan Belfort", 0);

            _repo.AddScore(elon);
            _repo.AddScore(dave);
            _repo.AddScore(karen);
            _repo.AddScore(jordan);
            _repo.AddScore(jordan2);
        }

        public void Menu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.Clear();
                Console.WriteLine("The game of life:\n\n" +
                    "1. Start Game\n\n" +
                    "2. Instructions\n\n" +
                    "3. High Scores\n\n" +
                    "4. Exit\n\n");

                string userInput = Console.ReadLine().ToLower();
                switch (userInput)
                {
                    case "1":
                    case "start game":
                    case "start":
                        TheGame();
                        break;
                    case "2":
                    case "instruction":
                        Instructions();
                        break;
                    case "3":
                    case "high scores":
                    case "scores":
                        string nm = "Name";
                        string scr = "Score";
                        Console.Clear();
                        Console.WriteLine($"{nm, -30} {scr, -30}\n ");
                        PrintAllScores();
                        break;
                    case "4":
                    case "exit":
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void TheGame()
        {
            // add length setting here if time
            double runningTotal = 0;
            int year = 2021;
            List<Investments> yourInvestments = new List<Investments>();

            // starting game and getting a job
            Console.Clear();
            Console.WriteLine("How many years would you like to go through?\n5 is a short game\n10 is a medium length game\n15 is a long game");
            int rounds = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Jobs job = GetJob();
            Console.WriteLine($"\nCongratulations you are now a {job.JobTitle} and you make ${job.Salary} a year.");
            ContinueMessage();

            // The body of the game
            for (int i = 0; i < rounds; i++)
            {
                Console.Clear();
                Console.WriteLine($"The year is {year}. Right now you have ${runningTotal}.\nPress enter to continue through {year}\n");
                Console.ReadKey();
                Console.Clear();
                //Get paid
                runningTotal += job.Salary;
                double expenses = job.Salary * 0.28;
                Console.WriteLine($"You got paid ${job.Salary}, after taxes! Don't ask me how it's such an even number I'm just a Console App\nYour current Balance is ${runningTotal}");
                runningTotal -= expenses;
                Console.WriteLine($"\nand... You immediately had to pay for your expenses totaling ${expenses} so your total is down to ${runningTotal}");
                ContinueMessage();
                Console.Clear();

                //Invesments
                Console.WriteLine("Do you want to make any investments? (y/n)");
                string response = Console.ReadLine().ToLower();

                if (response == "yes" || response == "y")
                {
                    Console.Clear();
                    bool wantToTrade = true;
                    while (wantToTrade)
                    {
                        Console.WriteLine("Do you want to buy or sell?");
                        string choice = Console.ReadLine();

                        if (choice == "buy")
                        {
                            Investments invesmentMade = MakeInvestment();
                            yourInvestments.Add(invesmentMade);
                            Console.WriteLine($"The investment of {invesmentMade.Name} was made.");
                            runningTotal -= invesmentMade.TotalCost;
                            Console.WriteLine($"You just spent {invesmentMade.TotalCost} on {invesmentMade.Name}");
                        }
                        else if (choice == "sell")
                        {
                            double investmentSells = SellInvestment(yourInvestments);
                            runningTotal += investmentSells;
                        }

                        Console.WriteLine("Do you wish to keep making trades? (y/n)");
                        string wantToKeepGoing = Console.ReadLine().ToLower();
                        if (wantToKeepGoing == "y" || wantToKeepGoing == "yes")
                        {
                            wantToTrade = true;
                        }
                        else
                        {
                            wantToTrade = false;
                        }
                    }
                    Console.WriteLine($"You are done making investments. Your current balance is ${runningTotal} Press enter to continue...");
                    Console.ReadLine();
                }

                // Life Events
                Console.Clear();
                int rand = new Random().Next(1, 4);
                Console.WriteLine($"Now it's time for the life events. This year {rand} event(s) will happen");
                ContinueMessage();
                for ( int r = 0; r < rand; r++)
                {
                    Console.Clear();
                    BadAndGoodEvents gainLoss = EvenetsToOccur();
                    Console.WriteLine(gainLoss.Message);
                    EventMessage(gainLoss);
                    runningTotal += gainLoss.Points;
                    ContinueMessage();
                }
                Console.WriteLine($"After the events you are now at ${runningTotal}");
                ContinueMessage();
                year++;
            }
            // End of game messages 
            EndOfGameHighScores(runningTotal);
        }
        // End of the main funcionality of the game. 


        // End of game method
        public void EndOfGameHighScores(double running)
        {
            Console.Clear();
            Console.WriteLine($"The game is over! You finsihed with ${running}.\n");
            Console.WriteLine("Add your score to the leaderboard!");
            HighScores newScore = new HighScores();
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            newScore.Name = name;
            newScore.Score = running;
            _repo.AddScore(newScore);
        }
        // Get a job
        public Jobs GetJob()
        {
            Console.WriteLine("Time to figure your life out and get a job\n");
            Console.WriteLine("Choose the job option that you would like\n");
            string[] jobOptions = { "Doctor,", " Developer,", " Fry Cook,", " Teacher,", " TrashMan,", " Sales:\n" };

            foreach (string jobs in jobOptions)
            {
                Console.Write($"{jobs}");
            }
            string ans = Console.ReadLine().ToLower();
            Console.Clear();
            switch (ans)
            {
                case "doctor":
                    Console.WriteLine("You really thought you could be a doctor? You work in sales.");
                    Console.WriteLine("From here on out your a SalesPerson..... we're progressive here!!");
                    Jobs doctor = new Jobs(JobOptions.SalesPerson);
                    return doctor;
                case "developer":
                    Console.WriteLine("You picked Developer!\nBUILDER OF THE FUTURE");
                    Jobs deve = new Jobs(JobOptions.Developer);
                    return deve;
                case "teacher":
                    Console.WriteLine("You picked Teacher!\nYou poor soul... hopefully you don't choke a kid out!");
                    Jobs teach = new Jobs(JobOptions.Teacher);
                    return teach;
                case "trash man":
                case "trashman":
                    Console.WriteLine("You picked Trash man..?\nSomeones got to do it!");
                    Jobs trash = new Jobs(JobOptions.TrashMan);
                    return trash;
                case "sales":
                    Console.WriteLine("You Picked Sales!\nFrom here on out your a SalesPerson..... we're progressive here!!");
                    Jobs sales = new Jobs(JobOptions.SalesPerson);
                    return sales;
                default:
                    Console.WriteLine("You picked FryCook!\nYou've either messed up or actaully chose FryCook.");
                    Console.WriteLine("Either way this is ROCK BOTTOM");
                    Jobs job = new Jobs(JobOptions.FryCook);
                    return job;
            }
        }

        // Intructions tab
        public void Instructions()
        {
            Console.Clear();
            Console.WriteLine("1. Start the game\n\n");
            Console.WriteLine("2. Pick a class.\n\n");
            Console.WriteLine("3. You have up to 20 turn to make the most money." +
                " while doing so you'll have to overcome life.\n\n");
            Console.WriteLine("4. Every turn is a year and with that come possibly Good or Bad Events .....GOOD LUCK!!\n\n");
            ContinueMessage();
        }


        // Investment portion of game
        public Investments MakeInvestment()
        {
            Console.WriteLine("\nHere are your investment options. They're all going to the moon anyway.\n");
            string[] InvestmentOptionsArr = { "Doge", " Tesla", " Gamestop", " AMC", " Nokia", " BlockBuster", " MySpace", " Bond\n\n" };

            foreach (string jobs in InvestmentOptionsArr)
            {
                Console.Write($"{jobs}");
            }
            string ans = Console.ReadLine().ToLower();
            switch (ans)
            {
                case "doge":
                    Investments doge = new Investments(InvestmentOptions.Doge, Shares());
                    return doge;
                case "tesla":
                    Investments telsa = new Investments(InvestmentOptions.Tesla, Shares());
                    return telsa;
                case "gamestop":
                    Investments gamestop = new Investments(InvestmentOptions.GameStop, Shares());
                    return gamestop;
                case "amc":
                    Investments amc = new Investments(InvestmentOptions.AMC, Shares());
                    return amc;
                case "nokia":
                    Investments nokia = new Investments(InvestmentOptions.Nokia, Shares());
                    return nokia;
                case "blockbuster":
                    Investments blockbuster = new Investments(InvestmentOptions.BlockBuster, Shares());
                    return blockbuster;
                case "myspace":
                    Investments myspace = new Investments(InvestmentOptions.MySpace, Shares());
                    return myspace;
                default:
                    Console.WriteLine("You invested in a bond, which means you didn't really invest");
                    Investments bond = new Investments(InvestmentOptions.Bond, Shares());
                    return bond;
            }
        }

        public int Shares()
        {
            Console.Clear();
            Console.Write("How many shares do you want to buy? ");
            int total = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return total;
        }

        public double SellInvestment(List<Investments> sells)
        {
            Console.WriteLine("Which investment would you like to sell? The options you have to sell are below.");
            foreach (Investments item in sells)
            {
                Console.WriteLine($"Name: {item.Name}\n Shares: {item.TotalShares}");
            }
            string response = Console.ReadLine().ToLower();

            foreach (Investments item in sells)
            {
                string name = Convert.ToString(item.Name).ToLower();
                if (response == name)
                {
                    double gainOrLoss = item.AmountGainOrLoss - item.TotalCost;
                    Console.WriteLine($"Your investment of {item.Name} your gain or loss(-) was ${gainOrLoss}");
                    return item.AmountGainOrLoss;
                }
            }
            Console.WriteLine("Doesn't look like you have that Investment. The Suits block trading for the rest of the year.");
            return 0;
        }


        // Life events portion of game
        public void EventMessage(BadAndGoodEvents item)
        {

            Console.WriteLine($"This event happend: {item.EventTitle}\nYour change in score is: {item.Points}");
        }


        public BadAndGoodEvents EvenetsToOccur()
        {
            int randomNumber = new Random().Next(1, 21);
            Events randomEvent = (Events)randomNumber;
            BadAndGoodEvents theEvent = new BadAndGoodEvents(randomEvent);
            return theEvent;
        }

        // Code from 324 to 329 accomplishes same as literally everything typed out.....
        /*
        public double EventsThatHappen()
        {
            // Events randomEvent = (Events)randomNumber;
            // BadAndGoodEvents theEvent = new BadAndGoodEvents(randomEvent);
            //runningTotal += theEvent.Points;
            //theEvent.Message();
            int randomNumber = new Random().Next(1, 11);
            switch (randomNumber)
            {
                case 1:
                    BadAndGoodEvents injury = new BadAndGoodEvents(Events.injury);
                    Console.WriteLine("You broke your leg trying to prove to your friends you can still dunk!");
                    EventMessage(injury);
                    return injury.Points;
                case 2:
                    BadAndGoodEvents carRepair = new BadAndGoodEvents(Events.CarRepair);
                    Console.WriteLine("The engine light is on but its alot worse because you put it" +
        " off for over a year!!");
                    EventMessage(carRepair);
                    return carRepair.Points;
                case 3:
                    BadAndGoodEvents payingBills = new BadAndGoodEvents(Events.PayingBills);
                    Console.WriteLine("Time to give away your hard earned money");
                    EventMessage(payingBills);
                    return payingBills.Points;
                case 4:
                    BadAndGoodEvents winngingScratchOff = new BadAndGoodEvents(Events.WinngingScratchOff);
                    Console.WriteLine("Holy S*** I won 500 bucks!");
                    EventMessage(winngingScratchOff);
                    return winngingScratchOff.Points;
                case 5:
                    BadAndGoodEvents gettingPaid = new BadAndGoodEvents(Events.GettingPaid);
                    Console.WriteLine("MONEY MONEY MONEY....MONNEEYYYY");
                    EventMessage(gettingPaid);
                    return gettingPaid.Points;
                case 6:
                    BadAndGoodEvents shoppingSpree = new BadAndGoodEvents(Events.ShoppingSpree);
                    Console.WriteLine("For some reason you have the sudden urge to treat yourself ..." +
        " when you know you have bills coming up");
                    EventMessage(shoppingSpree);
                    return shoppingSpree.Points;
                case 7:
                    BadAndGoodEvents inHeritance = new BadAndGoodEvents(Events.Inheritance);
                    Console.WriteLine("That one realitive that you barley knew passed away, and now you  boatload of money");
                    EventMessage(inHeritance);
                    return inHeritance.Points;
                case 8:
                    BadAndGoodEvents lottery = new BadAndGoodEvents(Events.Lottery);
                    Console.WriteLine("Who ever said money didn't bring happieness... they're probaly broke.");
                    EventMessage(lottery);
                    return lottery.Points;
                case 9:
                    BadAndGoodEvents lawsuit = new BadAndGoodEvents(Events.Lawsuit);
                    Console.WriteLine("You've found a shrimp tail in your ceral.... and that really ruined your day.");
                    EventMessage(lawsuit);
                    return lawsuit.Points;
                case 10:
                default:
                    BadAndGoodEvents lawsuitBad = new BadAndGoodEvents(Events.LawsuitBad);
                    Console.WriteLine("You 'acidentally' ran someone over");
                    EventMessage(lawsuitBad);
                    return lawsuitBad.Points;
            }
        }*/

        // High scores Ui program calling from repo
        public void PrintAllScores()
        {
            _repo.PrintScores();
            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
        }

        public void ContinueMessage()
        {
            Console.WriteLine("\n\nPress Enter to continue...");
            Console.ReadKey();
        }
    }
}

