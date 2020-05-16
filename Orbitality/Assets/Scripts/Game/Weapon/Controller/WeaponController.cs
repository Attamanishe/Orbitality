using System;
using Game.Weapon.Base;
using Game.World.Manager;
using UnityEngine;

namespace Game.Weapon.Controller
{
    public class WeaponController : IWeaponController
    {
        protected Base.IWeapon Weapon;

        public void Init(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public virtual void Shot(Vector2 speed)
        {
            Weapon.Shot(speed);
        }

        public float GetCooldown()
        {
            return Weapon.GetCooldown();
        }

        public float GetMaxSpeed()
        {
            return Weapon.GetSpeed();
        }
    }
}