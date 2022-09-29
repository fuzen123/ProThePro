using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot type/Part")]
public class PartDelay : ShootingType
{
    [SerializeField] private Projectil projectil;
    [SerializeField] private float flyTime = 1f;
    [SerializeField] private float projectilMaxVelocity = 15f;
    private List<Projectil> projectils = new List<Projectil>(3);
    private float[] angles = { 0f, 12f, 24f};
    private bool isShooting = false;
    private float timeElapsed = 0f;
    private bool startShoot = false;
    private Vector3 shootDirection;
    private int numberOfProjectils = 0;
    public override bool IsShootUpdating { get => isShooting; }
    private void OnEnable()
    {
        timeElapsed = 0f;
        numberOfProjectils = 0;
        isShooting = false;
        startShoot = false;
    }
    public override void Shoot(Vector3 direction)
    {
        if(!isShooting)
        {
            shootDirection = direction;
            startShoot = true;
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
                if (projectils[i].DetectHit())
                {
                    Hit(projectils[i]);
                }
            }
            if (timeElapsed > flyTime)
            {
                DestroyProjectils();
            }
        }
        if(startShoot)
        {
            ShootWithDelay();
        }
    }
    private void Hit(Projectil projectil)
    {
        projectils.Remove(projectil);
        Destroy(projectil.Hit.transform.gameObject);
        Destroy(projectil.gameObject);
    }
    private void ShootWithDelay()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > 0.25f)
        {
            var triDir = Quaternion.Euler(0f, angles[numberOfProjectils], 0f) * shootDirection;
            Projectil p = Instantiate(projectil);
            projectils.Add(p);
            p.StartFly(triDir, projectilMaxVelocity);
            numberOfProjectils++;
            timeElapsed = 0f;
            isShooting = true;
            if (numberOfProjectils == 3)
            {
                startShoot = false;
                numberOfProjectils = 0;
            }
        }        
    }
    private void DestroyProjectils()
    {
        for (int i = 0; i < projectils.Count; i++)
        {
            Destroy(projectils[i].gameObject);
        }
        numberOfProjectils = 0;
        projectils.Clear();
        timeElapsed = 0f;
        isShooting = false;
    }
}