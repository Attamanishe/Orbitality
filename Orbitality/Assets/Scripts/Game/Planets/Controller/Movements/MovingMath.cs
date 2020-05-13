using System;
using UnityEngine;

namespace Game.Planets.Controller.Movements
{
    public static class MovingMath
    {
        public static Vector2 GetPosition(float time, float radius, float speed)
        {
            float angle = speed * time / radius;
            Vector2 position;
            position.x = (float)(radius * Math.Cos(angle));
            position.y = (float)(radius * Math.Sin(angle));
            return position;
        }
    }
}