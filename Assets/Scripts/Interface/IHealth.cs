using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD.Interfaces
{
    public interface IHealth
    {
        public Action<float> OnAmountChange { get; set; }
        public Action OnAmountEqualsZero { get; set; }
        public float Amount { get; set; }
        public void AddAmount(float amount);
        public void ReduceAmount(float amount);
    }
}
