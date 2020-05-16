using System;
using Assets.Scripts.Background;
using Common.Updater;
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
        public AIWeaponController(IPlanet planet, IWeaponController controller)
        {
            _planet = planet;
            _weaponController = controller;
            _cooldownWeaponController = new CooldownWeaponController(controller.GetCooldown() + TimeToLoad);
        }

        public void DoBackgroundUpdate(float deltaTime)
        {
            if (_cooldownWeaponController.TimeLeft <= 0 && _planet.GetPlanetState().Health > 0)
            {
                IPlanet target = GetNearestPlanet();
                if (target != null)
                {
                    Vector2 dirraction = target.GetPlanetState().Position - _planet.GetPlanetState().Position;

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