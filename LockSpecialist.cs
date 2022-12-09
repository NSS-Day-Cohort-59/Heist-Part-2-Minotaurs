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
            //Decrement bank VaultScore by Hacker SkillLevel
            b.VaultScore = b.VaultScore - SkillLevel;
            //Print to the console the name of robber and what action they are performing
            Console.WriteLine($"{Name} is trying to gain access to the vault. Decreased security by {SkillLevel}.");
            //If vault score is reduced to 0 or below print msg to console, hacker.name has opend the vault
            if (b.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has opened the vault!");
            }
        }

        public string PrintSpecialty()
        {
            return "LockSmith";
        }
    }
}