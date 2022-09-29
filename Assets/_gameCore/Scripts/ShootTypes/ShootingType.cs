using UnityEngine;
public abstract class ShootingType : ScriptableObject
{
    public abstract void UpdateShooting();
    public abstract void Shoot(Vector3 direction);
}