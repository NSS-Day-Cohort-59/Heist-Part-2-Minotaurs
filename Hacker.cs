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
            //Decrement bank AlarmScore by Hacker SkillLevel
            b.AlarmScore = b.AlarmScore - SkillLevel;
            //Print to the console the name of robber and what action they are performing
            Console.WriteLine($"{Name} is hacking the alarm system. Decreased security by {SkillLevel}.");
            //If alarm score is reduced to 0 or below print msg to console, hacker.name has disabled alarm
            if (b.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }

        public string PrintSpecialty()
        {
            return "Hacker";
        }
    }
}