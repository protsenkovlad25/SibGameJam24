using UnityEngine;
using UnityEngine.Events;

public enum GravityDir
{
    Up,
    Down,
    Left,
    Right
}

public static class GravityDirection
{
    public static UnityEvent<Vector2> OnGravityChanged;

    public static Vector2 Direction;
    public static GravityDir GravityDir;

    public static void Up()
    {
        GravityDir = GravityDir.Up;
        Direction = new Vector2(0, 1);
        ChangeGravity();
    }

    public static void Down()
    {
        GravityDir = GravityDir.Down;
        Direction = new Vector2(0, -1);
        ChangeGravity();
    }

    public static void Left()
    {
        GravityDir = GravityDir.Left;
        Direction = new Vector2(-1, 0);
        ChangeGravity();
    }

    public static void Right()
    {
        GravityDir = GravityDir.Right;
        Direction = new Vector2(1, 0);
        ChangeGravity();
    }

    public static void TurnLeft()
    {
        switch(GravityDir)
        {
            case GravityDir.Up: Left(); break;
            case GravityDir.Down:  break;
            case GravityDir.Left: break;
            case GravityDir.Right: break;
        }
    }

    public static void TurnRight()
    {

    }

    private static void ChangeGravity()
    {
        OnGravityChanged?.Invoke(Direction);
    }
}


