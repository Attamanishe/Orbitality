using Common;
using Game.World.Manager;
using UI;
using UnityEngine;

namespace Game.Planets.Instance
{
    public class PlayersPlanetObserver : MonoSingleton<PlayersPlanetObserver>
    {
        [SerializeField] private GameObject _playersPlanetMark;
        private Planet _planet;

        public void Init(Planet planet)
        {
            _planet = planet;
            Instantiate(_playersPlanetMark, _planet.transform);
            HUD.Instance.UpdateHealth(_planet.GetPlanetState().Health / _planet.GetPlanetState().MaxHealth);
            _planet.OnHealthChangePercents += HUD.Instance.UpdateHealth;
        }
    }
}