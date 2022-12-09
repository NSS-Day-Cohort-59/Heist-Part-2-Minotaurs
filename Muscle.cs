using System;
namespace PlanYourHeist2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank b)
        {
            //Decrement bank AlarmScore by Hacker SkillLevel
            b.SecurityGuardScore = b.SecurityGuardScore - SkillLevel;
            //Print to the console the name of robber and what action they are performing
            Console.WriteLine($"{Name} is fighting the guards. Decreased security by {SkillLevel}.");
            //If alarm score is reduced to 0 or below print msg to console, hacker.name has disabled alarm
            if (b.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has disarmed the guards!");
            }
        }
        public string PrintSpecialty()
        {
            return "Muscles";
        }
    }
}