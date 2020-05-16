using Common.Pool;
using Game.Physics;
using Game.Planets.Instance;
using UnityEngine;

namespace Game.Weapon.Base
{
    public class Bullet : MovablePhysicObject, IPoolable
    {
        public Weapon Owner;
        
        public override void Intersect(IPhysicObject obj)
        {
            base.Intersect(obj);
            //i could make some system to avoid type casting, but in is too much for 2 nights 
            if (obj is IPlanet planet)
            {
                planet.GotDamage(Owner.GetDamage());
            }
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