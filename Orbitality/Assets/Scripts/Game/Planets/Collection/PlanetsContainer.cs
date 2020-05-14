using System.Collections.Generic;
using Game.Planets.Instance;

namespace Game.Planets.Collection
{
    public class PlanetsContainer: IPlanetsContainer
    {
        public int Count { get; private set; }
        private List<IPlanet> _planets;
        
        public PlanetsContainer()
        {
            _planets = new List<IPlanet>();
        }
        
        public void Add(IPlanet planet)
        {
            _planets.Add(planet);
            Count++;
        }

        public void Remove(IPlanet planet)
        {
            Count--;
        }

        public IPlanet Get(int index)
        {
            return _planets[index];
        }
    }
}