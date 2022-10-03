using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot type/Wave")]
public class Wave : ShootingType
{
    public WaveAnimation WaveAnim;
    private WaveAnimation activeRing;
    public bool ShootSwitch { set { isShooting = value; } }
    private bool isShooting = false;
    public override bool IsShootUpdating { get => isShooting; }
    private void ShootRing()
    {
        activeRing.Play();
    }
    private void OnEnable()
    {
        activeRing = null;
        isShooting = false;
    }
    public override void Shoot(Vector3 dir)
    {
        if(activeRing == null)
        {
            activeRing = Instantiate(WaveAnim);
            activeRing.Init(this);
        }
        if (!isShooting)
        {
            isShooting = true;
        }
    }

    public override void UpdateShooting()
    {
        if (isShooting)
        {
            ShootRing();
        }
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
