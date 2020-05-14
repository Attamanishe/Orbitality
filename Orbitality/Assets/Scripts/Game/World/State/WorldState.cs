using System;
using System.Collections.Generic;

namespace Game.World.State
{
    [Serializable]
    public struct WorldState
    {
        public float RadiusStep;
        public float MinRadius;
        public List<PlanetState> PlanetStates;
    }
}