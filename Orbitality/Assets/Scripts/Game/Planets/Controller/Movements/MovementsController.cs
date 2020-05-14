using System;
using Comon;
using Comon.Updater;
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
                if (planet.GetHealth() > 0)
                {
                    float speed = planet.GetSpeed();
                    Vector2 position = planet.GetPosition();
                    float currentRadius = _minRadius + (i * _radiusStep);
                    planet.SetPosition(MovingMath.GetPosition(planet.GetLifeTime(), currentRadius, speed));
                    planet.SetLifeTime(planet.GetLifeTime() + deltaTime);
                }
            }
        }
    }
}