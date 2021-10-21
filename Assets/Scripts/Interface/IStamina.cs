using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Interfaces
{
    public interface IStamina
    {
        public float Amount { get; }
        public Action<float> OnAmountChange { get; set; }
        public bool IsRegenerating { get; }
        public void AddToStamina(float amount);
        public void ReduceStamina(float amount);
        public void SetTimePassed(float amount);
        public void StaminaRegeneration();
    }
}
