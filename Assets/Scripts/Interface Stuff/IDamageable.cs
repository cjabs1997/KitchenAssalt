﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    void LoseHealth(int healthDelta);
    void Stun(float duration);
}
