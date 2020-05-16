using Common;
using Game.Planets.Collection;
using Game.Planets.Instance;

namespace Game.Planets.Controller
{
    public class PlanetsController: Singleton<PlanetsController>
    {
        private PlanetsContainer _container;
        
        protected PlanetsController():base()
        {
            _container = new PlanetsContainer();
        }

        public void Add(IPlanet planet)
        {
            _container.Add(planet);
            if (planet.GetPlanetState().isControlledByPlayer)
            {
                PlayersPlanetObserver.Instance.Init(planet as Planet);
            }
        }
        
        public IPlanet Get(int index)
        {
            return _container.Get(index);
        }
        
        public int GetCount()
        {
            return _container.Count;
        }
    }
}