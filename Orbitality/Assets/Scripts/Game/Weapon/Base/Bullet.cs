using Common.Pool;
using Game.Physics;

namespace Game.Weapon.Base
{
    public class Bullet : MovablePhysicObject, IPoolable
    {
        public void Dispose()
        {
            gameObject.SetActive(false);
        }

        public void OnNew()
        {
            gameObject.SetActive(true);
        }
    }
}