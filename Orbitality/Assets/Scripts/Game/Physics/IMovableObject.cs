using System;
using UnityEngine;

namespace Game.Physics
{
    public interface IMovableObject : IPhysicObject
    {
        event Action<IPhysicObject> OnCollision;
        Vector2 GetSpeed();
        void SetSpeed(Vector2 speed);
        void SetPosition(Vector2 position);
    }
}