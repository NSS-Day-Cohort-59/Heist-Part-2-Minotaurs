using System;
namespace PlanYourHeist2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank b)
        {
            b.VaultScore = b.VaultScore - SkillLevel;
            Console.WriteLine($"{Name} decreased security by {SkillLevel}");
            if (b.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled the alarm system!");
            }
        }

        public string PrintSpecialty()
        {
            return "Locksmith";
        }
    }
}