using System;
using Assets.Scripts.Background;
using Common.Updater;
using Game.Physics;
using Game.Planets.Controller;
using Game.Planets.Instance;
using Game.Weapon.Controller;
using UnityEngine;

namespace Game.AI
{
    public class AIWeaponController : IBackgroundUpdateable, IUpdateable, IDisposable
    {
        private const int MaxPower = 300;
        private const float TimeToLoad = 0.5f;
        
        private struct ShotResult
        {
            public bool IsReady;
            public Vector2 Speed;
        }
        
        private CooldownWeaponController _cooldownWeaponController;
        private IWeaponController _weaponController;
        private IPlanet _planet;
        private ShotResult _shotResult;
        private PhysicStaticObject _sun;
        public AIWeaponController(IPlanet planet, IWeaponController controller, PhysicStaticObject sun)
        {
            _planet = planet;
            _weaponController = controller;
            _cooldownWeaponController = new CooldownWeaponController(controller.GetCooldown() + TimeToLoad);
            _sun = sun;
        }

        public void DoBackgroundUpdate(float deltaTime)
        {
            if (_cooldownWeaponController.TimeLeft <= 0 && _planet.GetPlanetState().Health > 0)
            {
                IPlanet target = GetNearestPlanet();
                if (target != null)
                {
                    Vector2 dirraction = target.GetPlanetState().Position - _planet.GetPlanetState().Position;
                    
                    Vector2 normal = new Vector2(dirraction.y, dirraction.x);
                    float dist = (normal + dirraction).magnitude;
                    Vector2 toSun = _sun.GetPosition() + _planet.GetPlanetState().Position;
                    float coef = normal.magnitude / toSun.magnitude;
                    Vector2 comp = normal * coef;
                    
                    if (Vector2.Dot(toSun.normalized, comp.normalized) > 0)
                    {
                        comp = -comp;
                    }

                    dirraction += comp;
                    _shotResult.Speed = dirraction.normalized * MaxPower;
                    _shotResult.IsReady = true;
                }
            }
        }

        private IPlanet GetNearestPlanet()
        {
            IPlanet target = null;
            float minDistance = -1;

            for (int i = 0; i < PlanetsController.Instance.GetCount(); i++)
            {
                IPlanet candidate = PlanetsController.Instance.Get(i);
                if (candidate != _planet && candidate.GetPlanetState().Health > 0)
                {
                    float distance = Vector2.Distance(_planet.GetPlanetState().Position,
                        candidate.GetPlanetState().Position);
                    if (target == null || distance < minDistance)
                    {
                        target = candidate;
                        minDistance = distance;
                    }
                }
            }

            return target;
        }

        public void DoUpdate(float deltaTime)
        {
            if (_shotResult.IsReady)
            {
                _weaponController.Shot(_shotResult.Speed);
                _shotResult.IsReady = false;
                _cooldownWeaponController.Reset();
            }
        }

        public void Dispose()
        {
            _cooldownWeaponController.Dispose();
        }
    }
}