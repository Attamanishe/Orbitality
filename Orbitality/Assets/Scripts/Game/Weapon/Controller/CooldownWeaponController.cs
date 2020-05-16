using System;
using Common.Updater;

namespace Game.Weapon.Controller
{
    public class CooldownWeaponController : IUpdateable, IDisposable
    {
        public float TimeLeft { get; private set; }

        private readonly float _coolcown;

        public CooldownWeaponController(float coolcown)
        {
            UpdaterManager.Instance.Add(this);
            _coolcown = coolcown;
        }

        public void Reset()
        {
            TimeLeft = _coolcown;
        }

        public void DoUpdate(float deltaTime)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= deltaTime;
            }
        }

        public void Dispose()
        {
            UpdaterManager.Instance?.Remove(this);
        }
    }
}