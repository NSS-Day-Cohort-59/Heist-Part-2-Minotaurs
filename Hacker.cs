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
            //Decrement the AlarmScore by  the SkillLevel of the Hacker.
             b.AlarmScore -= SkillLevel;
            //Print name of robber and the action being performed to the console
            Console.WriteLine($"{Name} is hacking the alarm system. Decrease security by {SkillLevel}");
            //If AlarmScre is reduced to 0 or below pring msg to console, "hacker.name has disable alarm system"
            if(b.AlarmScore <= 0) {
                Console.WriteLine($"{Name} has disable the alarm system.");
            }
            
        }
    }
}      
           
   