using AD.Weapons;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace AD.Interfaces
{
    public interface IDamage
    {
        public int Amount { get; }
        public GameObject ParticalEffect { get; }
        public AudioClip[] ContactSounds { get; }
    }
}
