using Game.Planets.Instance;
using Game.Weapon.Config;
using UnityEngine;

namespace Game.Weapon.Base
{
    public abstract class Weapon : MonoBehaviour, IWeapon
    {
        public int Id => Parameters.Id;
        [SerializeField] protected WeaponParameters Parameters;
        protected Planet Owner;

        public virtual float GetCooldown()
        {
            return Parameters.Cooldown;
        }

        public abstract void Shot(Vector2 speed, Vector2 position);

        public void Init(Planet owner)
        {
            Owner = owner;
        }
    }
}