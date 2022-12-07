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
             //Decrement the bank security score by Hacker SkillLevel
            
            throw new NotImplementedException();
        }
    }
}