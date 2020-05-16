using Game.Planets.Instance;
using Game.World.Config;
using Game.World.State;
using UnityEngine;

namespace Game.Planets.ModelFactory
{
    public class PlanetsMonoFactory : MonoBehaviour, IPlanetsFactory
    {
        public static IPlanetsFactory Instance { get; private set; }
        
        [SerializeField] private Planet _planetPrefab;
        [SerializeField] private Transform _instantiationRoot;

        private void Awake()
        {
            Instance = this;
        }

        public IPlanet Create(PlanetInstance modelPrefab, Weapon.Base.Weapon weaponPrefab, PlanetState state)
        {
            Planet planet = Instantiate(_planetPrefab, _instantiationRoot);
            PlanetInstance instance = Instantiate(modelPrefab, planet.transform);
            Weapon.Base.Weapon weapon = Instantiate(weaponPrefab, planet.transform);
            planet.Init(instance, weapon, state);
            return planet;
        }
    }
}