﻿using AD.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHittable 
{
    void GetHit(IDamage damage);
}