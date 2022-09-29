using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private List<ShootingType> shootTypes = new List<ShootingType>();
    [SerializeField] private ShootingType activeShootTytpe;

    public void UpdateShoot()
    {
        activeShootTytpe.UpdateShooting();
    }
}
