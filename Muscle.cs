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
            b.SecurityGuardScore = b.SecurityGuardScore - SkillLevel;
            Console.WriteLine($"{Name} decreased security by {SkillLevel}");
            if (b.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }

        public string PrintSpecialty()
        {
            return "Muscle";

        }
    }
}