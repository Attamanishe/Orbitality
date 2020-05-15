using Game.Planets.Instance;
using UnityEngine;

namespace Game.Weapon.Base
{
    public interface IWeapon
    {
        int Id { get; }
        float GetCooldown();
        void Shot(Vector2 speed, Vector2 position);
        void Init(Planet owner);
    }
}