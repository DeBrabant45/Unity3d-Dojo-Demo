using System;

namespace AD.Interfaces
{
    public interface IBaseStats
    {
        public IHealth Health { get; set; }
        public IStamina Stamina { get; set; }
        public IPosture Posture { get; set; }
    }
}