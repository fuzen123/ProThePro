using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartShoot : ShootStyle
{
    [SerializeField] private Projectil projectil;
    [SerializeField] private float flyTime = 1f;
    [SerializeField] private float projectilMaxVelocity = 15f;
    private List<Projectil> projectils = new List<Projectil>(3);
    private float[] angles = { 0f, 12f, 24f };
    private bool isShooting = false;
    private float timeElapsed = 0f;

    public override void Shoot(Vector3 direction)
    {
        if (!isShooting)
        {
            StartCoroutine(ShootWithDelay(direction));
            isShooting = true;
        }
    }

    public override void UpdateShooting()
    {
        if (isShooting)
        {
            timeElapsed += Time.deltaTime;
            for (int i = 0; i < projectils.Count; i++)
            {
                projectils[i].Moving();
                if(projectils[i].DetectHit())
                {
                    Hit(projectils[i]);
                }
            }
            if (timeElapsed > flyTime)
            {
                DestroyProjectils();
            }
        }
    }
    private void Hit(Projectil projectil)
    {
        projectils.Remove(projectil);
        Destroy(projectil.Hit.transform.gameObject);
        Destroy(projectil.gameObject);
    }
    private IEnumerator ShootWithDelay(Vector3 dir)
    {
        for (int i = 0; i < 3; i++)
        {
            var triDir = Quaternion.Euler(0f, angles[i], 0f) * dir;
            Projectil p = Instantiate(projectil);
            projectils.Add(p);
            p.StartFly(triDir, projectilMaxVelocity);
            yield return new WaitForSeconds(0.25f);
            timeElapsed -= 0.25f;
        }        
    }
    private void DestroyProjectils()
    {
        for (int i = 0; i < projectils.Count; i++)
        {
            Destroy(projectils[i].gameObject);
        }
        projectils.Clear();
        timeElapsed = 0f;
        isShooting = false;
    }
}
