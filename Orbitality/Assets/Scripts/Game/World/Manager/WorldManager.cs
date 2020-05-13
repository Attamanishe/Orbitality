using System;
using System.Collections.Generic;
using System.Linq;
using Comon;
using Game.Generation;
using Game.Generation.Config;
using Game.Generation.State;
using Game.Planets.Controller;
using Game.Planets.Controller.Movements;
using Game.Planets.Factory;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = System.Random;

namespace Game.World.Manager
{
    public class WorldManager : MonoSingleton<WorldManager>
    {
        [SerializeField] private WorldGenerationSettings _generationSettings;

        private ILogicWorldGenerator _logicWorldGenerator = new LogicWorldGenerator();

        private void Start()
        {
            //load world or create new one
            WorldState state = LaunchGameSettings.Instance.StateToLoad.PlanetStates == null
                ? _logicWorldGenerator.Generate(LaunchGameSettings.Instance.PlayersCount, _generationSettings)
                : LaunchGameSettings.Instance.StateToLoad;
           
            InstantiatePlanets(state);
            MovementsController.Instance.Init(state.RadiusStep, state.MinRadius);
        }

        public WorldState GetCurrentState()
        {
            WorldState state;
            state.MinRadius = _generationSettings.MinRadius;
            state.RadiusStep = _generationSettings.RadiusStep;
            state.PlanetStates = new List<PlanetState>(PlanetsController.Instance.GetCount());

            for (int i = 0; i < PlanetsController.Instance.GetCount(); i++)
            {
                PlanetState planetState = new PlanetState();
                IPlanet planet = PlanetsController.Instance.Get(i);
                planetState.Id = planet.Id;
                planetState.Health = planet.GetHealth();
                planetState.Speed = planet.GetSpeed();
                planetState.Position = planet.GetPosition();
                planetState.LifeTime = planet.GetLifeTime();

                state.PlanetStates.Add(planetState);
            }

            return state;
        }

        private void InstantiatePlanets(WorldState state)
        {
            for (int i = 0; i < state.PlanetStates.Count; i++)
            {
                PlanetState planetState = state.PlanetStates[i];
                PlanetConfig config =
                    _generationSettings.Configs.FirstOrDefault(c => c.Parameters.Id == planetState.Id);
                IPlanet planet = PlanetsMonoFactory.Instance.Create(config.Model, config.Parameters);
                planet.SetLifeTime(planetState.LifeTime);
                PlanetsController.Instance.Add(planet);
            }
        }
    }
}