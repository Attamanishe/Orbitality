using System;
using System.Collections.Generic;

namespace Game.Generation.State
{
    [Serializable]
    public struct WorldState
    {
        public float RadiusStep;
        public float MinRadius;
        public List<PlanetState> PlanetStates;
    }
}