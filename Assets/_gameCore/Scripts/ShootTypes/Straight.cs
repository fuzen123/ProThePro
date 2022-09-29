using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot type/Simple Straight")]
public class Straight : ShootingType
{
    [SerializeField] private Projectil projectil;
    [SerializeField] private float flyRange = 10f;
    [SerializeField] private float projectilMaxVelocity = 15f;
    private Projectil currentProjectil = null;
    private bool isShooting = false;

    public override void Shoot(Vector3 direction)
    {
        if (!isShooting)
        {
            isShooting = true;
            currentProjectil = Instantiate(projectil);
            currentProjectil.StartFly(direction, projectilMaxVelocity);
        }
    }

    public override void UpdateShooting()
    {
        if (isShooting)
        {
            currentProjectil.Moving();
            if (currentProjectil.DetectHit())
            {
                isShooting = false;
                Destroy(currentProjectil.Hit.transform.gameObject);
                Destroy(currentProjectil.gameObject);
            }
            if (Vector3.Distance(Vector3.zero, currentProjectil.transform.position) > flyRange)
            {
                isShooting = false;
                //todo: destroy objects in some range
                Destroy(currentProjectil.gameObject);
            }
        }
    }
}
