using System;
using UnityEngine;

namespace Game.World.State
{
    [Serializable]
    public struct 
        PlanetState
    {
        public int Id;
        public int WeaponId;
        public float Health;
        public float MaxHealth;
        public float Speed;
        public Vector2 Position;      
        public float LifeTime;
        public bool isControlledByPlayer;
    }
}