using Game.Planets.Instance;
using Game.World.Config;
using Game.World.State;

namespace Game.Planets.ModelFactory
{
    public interface IPlanetsFactory
    {
        IPlanet Create(PlanetInstance prefab, Weapon.Base.Weapon weaponPrefab, PlanetState state);
    }
}