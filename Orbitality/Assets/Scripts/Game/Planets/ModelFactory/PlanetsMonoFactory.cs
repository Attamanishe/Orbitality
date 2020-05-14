using Game.Planets.Instance;
using Game.World.Config;
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

        public IPlanet Create(PlanetInstance modelPrefab, Weapon.Base.Weapon weaponPrefab, IPlanetParameters parameters)
        {
            Planet planet = Instantiate(_planetPrefab, _instantiationRoot);
            PlanetInstance instance = Instantiate(modelPrefab, planet.transform);
            Weapon.Base.Weapon weapon = Instantiate(weaponPrefab, planet.transform);
            planet.Init(instance, parameters, weapon);
            return planet;
        }
    }
}