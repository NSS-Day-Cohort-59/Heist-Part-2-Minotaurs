using System;

namespace PlanYourHeist2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank b)
        {
            //Take the Bank parameter and decrement its appropriate security score by the SkillLevel.
            b.AlarmScore = b.AlarmScore - SkillLevel;

            //Print to the console the name of the robber and what action they are performing.
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel}!");

            //If the appropriate security score has be reduced to 0 or below, print a message to the console.
            if (b.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }
    }
}
