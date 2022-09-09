using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightShoot : ShootStyle
{
    public GameObject projectil;

    private GameObject currentProjectil = null;
    private bool canShoot = true;
    public override void Shoot(Vector3 direction)
    {
        if(canShoot)
        {
            canShoot = false;
            currentProjectil = Instantiate(projectil);
            currentProjectil.GetComponent<Projectil>().StartFly(this, direction);
        }
    }
    public void ResetShoot()
    {
        canShoot = true;
    }
}
