using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot type/TriParalel")]
public class TriParalel : ShootingType
{
    [SerializeField] private Projectil projectil;
    [SerializeField] private float flyTime = 1f;
    [SerializeField] private float projectilMaxVelocity = 15f;
    [SerializeField] private float[] triAngles = { -30f, 0f, 30f };
    private List<Projectil> projectils = new List<Projectil>(3);
    private bool isShooting = false;
    private float timeElapsed = 0f;
    public override bool IsShootUpdating { get => isShooting; }

    public override void Shoot(Vector3 direction)
    {
        if (!isShooting)
        {
            for (int i = 0; i < 3; i++)
            {
                var triDir = Quaternion.Euler(0f, triAngles[i], 0f) * direction;
                Projectil p = Instantiate(projectil);
                projectils.Add(p);
                p.StartFly(triDir, projectilMaxVelocity);

            }
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
    }
    private void Hit(Projectil projectil)
    {
        projectils.Remove(projectil);
        Destroy(projectil.Hit.transform.gameObject);
        Destroy(projectil.gameObject);
    }
    private void DestroyProjectils()
    {
        for (int i = 0; i < projectils.Count; i++)
        {
            Destroy(projectils[i].gameObject);
            projectils[i] = null;
        }
        projectils.Clear();
        timeElapsed = 0f;
        isShooting = false;
    }
}
