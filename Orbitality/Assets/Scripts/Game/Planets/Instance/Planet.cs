using System;
using Game.Physics;
using Game.Weapon.Base;
using Game.World.Config;
using Game.World.State;
using UnityEngine;

namespace Game.Planets.Instance
{
    public class Planet : PhysicStaticObject, IPlanet
    {
        public int Id => _planetState.Id;
        public int WeaponId => _planetState.WeaponId;
        public event Action<IPlanet> OnLogicalDestroy;
        private IPlanetVisualModel _planetInstance;
        private IWeapon _weapon;
        private PlanetState _planetState;
        public void Init(IPlanetVisualModel planetInstance, IWeapon weapon, PlanetState state)
        {
            _planetInstance = planetInstance;
            _weapon = weapon;
            _weapon.Init(this);
            _planetState = state;
        }

        public IWeapon GetWeapon()
        {
            return _weapon;
        }

        public PlanetState GetPlanetState()
        {
            return _planetState;
        }

        public void SetLifeTime(float time)
        {
            _planetState.LifeTime = time;
        }

        public void GotDamage(float damage)
        {
            _planetState.Health -= damage;
            if (_planetState.Health <= 0)
            {
                OnLogicalDestroy?.Invoke(this);
                Destroy();
            }
        }
        
        public void SetPosition(Vector2 position)
        {
            Vector3 p = new Vector3(position.x, transform.localPosition.y, position.y);
            transform.localPosition = p;
            _planetState.Position = position;
            Position = position;
        }

        private void Destroy()
        {
            Destroy(gameObject, 3);
        }
    }
}