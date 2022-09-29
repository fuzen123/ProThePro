using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private List<ShootingType> shootTypes = new List<ShootingType>();
    [SerializeField] private ShootingType activeShootType;
    private int currentShootTypeIndex = 0;
    public void Tick()
    {
        activeShootType.UpdateShooting();
    }
    public void InitShoot(Vector3 shootdirection)
    {
        activeShootType.Shoot(shootdirection);
    }
    public void NextShootType()
    {
        if(!activeShootType.IsShootUpdating)
        {
            currentShootTypeIndex = (currentShootTypeIndex + 1) % shootTypes.Count;
            activeShootType = shootTypes[currentShootTypeIndex];
        }
    }
    public void UpgradeShoot()
    {
        
    }
}
