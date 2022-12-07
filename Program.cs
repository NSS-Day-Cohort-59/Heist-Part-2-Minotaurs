using System;
using System.Collections.Generic;

namespace PlanYourHeist2
{
    class Program
    {
        static void Main(string[] args)
        {
            // In the Main method, create a List<IRobber> and store it in a variable named rolodex. This list will contain all possible operatives that we could employ for future heists. We want to give the user the opportunity to add new operatives to this list, but for now let's pre-populate the list with 5 or 6 robbers (give it a mix of Hackers, Lock Specialists, and Muscle).

            List<IRobber> Rolodex = new List<IRobber>()
            {
                new Hacker {
                    Name = "One",
                    SkillLevel = 10,
                    PercentageCut = 20
                },
                new Hacker {
                    Name = "Two",
                    SkillLevel = 40,
                    PercentageCut = 40
                },

                new Muscle {
                    Name = "Three",
                    SkillLevel = 50,
                    PercentageCut = 20
                },
                new Muscle {
                    Name = "Four",
                    SkillLevel = 10,
                    PercentageCut = 50
                },

                new LockSpecialist {
                    Name = "Five",
                    SkillLevel = 80,
                    PercentageCut = 10
                },
                new LockSpecialist {
                    Name = "Six",
                    SkillLevel = 15,
                    PercentageCut = 15
                }
            };

            // Print out the number of current operatives in the rolodex. 
            Console.WriteLine(Rolodex.Count);

            //Then prompt the user to enter the name of a new possible crew member.
            Console.WriteLine("What is the name of this new crewmember?");
            string newCrewMember = Console.ReadLine();

            //Print out a list of possible specialties and have the user select which specialty this operative has. 
            Console.WriteLine("Select speciality: 1. Hacker (Disables alarms) 2. Muscle (Disarms guards) 3. Locksmith (Cracks vault)");
            int specialitySelected = int.Parse(Console.ReadLine());

            //Prompt user to enter the crew member's skill level as an integer between 1 and 100. 
            Console.WriteLine("What is this crewmember's Skill Level? (1-100)");
            int skillLevelSelected = int.Parse(Console.ReadLine());

            //Prompt user to enter the percentage cut the crew member demands for each mission. 
            Console.WriteLine("What is this crewmember's percentage cut?");
            int percentageSelected = int.Parse(Console.ReadLine());

            //Instantiate the appropriate class for that crew member (based on their specialty) and they should be added to the rolodex.


        }
    }
}

