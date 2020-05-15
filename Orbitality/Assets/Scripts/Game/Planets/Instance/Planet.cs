using System;
using Game.Physics;
using Game.Weapon.Base;
using Game.World.Config;
using UnityEngine;

namespace Game.Planets.Instance
{
    public class Planet : PhysicStaticObject, IPlanet
    {
        public int Id => _parameters.Id;
        public int WeaponId => _weapon.Id;
        public event Action<IPlanet> OnLogicalDestroy;
        private IPlanetParameters _parameters;
        private IPlanetVisualModel _planetInstance;
        private IWeapon _weapon;
        public void Init(IPlanetVisualModel planetInstance, IPlanetParameters parameters, IWeapon weapon)
        {
            _planetInstance = planetInstance;
            _parameters = parameters;
            _weapon = weapon;
            _weapon.Init(this);
        }
    
        public float GetHealth()
        {
            return _parameters.GetHealth();
        }

        public float GetSpeed()
        {
            return _parameters.GetSpeed();
        }

        public float GetLifeTime()
        {
            return _parameters.GetLifeTime();
        }

        public void SetLifeTime(float time)
        {
            _parameters.SetLifeTime(time);
        }

        public void SetSpeed(float speed)
        {
            _parameters.SetSpeed(speed);
        }

        public void GotDamage(float damage)
        {
            _parameters.SetHealth(_parameters.GetHealth() - damage);
            if (_parameters.GetHealth() <= 0)
            {
                OnLogicalDestroy(this);
                Destroy();
            }
        }

        public void SetPosition(Vector2 position)
        {
            Vector3 p = new Vector3(position.x, transform.localPosition.y, position.y);
            transform.localPosition = p;
            Position = position;
        }

        private void Destroy()
        {
            Destroy(gameObject, 3);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _weapon.Shot(Vector2.left, GetPosition());
            }
        }
    }
}