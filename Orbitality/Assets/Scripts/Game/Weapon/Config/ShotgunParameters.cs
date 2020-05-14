using UnityEngine;

namespace Game.Weapon.Config
{
    [CreateAssetMenu(fileName = "NewShotgunParameters", menuName = "Generation/ShotgunParameters", order = 0)]
    public class ShotgunParameters : WeaponParameters
    {
        public int BulletsCount;
        public float RangeOffset;
    }
}