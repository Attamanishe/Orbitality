using Game.Planets.Instance;
using UnityEngine;

namespace Game.Weapon.Base
{
    public interface IWeapon
    {
        int Id { get; }
        float GetCooldown();
        float GetDamage();
        float GetSpeed();
        void Shot(Vector2 speed);
        void Init(Planet owner);
    }
}