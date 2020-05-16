using System;
using Game.Weapon.Base;
using Game.World.Config;
using Game.World.State;
using UnityEngine;

namespace Game.Planets.Instance
{
    public interface IPlanet
    {
        event Action<IPlanet> OnLogicalDestroy; 
        void Init(IPlanetVisualModel planetInstance, IWeapon weapon, PlanetState state);
        IWeapon GetWeapon();
        void GotDamage(float damage);
        void SetPosition(Vector2 position);
        PlanetState GetPlanetState();
        void SetLifeTime(float stateLifeTime);
    }
}