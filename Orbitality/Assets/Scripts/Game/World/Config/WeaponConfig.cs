using UnityEngine;

namespace Game.World.Config
{
    [CreateAssetMenu(fileName = "NewWeaponConfig", menuName = "Generation/WeaponConfig", order = 0)]
    public class WeaponConfig : ScriptableObject
    {
        public Weapon.Base.Weapon Model;
    }
}