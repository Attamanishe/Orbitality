using Common.Pool;
using Game.Physics;
using UnityEngine;

namespace Game.Weapon.Base
{
    public class Bullet : MovablePhysicObject, IPoolable
    {
        public override void Intersect(IPhysicObject obj)
        {
            base.Intersect(obj);
        }

        public void Dispose()
        {
            gameObject.SetActive(false);
            ClearListeners();
            transform.position = Vector3.zero;
            Position = Vector2.zero;
        }

        public void OnNew()
        {
            gameObject.SetActive(true);
        }
    }
}