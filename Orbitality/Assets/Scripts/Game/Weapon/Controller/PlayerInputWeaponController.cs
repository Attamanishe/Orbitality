using System;
using Common.Updater;
using Game.Planets.Instance;
using UI;
using UnityEngine;

namespace Game.Weapon.Controller
{
    public class PlayerInputWeaponController : MonoBehaviour, IUpdateable
    {
        [SerializeField] private float _sensativity = 600;

        private IWeaponController _controller;
        private IPlanet _planet;

        private float _holdTime;
        private Vector2 _lastTouchPosition;
        private Camera _cameraCached;
        private CooldownWeaponController _cooldownWeaponController;

        private void Start()
        {
            _cameraCached = Camera.main;
            WeaponControllerDistributor.Instance.BindPlayerController(out _planet, out _controller);
            _cooldownWeaponController = new CooldownWeaponController(_controller.GetCooldown());
            UpdaterManager.Instance.Add(this);
        }

        public void DoUpdate(float deltaTime)
        {
            HUD.Instance.UpdateCooldown(_cooldownWeaponController.TimeLeft / _planet.GetWeapon().GetCooldown());
            
            if (_planet.GetPlanetState().Health > 0 && _cooldownWeaponController.TimeLeft <= 0)
            {
                float speed = _holdTime * _sensativity;
                if (Input.GetMouseButton(0) && speed < _controller.GetMaxSpeed())
                {
                    _holdTime += Time.deltaTime;
                    _lastTouchPosition = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0) || speed >= _controller.GetMaxSpeed())
                {
                    Ray ray = _cameraCached.ScreenPointToRay(_lastTouchPosition);
                    RaycastHit hit;
                    if (UnityEngine.Physics.Raycast(ray, out hit))
                    {
                        Vector2 point = new Vector2(hit.point.x, hit.point.z);
                        Vector2 dirraction = point - _planet.GetPlanetState().Position;
                        _controller.Shot(dirraction.normalized * speed);
                        _holdTime = 0;
                        _cooldownWeaponController.Reset();
                    }
                }
            }
        }

        private void OnDestroy()
        {
            UpdaterManager.Instance?.Remove(this);
            _cooldownWeaponController.Dispose();
        }
    }
}