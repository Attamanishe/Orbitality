using System;
using UnityEngine;

namespace Game.Physics
{
    public interface IPhysicObject
    {
        float GetWeight();
        float GetSize();
        bool CheckIntersection(IPhysicObject candidate);
        void Intersect(IPhysicObject obj);
        Vector2 GetPosition();
        
    }
}