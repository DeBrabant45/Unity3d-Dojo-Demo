using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Decision
{
    public abstract class Decision<T> : ScriptableObject
    {
        public abstract bool Decide(T controller);
    }
}
