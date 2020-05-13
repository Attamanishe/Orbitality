using System;
using UnityEngine;

namespace Game.Planets.Factory
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

        public IPlanet Create(PlanetInstance modelPrefab, IPlanetParameters parameters)
        {
            Planet planet = Instantiate(_planetPrefab, _instantiationRoot);
            PlanetInstance instance = Instantiate(modelPrefab, planet.transform);
            planet.Init(instance, parameters);
            return planet;
        }
    }
}