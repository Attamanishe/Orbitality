using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Game.Planets.Controller;
using Game.Planets.Controller.Movements;
using Game.Planets.Instance;
using Game.Planets.ModelFactory;
using Game.Weapon.Config;
using Game.Weapon.Controller;
using Game.World.Config;
using Game.World.Logic;
using Game.World.State;
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
                IPlanet planet = PlanetsController.Instance.Get(i);
                PlanetState planetState = planet.GetPlanetState();
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
                    _generationSettings.Configs.FirstOrDefault(c => c.Id == planetState.Id);

                WeaponConfig weaponParameters =
                    _generationSettings.WeaponConfigs.FirstOrDefault(w => w.Model.Id == planetState.WeaponId);
                IPlanet planet =
                    PlanetsMonoFactory.Instance.Create(config.Model, weaponParameters.Model, planetState);
                PlanetsController.Instance.Add(planet);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            PlanetsController.Instance.Dispose();
            MovementsController.Instance.Dispose();
            WeaponControllerDistributor.Instance.Dispose();
            Time.timeScale = 1;
        }

        public void Pause()
        {
            Time.timeScale = 0;
        }

        public void Resume()
        {
            Time.timeScale = 1;
        }
    }
}