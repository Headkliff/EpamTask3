﻿using BillingSystem.Models.Interfaces;

namespace BillingSystem.Models.Classes
{
    public class BillingSystem : IBillingSystem
    {
        private IInfo<CallInfo> _info;

        public Report GetReport(int telephoneNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
