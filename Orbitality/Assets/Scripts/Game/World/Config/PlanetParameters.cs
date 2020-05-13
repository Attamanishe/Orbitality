using System;
using UnityEngine;

[Serializable]
public struct PlanetParameters : IPlanetParameters
{
    //used for save/load process
    public int Id => m_Id;
    public int m_Id;
    public float m_Health;
    public float m_Speed;
    public float m_LifeTime; 
    public float GetHealth()
    {
        return m_Health;
    }

    public float GetSpeed()
    {
        return m_Speed;
    }

    public void SetSpeed(float speed)
    {
        m_Speed = speed;
    }

    public void SetHealth(float health)
    {
        m_Health = health;
    }

    public float GetLifeTime()
    {
        return m_LifeTime;
    }

    public void SetLifeTime(float time)
    {
        m_LifeTime = time;
    }
}