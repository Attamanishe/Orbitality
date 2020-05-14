using System;
using System.Collections.Generic;
using UnityEngine;

namespace Comon.Updater
{
    public class UpdaterManager : MonoSingleton<UpdaterManager>
    {
        private List<IUpdateable> _updateables;

        protected override void Awake()
        {
            base.Awake();
            _updateables = new List<IUpdateable>();
        }

        public void Add(IUpdateable updateable)
        {
            _updateables.Add(updateable);
        }

        public void Remove(IUpdateable updateable)
        {
            _updateables.Remove(updateable);
        }

        private void Update()
        {
            float delta = Time.deltaTime;
            for (int i = 0; i < _updateables.Count; i++)
            {
                _updateables[i].DoUpdate(delta);
            }
        }
    }
}