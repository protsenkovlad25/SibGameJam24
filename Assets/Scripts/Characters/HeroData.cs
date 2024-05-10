using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroData
{
    public float MoveSpeed { get; set; }
    public float ShovelTime { get; set; }
    public float MaxFallSpeed { get; set; }
    public float InvFramesTime { get; set; }
    public float ShovelCooldown { get; set; }
    public float GravityChangeCD { get; set; }
    public float SpeedIncreaseTime { get; set; }

    public int Health { get; set; }
    public int MaxHealth { get; set; }
}
