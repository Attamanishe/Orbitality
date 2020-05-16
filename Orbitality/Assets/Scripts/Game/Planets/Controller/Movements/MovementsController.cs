using System;
using Common;
using Common.Updater;
using Game.Planets.Instance;
using Game.World.State;
using UnityEngine;

namespace Game.Planets.Controller.Movements
{
    public class MovementsController : Singleton<MovementsController>, IUpdateable
    {
        private float _radiusStep;
        private float _minRadius;

        protected MovementsController() : base()
        {
            UpdaterManager.Instance.Add(this);
        }

        public void Init(float radiusStep, float minRadius)
        {
            _radiusStep = radiusStep;
            _minRadius = minRadius;
        }

        public void DoUpdate(float deltaTime)
        {
            PlanetsController planetsController = PlanetsController.Instance;
            for (int i = 0; i < planetsController.GetCount(); i++)
            {
                IPlanet planet = planetsController.Get(i);
                //there will be destroyed planets with health < 0 in container to save progress and planets state
                PlanetState state = planet.GetPlanetState();
                if (state.Health > 0)
                {
                    float speed = state.Speed;
                    Vector2 position = state.Position;
                    float currentRadius = _minRadius + (i * _radiusStep);
                    planet.SetPosition(MovingMath.GetPosition(state.LifeTime, currentRadius, speed));
                    planet.SetLifeTime(state.LifeTime + deltaTime);
                }
            }
        }
    }
}