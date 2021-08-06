using System;
using AD.Decision;

namespace AD.StateMachine
{
    [Serializable]
    public abstract class Transition<T>
    {
        public abstract Decision<T> Decision { get; }
    }
}
