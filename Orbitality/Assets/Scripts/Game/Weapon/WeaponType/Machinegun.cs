using Common.Pool;
using Game.Weapon.Base;
using Game.Weapon.Config;
using UnityEngine;
using UnityEngine.XR.WSA;
using WorldManager = Game.World.Manager.WorldManager;

namespace Game.Weapon.WeaponType
{
    public class Machinegun : Base.Weapon
    {
        private PrefabsPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new PrefabsPool<Bullet>(Parameters.BulletPrefab);
        }

        public override void Shot(Vector2 speed, Vector2 position)
        {
            Bullet bullet = _pool.Get(WorldManager.Instance.transform);
            bullet.SetPosition(new Vector2(transform.position.x, transform.position.z) +
                               speed.normalized * (bullet.GetSize() + Owner.GetSize() + 1));
            bullet.SetSpeed(Parameters.BulletSpeed * speed);
            bullet.OnCollision += b =>
            {
                _pool.Release(bullet);
            };
            
            bullet.OnRemoved += () =>
            {
                _pool.Release(bullet);
            };
        }
    }
}