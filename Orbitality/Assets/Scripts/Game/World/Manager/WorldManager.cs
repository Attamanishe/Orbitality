using System;
using System.Linq;
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
    public class WorldManager : MonoBehaviour
    {
        [SerializeField] private WorldGenerationSettings _generationSettings;

        private ILogicWorldGenerator _logicWorldGenerator = new LogicWorldGenerator();

        private void Start()
        {
            CreateNewWorld(5);
        }

        public void CreateNewWorld(int countOfPlanets)
        {
            WorldState state = _logicWorldGenerator.Generate(countOfPlanets, _generationSettings);
            InstantiatePlanets(state);
            MovementsController.Instance.Init(state.RadiusStep,state.MinRadius);
        }

        private void InstantiatePlanets(WorldState state)
        {
            for (int i = 0; i < state.PlanetStates.Count; i++)
            {
                PlanetState planetState = state.PlanetStates[i];
                PlanetConfig config = _generationSettings.Configs.FirstOrDefault(c => c.Parameters.Id == planetState.Id);
                IPlanet planet = PlanetsMonoFactory.Instance.Create(config.Model, config.Parameters);
                planet.SetLifeTime(UnityEngine.Random.Range(0, 1000));
                PlanetsController.Instance.Add(planet);
            }
        }
    }
}