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
        public override void Shot(Vector2 speed)
        {
            Bullet bullet = CreateBullet();
            bullet.SetPosition(new Vector2(transform.position.x, transform.position.z) +
                               speed.normalized * (bullet.GetSize() + Owner.GetSize() + 1));
            if (speed.magnitude > Parameters.BulletSpeed)
            {
                speed = speed.normalized * Parameters.BulletSpeed;
            }
            bullet.SetSpeed(speed);
        }
    }
}