using UnityEngine;

namespace Game.Weapon.Base
{
    public interface IWeapon
    {
        int Id { get; }
        float GetCooldown();
        void Shot(Vector2 speed, Vector2 position);
    }
}