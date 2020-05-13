using System.Collections.Generic;
using Game.Generation.Config;
using Game.Generation.State;
using UnityEngine;

namespace Game.Generation
{
    public class LogicWorldGenerator : ILogicWorldGenerator
    {
        public WorldState Generate(int count, WorldGenerationSettings generationSettings)
        {
            WorldState state;
            state.MinRadius = generationSettings.MinRadius;
            state.RadiusStep = generationSettings.RadiusStep;
            state.PlanetStates = new List<PlanetState>(count);
            
            for (int i = 0; i < count; i++)
            {
                PlanetState planetState = new PlanetState();
                PlanetConfig planetConfig =
                    generationSettings.Configs[Random.Range(0, generationSettings.Configs.Count)];
                
                planetState.Id = i;
                planetState.Health = planetConfig.Parameters.GetHealth();
                planetState.Speed = planetConfig.Parameters.GetSpeed();
                
                state.PlanetStates.Add(planetState);
            }

            return state;
        }
    }
}