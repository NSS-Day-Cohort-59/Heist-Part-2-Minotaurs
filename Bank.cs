using System;

namespace PlanYourHeist2
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        //this is a compouted boolean property; also, boolean defaults to false
        public bool IsSecure
        {
            get
            {
                if (AlarmScore + VaultScore + SecurityGuardScore <= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
            set { }
        }
    }
}