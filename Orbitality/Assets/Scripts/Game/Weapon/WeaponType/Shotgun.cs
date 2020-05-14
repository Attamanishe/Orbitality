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
                bullet.SetPosition(new Vector2(transform.localPosition.x, transform.localPosition.z));
                bullet.SetSpeed(parameters.BulletSpeed *
                                (speed + new Vector2(Random.Range(-parameters.RangeOffset, parameters.RangeOffset),
                                    Random.Range(-parameters.RangeOffset, parameters.RangeOffset))));
            }
        }
    }
}