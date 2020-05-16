using System.Collections.Generic;
using Common;
using Game.Planets.Controller;
using Game.Planets.Instance;

namespace Game.Weapon.Controller
{
    public class WeaponControllerDistributor : Singleton<WeaponControllerDistributor>
    {
        private WeaponControllerDistributor()
        {
        }

        public void BindPlayerController(out IPlanet planet, out IWeaponController weaponController)
        {
            planet = null;
            for (int i = 0; i < PlanetsController.Instance.GetCount(); i++)
            {
                IPlanet p = PlanetsController.Instance.Get(i);
                if (p.GetPlanetState().isControlledByPlayer)
                {
                    planet = p;
                    break;
                }
            }

            weaponController = new WeaponController(planet.GetWeapon());
        }

        public List<KeyValuePair<IPlanet, IWeaponController>> BindAIControllers()
        {
            List<KeyValuePair<IPlanet, IWeaponController>> list = new List<KeyValuePair<IPlanet, IWeaponController>>();
            for (int i = 0; i < PlanetsController.Instance.GetCount(); i++)
            {
                IPlanet p = PlanetsController.Instance.Get(i);
                if (!p.GetPlanetState().isControlledByPlayer)
                {
                    list.Add(new KeyValuePair<IPlanet, IWeaponController>(p, new WeaponController(p.GetWeapon())));
                }
            }

            return list;
        }
    }
}