using Game.Planets.Instance;
using UnityEngine;

namespace Game.World.Config
{
    [CreateAssetMenu(fileName = "NewPlanetConfig", menuName = "Generation/PlanetConfig", order = 0)]
    public class PlanetConfig : ScriptableObject
    {
        public PlanetInstance Model;
        public PlanetParameters Parameters;
    }
}