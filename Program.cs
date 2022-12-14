using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourHeist2
{
    class Program
    {
        static void Main(string[] args)
        {
            //list of robbers
            List<IRobber> Rolodex = new List<IRobber>()
        {
            new Hacker {Name = "Bobert", SkillLevel= 10, PercentageCut = 20 },
            new Hacker {Name = "Bobble", SkillLevel= 40, PercentageCut = 40 },
            new Muscle {Name = "Sam", SkillLevel= 50, PercentageCut = 20 },
            new Muscle {Name = "Jim", SkillLevel= 10, PercentageCut = 50 },
            new LockSpecialist {Name = "Rob", SkillLevel= 80, PercentageCut = 10 },
            new LockSpecialist {Name = "Sallie", SkillLevel= 15, PercentageCut = 15 }
        };

            while (true)
            {
                //prompt for new crewmemeber name
                Console.Write("What is the name of this crewmember: ");
                string newCrewMemeber = Console.ReadLine();
                Console.WriteLine();

                //prompt continues till blank name entered
                if (newCrewMemeber == "")
                {
                    break;
                }

                //promt for user to select type
                Console.Write(@"Select a Specialty: 
                1). Hacker (disarms security system) 
                2). Muscle (disarms guards)
                3). Lockspecialist (disarms vault) 
                ");
                int specialtySelected = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //prompt for skill level 1-100
                Console.Write("What is this crewmember's skill level (1-100): ");
                int selectedSkillLevel = int.Parse(Console.ReadLine());
                Console.WriteLine();

                //promt for percentage cut
                Console.Write("What cut of the loot do they want (1-100): ");
                int percentageWanted = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("--------------------------------------");
                Console.WriteLine($"Rolodex Contacts: {Rolodex.Count}");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine();

                // create new class instance of specified type
                switch (specialtySelected)
                {
                    case 1:
                        //create new instance of hacker
                        Hacker one = new Hacker()
                        {
                            Name = newCrewMemeber,
                            SkillLevel = selectedSkillLevel,
                            PercentageCut = percentageWanted
                        };
                        Rolodex.Add(one);
                        break;
                    case 2:
                        //create new instance of muscle
                        Muscle Two = new Muscle()
                        {
                            Name = newCrewMemeber,
                            SkillLevel = selectedSkillLevel,
                            PercentageCut = percentageWanted
                        };
                        Rolodex.Add(Two);
                        break;
                    case 3:
                        //create new instance of lockspecialist
                        LockSpecialist Three = new LockSpecialist()
                        {
                            Name = newCrewMemeber,
                            SkillLevel = selectedSkillLevel,
                            PercentageCut = percentageWanted
                        };
                        Rolodex.Add(Three);
                        break;

                    default:
                        break;
                }
            }

            //randomly assign values for these properties:
            //AlarmScore (between 0 and 100)
            //VaultScore (between 0 and 100)
            //SecurityGuardScore (between 0 and 100)
            //CashOnHand (between 50,000 and 1 million)
            Random rnd = new Random();
            int alarm = rnd.Next(0, 101);
            int vault = rnd.Next(0, 101);
            int securityguard = rnd.Next(0, 101);
            int cash = rnd.Next(50000, 1000000);

            //Create a new bank object 
            Bank bank = new Bank()
            {
                AlarmScore = alarm,
                VaultScore = vault,
                SecurityGuardScore = securityguard,
                CashOnHand = cash
            };

            List<int> scores = new List<int>()
            {
                bank.AlarmScore, bank.VaultScore, bank.SecurityGuardScore
            };

            scores.Sort();

            string mostSecure = "";
            string leastSecure = "";

            foreach (int item in scores)
            {
                if (bank.AlarmScore == scores[0])
                {
                    leastSecure = "leastSecure: Alarm";
                }
                else if (bank.VaultScore == scores[0])
                {
                    leastSecure = "Least Secure: Vault";
                }
                else
                {
                    leastSecure = "Least Secure: Security Guards";
                };
                if (bank.AlarmScore == scores[2])
                {
                    mostSecure = "Most Secure: Alarm";
                }
                else if (bank.VaultScore == scores[2])
                {
                    mostSecure = "Most Secure: Vault";
                }
                else
                {
                    mostSecure = "Most Secure: Security Guards";
                }
            }
            Console.WriteLine("======================================");
            Console.WriteLine(mostSecure);
            Console.WriteLine(leastSecure);
            Console.WriteLine("======================================");
            Console.WriteLine();

            //Create a new List and store it in a variable called crew
            List<IRobber> crew = new List<IRobber>();

            // Allow the user to select as many crew members as they'd like from the rolodex. 
            while (true)
            {
                //Continue to print out the report after each crew member is selected, but the report should not include operatives that have already been added to the crew, or operatives that require a percentage cut that can't be offered.
                List<IRobber> availableOperatives = Rolodex
                    .Where(r => r.PercentageCut <= 100 - crew.Sum(r => r.PercentageCut))
                    .Where(r => crew.FirstOrDefault(o => o.Name == r.Name) == null)
                    .ToList();

                //Print out report of the rolodex that includes person's index, name, specialty, skill level and cut 
                Console.WriteLine();
                Console.WriteLine("+ Available People +");
                Console.WriteLine("--------------------------------------");
                for (int i = 0; i < availableOperatives.Count; i++)
                {
                    IRobber robber = availableOperatives[i];
                    Console.WriteLine($"{i}: {robber.Name}, {robber.PrintSpecialty()}, {robber.SkillLevel}, {robber.PercentageCut}");
                }

                //Prompt user to enter the index of the operative they'd like
                Console.WriteLine();
                Console.Write("Please pick an operative by #: ");
                string operativeIndex = Console.ReadLine();

                if (string.IsNullOrEmpty(operativeIndex))
                {
                    break;
                }

                //Find robber in rolodex
                IRobber chosenRobber = Rolodex[int.Parse(operativeIndex)];

                //Add robber to crew
                crew.Add(chosenRobber);
            }

            Console.WriteLine();
            Console.WriteLine("The heist will begin! Will your crew be successful?");
            Console.WriteLine("----------------------------------------------------------------");

            foreach (IRobber crewMember in crew)
            {
                //Each crew member should perform his/her skill on the bank.
                Console.WriteLine();
                crewMember.PerformSkill(bank);
            }

            //evaluate if the bank is secure
            if (bank.IsSecure)
            {
                //Print out a failure message to the user
                Console.WriteLine();
                Console.WriteLine("************************");
                Console.WriteLine("Bad job. Bank Wins!");
                Console.WriteLine("************************");
            }
            else
            {
                //Print out a success message to the user
                Console.WriteLine();
                Console.WriteLine("************************");
                Console.WriteLine("Good Job! Bank lost.");
                Console.WriteLine("************************");
            }



        }
    }
}