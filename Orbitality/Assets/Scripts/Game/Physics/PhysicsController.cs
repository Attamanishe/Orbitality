using System.Collections.Generic;
using Common;
using Common.Updater;
using UnityEngine;

namespace Game.Physics
{
    public class PhysicsController : MonoSingleton<PhysicsController>, IUpdateable
    {
        [SerializeField] private float _gravityScale = 100;
        private List<IPhysicObject> _staticObjects = new List<IPhysicObject>();
        private List<IMovableObject> _movableObjects = new List<IMovableObject>();

        protected override void Awake()
        {
            base.Awake();
            UpdaterManager.Instance.Add(this);
        }

        public void DoUpdate(float deltaTime)
        {
            CheckIntersections();
            UpdatePositions(deltaTime);
        }

        public void AddMovable(IMovableObject movablePhysicObject)
        {
            _movableObjects.Add(movablePhysicObject);
        }

        public void RemoveMovable(IMovableObject movablePhysicObject)
        {
            _movableObjects.Remove(movablePhysicObject);
        }

        public void AddStatic(IPhysicObject physicStaticObject)
        {
            _staticObjects.Add(physicStaticObject);
        }

        public void RemoveStatic(IPhysicObject physicStaticObject)
        {
            _staticObjects.Remove(physicStaticObject);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            UpdaterManager.Instance?.Remove(this);
        }

        private void CheckIntersections()
        {
            for (int i = 0; i < _staticObjects.Count; i++)
            {
                IPhysicObject staticObject = _staticObjects[i];
                for (int j = 0; j < _movableObjects.Count; j++)
                {
                    IPhysicObject movableObject = _movableObjects[j];
                    if (staticObject.CheckIntersection(movableObject))
                    {
                        staticObject.Intersect(movableObject);
                        movableObject.Intersect(staticObject);
                        break;
                    }
                }
            }
        }

        private void UpdatePositions(float deltaTime)
        {
            for (int j = 0; j < _movableObjects.Count; j++)
            {
                IMovableObject movableObject = _movableObjects[j];
                Vector2 speed = movableObject.GetSpeed();
                for (int i = 0; i < _staticObjects.Count; i++)
                {
                    IPhysicObject staticObject = _staticObjects[i];
                    Vector2 dirraction = staticObject.GetPosition() - movableObject.GetPosition();
                    float acceleration = staticObject.GetWeight() / dirraction.sqrMagnitude;
                    speed += dirraction.normalized * acceleration * deltaTime;
                }
                movableObject.SetPosition( movableObject.GetPosition()+speed * deltaTime);
                movableObject.SetSpeed(speed);
            }
        }
    }
}