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
                
                planetState.Id = planetConfig.Id;
                planetState.WeaponId = weaponConfig.Model.Id;
                planetState.Health = planetConfig.Health;
                planetState.MaxHealth = planetConfig.Health;
                planetState.Speed = planetConfig.Speed;
                planetState.LifeTime = UnityEngine.Random.Range(0, 1000);
                state.PlanetStates.Add(planetState);
            }

            PlanetState planetStates = state.PlanetStates[Random.Range(0, state.PlanetStates.Count)];
            planetStates.isControlledByPlayer = true;
            state.PlanetStates[Random.Range(0, state.PlanetStates.Count)] = planetStates;
            
            return state;
        }
    }
}