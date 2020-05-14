using Common.Pool;
using Game.Weapon.Base;
using Game.Weapon.Config;
using UnityEngine;
using UnityEngine.XR.WSA;
using WorldManager = Game.World.Manager.WorldManager;

namespace Game.Weapon.WeaponType
{
    public class Machinegun : Base.Weapon
    {
        private PrefabsPool<Bullet> _pool;

        private void Awake()
        {
            _pool = new PrefabsPool<Bullet>(Parameters.BulletPrefab);
        }

        public override void Shot(Vector2 speed, Vector2 position)
        {
            
        }
    }
}