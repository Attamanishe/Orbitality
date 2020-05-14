using System.Collections.Generic;
using Game.World.Config;
using Game.World.State;
using UnityEngine;

namespace Game.World.Logic
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
                WeaponConfig weaponConfig =
                    generationSettings.WeaponConfigs[Random.Range(0, generationSettings.WeaponConfigs.Count)];
                
                planetState.Id = planetConfig.Parameters.Id;
                planetState.WeaponId = weaponConfig.Model.Id;
                planetState.Health = planetConfig.Parameters.GetHealth();
                planetState.Speed = planetConfig.Parameters.GetSpeed();
                planetState.LifeTime = UnityEngine.Random.Range(0, 1000);
                state.PlanetStates.Add(planetState);
            }

            return state;
        }
    }
}