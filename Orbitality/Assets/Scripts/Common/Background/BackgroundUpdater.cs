using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;
using UnityEngine;

namespace Assets.Scripts.Background
{
    public class BackgroundUpdater : MonoSingleton<BackgroundUpdater>
    {
        private List<IBackgroundUpdateable> _backgroundUpdatables;
        private Thread _updateThread;
        private bool _stoped = true;
        private bool _inited;

        protected override void Awake()
        {
            base.Awake();
            _backgroundUpdatables = new List<IBackgroundUpdateable>();

            if (!_stoped)
            {
                Stop();
            }

            _stoped = false;
            _updateThread = new Thread(DoUpdate);
            _updateThread.Start();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Stop();
        }

        private void LateUpdate()
        {
            _inited = true;
        }

        public void Stop()
        {
            if (!_stoped)
            {
                _stoped = true;

                lock (_backgroundUpdatables)
                {
                    _backgroundUpdatables.Clear();
                }

                _updateThread.Interrupt();
            }
        }

        public void Add(IBackgroundUpdateable updateable)
        {
            lock (_backgroundUpdatables)
            {
                _backgroundUpdatables.Add(updateable);
            }
        }

        public void Remove(IBackgroundUpdateable updateable)
        {
            lock (_backgroundUpdatables)
            {
                _backgroundUpdatables.Remove(updateable);
            }
        }

        private void DoUpdate(object obj)
        {
            const float sleepTime = 0.033f;
            const int sleepTimeMiliseconds = (int) (sleepTime * 1000);

            while (!_stoped)
            {
                lock (_backgroundUpdatables)
                {
                    for (int i = 0; i < _backgroundUpdatables.Count && _inited; i++)
                    {
                        try
                        {
#if UNITY_DEVELOPMENT || UNITY_EDITOR
                            UnityEngine.Profiling.Profiler.BeginSample(_backgroundUpdatables[i].GetType().Name);
#endif
                            _backgroundUpdatables[i].DoBackgroundUpdate(sleepTime);
                        }
                        catch (Exception e)
                        {
                            Debug.LogError(e.ToString());
                        }
#if UNITY_DEVELOPMENT || UNITY_EDITOR
                        finally
                        {
                            UnityEngine.Profiling.Profiler.EndSample();
                        }
#endif
                    }
                }

                try
                {
                    Thread.Sleep(sleepTimeMiliseconds);
                }
                catch
                {
                }
            }
        }
    }
}