using System;
using UnityEngine;

public interface IPlanet
{
    int Id { get; }
    event Action<IPlanet> OnLogicalDestroy; 
    void Init(IPlanetVisualModel planetInstance, IPlanetParameters parameters);
    float GetHealth();
    float GetSpeed();
    float GetLifeTime(); 
    void SetLifeTime(float time);
    void SetSpeed(float speed);
    void GotDamage(float damage);
    void SetPosition(Vector2 position);
    Vector2 GetPosition();
}