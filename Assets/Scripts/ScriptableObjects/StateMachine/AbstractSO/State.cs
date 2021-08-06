using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.StateMachine
{
    public abstract class State<T> : ScriptableObject
    {
        public abstract void UpdateState(T controller);
        public abstract void DoActions(T controller);
        public abstract void CheckTransitions(T controller);
    }
}
