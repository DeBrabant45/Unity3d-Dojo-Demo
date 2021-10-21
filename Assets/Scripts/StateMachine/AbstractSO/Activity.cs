using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Activity
{
    public abstract class Activity<T> : ScriptableObject
    {
        public abstract void Act(T controller);
    }
}
