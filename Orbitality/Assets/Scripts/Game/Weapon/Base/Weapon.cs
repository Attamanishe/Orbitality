using Common.Pool;
using Game.Planets.Instance;
using Game.Weapon.Config;
using Game.World.Manager;
using UnityEngine;

namespace Game.Weapon.Base
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public int Id => Parameters.Id;
        [SerializeField] protected WeaponParameters Parameters;
        protected Planet Owner;
        
        private PrefabsPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new PrefabsPool<Bullet>(Parameters.BulletPrefab);
        }
        public virtual float GetCooldown()
        {
            return Parameters.Cooldown;
        }

        public float GetDamage()
        {
           return Parameters.Damage;
        }

        public float GetSpeed()
        {
            return Parameters.BulletSpeed;
        }

        public abstract void Shot(Vector2 speed);

        public void Init(Planet owner)
        {
            Owner = owner;
        }
        
        protected Bullet CreateBullet()
        {
            Bullet bullet = _pool.Get(WorldManager.Instance.transform);

            bullet.Owner = this;

            bullet.OnCollision += b => { _pool.Release(bullet); };

            bullet.OnRemoved += () => { _pool.Release(bullet); };
            return bullet;
        }
    }
}