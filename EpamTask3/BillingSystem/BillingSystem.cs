using ATE.Models.Interfaces;
using BillingSystem.Models.Interfaces;

namespace BillingSystem
{
    internal class BillingSystem : IBillingSystem
    {
        private IATE ate;

        public BillingSystem(IATE ate)
        {
            this.ate = ate;
        }
    }
}