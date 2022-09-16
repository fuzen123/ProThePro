using System.Collections;
using UnityEngine;

public class TriShoot : ShootStyle
{
    [SerializeField] private Projectil projectil;
    [SerializeField] private float flyTime = 1f;
    [SerializeField] private float projectilMaxVelocity = 15f;
    private Projectil[] projectils = new Projectil[3];
    private float[] triAngles = { -30f, 0f, 30f};
    private bool isShooting = false;
    private float timeElapsed = 0f;

    public override void Shoot(Vector3 direction)
    {
        if (!isShooting)
        {
            for (int i = 0; i < 3; i++)
            {
                var triDir = Quaternion.Euler(0f, triAngles[i], 0f) * direction;
                projectils[i] = Instantiate(projectil);
                projectils[i].StartFly(triDir, projectilMaxVelocity);
            }
            isShooting = true;
        }
    }

    public override void UpdateShooting()
    {
        if(isShooting)
        {
            timeElapsed += Time.deltaTime;
            for (int i = 0; i < projectils.Length; i++)
            {
                projectils[i].Moving();
            }
            if(timeElapsed > flyTime)
            {
                DestroyProjectils();
            }
        }
    }
    private void DestroyProjectils()
    {
        for (int i = 0; i < projectils.Length; i++)
        {
            Destroy(projectils[i].gameObject);
            projectils[i] = null;
        }
        //projectils = new Projectil[3];
        timeElapsed = 0f;
        isShooting = false;
    }
}
