using System;
using UnityEngine;

namespace Game.Generation.State
{
    [Serializable]
    public struct 
        PlanetState
    {
        public int Id;
        public float Health;
        public float Speed;
        public Vector2 Position;
    }
}