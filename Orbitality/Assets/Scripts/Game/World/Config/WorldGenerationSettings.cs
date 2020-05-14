using System.Collections.Generic;
using UnityEngine;

namespace Game.World.Config
{
    [CreateAssetMenu(fileName = "NewWorldGenerationSettings", menuName = "Generation/WorldGenerationSettings", order = 0)]
    public class WorldGenerationSettings : ScriptableObject
    {
        public List<PlanetConfig> Configs;
        public List<WeaponConfig> WeaponConfigs;
        public float RadiusStep;
        public float MinRadius;
    }
}