using System.Collections.Generic;
using Assets.Scripts.Background;
using Common;
using Common.Updater;
using Game.Physics;
using Game.Weapon.Controller;
using UnityEngine;

namespace Game.AI
{
    public class AIController : MonoSingleton<AIController>
    {
        [SerializeField] private PhysicStaticObject _sun;
        
        private List<AIWeaponController> _aiControllers;

        private void Start()
        {
            _aiControllers = new List<AIWeaponController>();
            foreach (var aiWeaponControllerModel in WeaponControllerDistributor.Instance.BindAIControllers())
            {
                AIWeaponController controller =
                    new AIWeaponController(aiWeaponControllerModel.Key, aiWeaponControllerModel.Value, _sun);
                BackgroundUpdater.Instance.Add(controller);
                UpdaterManager.Instance.Add(controller);
                _aiControllers.Add(controller);
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            foreach (var controller in _aiControllers)
            {
                BackgroundUpdater.Instance?.Remove(controller);
                UpdaterManager.Instance?.Remove(controller);
            }
        }
    }
}