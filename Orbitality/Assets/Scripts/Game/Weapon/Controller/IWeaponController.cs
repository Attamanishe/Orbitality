using Game.Weapon.Base;
using UnityEngine;

namespace Game.Weapon.Controller
{
    public interface IWeaponController
    {
        void Shot(Vector2 speed);
        float GetCooldown();
        float GetMaxSpeed();
    }
}