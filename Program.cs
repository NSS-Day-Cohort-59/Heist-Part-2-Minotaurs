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
                //prompt continues till blank name entered
                Console.Write("What is the name of this crewmember: ");
                string newCrewMemeber = Console.ReadLine();
                Console.WriteLine();

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

                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Rolodex Contacts: {Rolodex.Count}");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine();

                // create new class instance of specified type
                switch (specialtySelected)
                {
                    case 1:
                        //create new instance of hacker
                        Hacker One = new Hacker()
                        {
                            Name = newCrewMemeber,
                            SkillLevel = selectedSkillLevel,
                            PercentageCut = percentageWanted
                        };
                        Rolodex.Add(One);
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
            Random rnd = new Random();
            int alarm = rnd.Next(0, 101);
            int vault = rnd.Next(0, 101);
            int securityguard = rnd.Next(0, 101);
            int cash = rnd.Next(50000, 1000000);
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

            Console.WriteLine("==============================");
            Console.WriteLine(mostSecure);
            Console.WriteLine(leastSecure);
            Console.WriteLine("===========================+==");
            Console.WriteLine();

            //Create a new List and store it in a variable called crew
            List<IRobber> crew = new List<IRobber>();

            //Allow the user to select as many crew members as they'd like from the rolodex.
            while (true)
            {
                List<IRobber> availableOperatives = Rolodex
                    .Where(r => r.PercentageCut <= 100 - crew.Sum(r => r.PercentageCut))
                    .Where(r => crew.FirstOrDefault(o => o.Name == r.Name) == null)
                    .ToList();

                //Print out report of the rolodex that includes person's index, name, specialty, skill level and cut
                Console.WriteLine();
                Console.WriteLine("+++ Available People +++");

                for (int i = 0; i < availableOperatives.Count; i++)
                {
                    IRobber robber = availableOperatives[i];
                    Console.WriteLine($"{i}: {robber.Name}, {robber.PrintSpecialty()}, {robber.SkillLevel}, {robber.PercentageCut}");
                }

                //Prompt user to enter the index of the operative they'd like
                Console.WriteLine();
                Console.Write("Please pick an operative by #: ");
                string operativeIndex = Console.ReadLine();

                //break to get out of add members to crew loop
                if (string.IsNullOrWhiteSpace(operativeIndex))
                {
                    break;
                }

                //find robber in rolodex
                IRobber robberChosen = Rolodex[int.Parse(operativeIndex)];

                //add robber to crew
                crew.Add(robberChosen);
            }

            Console.WriteLine();
            Console.WriteLine("The heist will begin! Will your crew be successful?");
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();

            //Once the user enters a blank value for a crew member, we're ready to begin the heist. 
            //Each crew member should perform his/her skill on the bank
            foreach (IRobber crewmember in crew)
            {
                crewmember.PerformSkill(bank);
                Console.WriteLine();
            }

            //Afterwards, evaluate if the bank is secure. 
            //If not, the heist was a success! Print out a success message to the user.
            //If the bank does still have positive values for any of its security properties, the heist was a failure. 
            //Print out a failure message to the user.
            if (bank.IsSecure)
            {
                Console.WriteLine("**********************");
                Console.WriteLine("Bad job. Bank wins!");
                Console.WriteLine("**********************");
            }
            else
            {
                Console.WriteLine("**********************");
                Console.WriteLine("Good job! Bank loses.");
                Console.WriteLine("**********************");
            }
        }
    }
}
