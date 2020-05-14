using System;
using System.Collections;
using System.Collections.Generic;
using Game.Physics;
using UnityEngine;

public class Planet : PhysicStaticObject, IPlanet
{
    public int Id => _parameters.Id;
    public event Action<IPlanet> OnLogicalDestroy;
    private IPlanetParameters _parameters;
    private IPlanetVisualModel _planetInstance;
    
    public void Init(IPlanetVisualModel planetInstance, IPlanetParameters parameters)
    {
        _planetInstance = planetInstance;
        _parameters = parameters;
    }
    
    public float GetHealth()
    {
        return _parameters.GetHealth();
    }

    public float GetSpeed()
    {
        return _parameters.GetSpeed();
    }

    public float GetLifeTime()
    {
       return _parameters.GetLifeTime();
    }

    public void SetLifeTime(float time)
    {
        _parameters.SetLifeTime(time);
    }

    public void SetSpeed(float speed)
    {
        _parameters.SetSpeed(speed);
    }

    public void GotDamage(float damage)
    {
        _parameters.SetHealth(_parameters.GetHealth() - damage);
        if (_parameters.GetHealth() <= 0)
        {
            OnLogicalDestroy(this);
            Destroy();
        }
    }

    public void SetPosition(Vector2 position)
    {
        Vector3 p = new Vector3(position.x, transform.localPosition.y, position.y);
        transform.localPosition = p;
    }

    public Vector2 GetPosition()
    {
        return Vector2.zero;
    }

    private void Destroy()
    {
        Destroy(gameObject, 3);
    }
    
}