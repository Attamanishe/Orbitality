using UnityEngine;

namespace Game.Physics
{
    public abstract class PhysicObject : MonoBehaviour, IPhysicObject
    {
        protected Vector2 Position;
        [SerializeField] protected float Weigth;
        [SerializeField] protected float Radius;
        public float GetWeight()
        {
            return Weigth;
        }

        public virtual float GetSize()
        {
            return Radius;
        }

        public virtual bool CheckIntersection(IPhysicObject candidate)
        {
            return Vector2.Distance(GetPosition(), candidate.GetPosition()) < (GetSize() + candidate.GetSize());
        }

        public virtual void Intersect(IPhysicObject obj)
        {
        }

        public virtual Vector2 GetPosition()
        {
            return Position;
        }
    }
}