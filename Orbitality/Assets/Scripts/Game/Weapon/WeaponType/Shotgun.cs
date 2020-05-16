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
        public override void Shot(Vector2 speed)
        {
            ShotgunParameters parameters = Parameters as ShotgunParameters;
            for (int i = 0; i < parameters.BulletsCount; i++)
            {
                Bullet bullet = CreateBullet();
                bullet.SetSpeed(Vector2.zero);
                bullet.SetPosition(new Vector2(transform.position.x, transform.position.z) +
                                   speed.normalized * (bullet.GetSize() + Owner.GetSize() + 5));
                if (speed.magnitude > parameters.BulletSpeed)
                {
                    speed = speed.normalized * parameters.BulletSpeed;
                }
                bullet.SetSpeed(speed + GetNormal(speed)*UnityEngine.Random.Range(-parameters.RangeOffset, parameters.RangeOffset));
            }
        }

        private static Vector2 GetNormal(Vector2 origin)
        {
            return new Vector2(origin.y, origin.x);
        }
    }
}