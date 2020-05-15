using System;
using Common.Pool;
using Game.Weapon.Base;
using Game.Weapon.Config;
using Game.World.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Weapon.WeaponType
{
    public class Shotgun : Base.Weapon
    {
        private PrefabsPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new PrefabsPool<Bullet>(Parameters.BulletPrefab);
        }

        public override void Shot(Vector2 speed, Vector2 position)
        {
            ShotgunParameters parameters = Parameters as ShotgunParameters;
            for (int i = 0; i < parameters.BulletsCount; i++)
            {
                Bullet bullet = _pool.Get(WorldManager.Instance.transform);
                bullet.SetSpeed(Vector2.zero);
                bullet.SetPosition(new Vector2(transform.position.x, transform.position.z) +
                                   speed.normalized * (bullet.GetSize() + Owner.GetSize() + 2));
                bullet.SetSpeed(parameters.BulletSpeed *
                                (speed + GetNormal(speed)*UnityEngine.Random.Range(-parameters.RangeOffset, parameters.RangeOffset)));

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

        private static Vector2 GetNormal(Vector2 origin)
        {
            return new Vector2(origin.y, origin.x);
        }
    }
}