using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct HeroData
{
    public float MoveSpeed;
    public float ShovelTime;
    public float MaxFallSpeed;
    public float InvFramesTime;
    public float ShovelCooldown;
    public float GravityChangeCD;
    public float SpeedIncreaseTime;

    public int Health;
    public int MaxHealth;
}
