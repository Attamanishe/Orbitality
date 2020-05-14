using Game.Weapon.Base;
using UnityEngine;

namespace Game.Weapon.Config
{
    [CreateAssetMenu(fileName = "NewWeaponParameters", menuName = "Generation/WeaponParameters", order = 0)]
    public class WeaponParameters : ScriptableObject
    {
        public int Id;
        public float Cooldown;
        public float Damage;
        public float BulletSpeed;
        public Bullet BulletPrefab;
    }
}