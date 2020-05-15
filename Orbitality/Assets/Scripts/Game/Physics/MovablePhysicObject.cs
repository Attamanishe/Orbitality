using System;
using UnityEngine;

namespace Game.Physics
{
    public class MovablePhysicObject : PhysicObject, IMovableObject
    {
        public event Action<IPhysicObject> OnCollision;
        protected Vector2 Speed;

        public virtual void OnEnable()
        {
            PhysicsController.Instance.AddMovable(this);
        }


        public Vector2 GetSpeed()
        {
            return Speed;
        }

        public void SetSpeed(Vector2 speed)
        {
            Speed = speed;
        }
        
        public virtual void SetPosition(Vector2 position)
        {
            Position = position;
            Vector3 currentPosition = transform.localPosition;
            transform.localPosition = new Vector3(position.x, currentPosition.y, position.y);
        }

        public override void Intersect(IPhysicObject obj)
        {
            base.Intersect(obj);
            OnCollision?.Invoke(obj);
        }

        public virtual void OnDisable()
        {
            PhysicsController.Instance?.RemoveMovable(this);
        }

        public override void ClearListeners()
        {
            base.ClearListeners();
            OnCollision = null;
        }
    }
}