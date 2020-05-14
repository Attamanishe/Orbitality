using System;
using Game.Weapon.Base;
using Game.World.Config;
using UnityEngine;

namespace Game.Planets.Instance
{
    public interface IPlanet
    {
        int Id { get; }
        int WeaponId { get; }
        event Action<IPlanet> OnLogicalDestroy; 
        void Init(IPlanetVisualModel planetInstance, IPlanetParameters parameters, IWeapon weapon);
        float GetHealth();
        float GetSpeed();
        float GetLifeTime(); 
        void SetLifeTime(float time);
        void SetSpeed(float speed);
        void GotDamage(float damage);
        void SetPosition(Vector2 position);
        Vector2 GetPosition();
    }
}