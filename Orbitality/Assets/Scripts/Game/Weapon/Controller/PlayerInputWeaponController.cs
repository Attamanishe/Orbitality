using Game.Planets.Instance;
using UnityEngine;

namespace Game.Weapon.Controller
{
    public class PlayerInputWeaponController : MonoBehaviour
    {
        [SerializeField] private float _sensativity;
        private IWeaponController _controller;
        private IPlanet _planet;

        private float _holdTime;
        private Vector2 _lastTouchPosition;
        private Camera _cameraCached;

        private void Start()
        {
            _cameraCached = Camera.main;
            WeaponControllerDistributor.Instance.BindPlayerController(out _planet, out _controller);
        }

        public void Update()
        {
            if (_planet.GetPlanetState().Health > 0)
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
                    }
                }
            }
        }
    }
}