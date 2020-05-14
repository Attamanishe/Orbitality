using System;

namespace Common.Pool
{
    public interface IPoolable:IDisposable
    {
        void OnNew();
    }
}