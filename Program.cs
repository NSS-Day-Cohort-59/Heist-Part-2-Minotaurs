using System;
using System.Collections.Generic;

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
                Console.WriteLine(Rolodex.Count);
                Console.WriteLine("What is the name of this crewmember?");
                string newCrewMemeber = Console.ReadLine();

                if (newCrewMemeber == "")
                {
                    break;
                }

                //print count of items in rolodex
                //prompt for new crewmemeber name
                //print possible types (lock,musc,hack)
                Console.WriteLine("Please Select a Specialty: 1). Hacker, 2). Muscle, 3). Locksmith ");
                //promt for user to select type
                int specialtySelected = int.Parse(Console.ReadLine());
                //prompt for skill level 1-100
                Console.WriteLine("What is this crewmember's skill level?");
                int selectedSkillLevel = int.Parse(Console.ReadLine());
                //promt for percentage cut
                Console.WriteLine("What cut of the loot they want?");
                int percentageWanted = int.Parse(Console.ReadLine());
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
            int securityguard = rnd.Next(0,101);
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
                        leastSecure ="Least Secure: Vault";
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

                Console.WriteLine(mostSecure);
                Console.WriteLine(leastSecure);
                Console.WriteLine("____________");
                Console.WriteLine();
                //Print out a report of the rolodex that includes the person's index, name, specialty, skill level and cut 
                foreach (IRobber robber in Rolodex)
                {
                    Console.WriteLine($"{robber.Name}, {robber.PrintSpecialty()}, {robber.SkillLevel}, {robber.PercentageCut}");
                }
        }
    }
}
