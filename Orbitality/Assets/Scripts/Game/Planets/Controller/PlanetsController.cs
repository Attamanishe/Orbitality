﻿using Comon;

namespace Game.Planets.Controller
{
    public class PlanetsController: Singleton<PlanetsController>
    {
        private PlanetsContainer _container;
        
        public PlanetsController():base()
        {
            _container = new PlanetsContainer();
        }

        public void Add(IPlanet planet)
        {
            _container.Add(planet);
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