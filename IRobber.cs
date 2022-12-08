using System;

namespace PlanYourHeist2
{
    public interface IRobber
    {
         string Name {get; set;}
         int SkillLevel {get; set;}
         int PercentageCut {get; set;}
         void PerformSkill(Bank b);
         //Print out the specialty property of each robber.
         string PrintSpecialty();
    }
}