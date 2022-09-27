using UnityEngine;

public abstract class ShootStyle : MonoBehaviour
{
    public abstract void UpdateShooting();
    public abstract void Shoot(Vector3 direction);
}
