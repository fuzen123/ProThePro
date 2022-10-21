using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private List<ShootingType> shootTypes = new List<ShootingType>();
    [SerializeField] private ShootingType activeShootType;
    [SerializeField] private ShootUI shootui;
    private int currentShootTypeIndex = 0;
    public void Tick()
    {
        activeShootType.UpdateShooting();
        if (activeShootType.IsShootUpdating)
            shootui.SetProgressFillbar(activeShootType.PositionProgress());
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
            shootui.SetShootIindex(currentShootTypeIndex + 1);
        }
    }
    public void UpgradeShoot()
    {
        activeShootType.Upgrade();
    }
}
