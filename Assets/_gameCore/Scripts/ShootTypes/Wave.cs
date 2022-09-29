using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Shoot type/Wave")]
public class Wave : ShootingType
{
    public WaveAnimation WaveAnim;
    private WaveAnimation activeRing;
    public bool ShootSwitch { set { isReadyToFireOff = value; } }
    private bool isReadyToFireOff = true;

    private void ShootRing()
    {
        activeRing.Play();
    }

    public override void Shoot(Vector3 dir)
    {
        if(activeRing == null)
        {
            activeRing = Instantiate(WaveAnim);
            activeRing.Init(this);
        }
        if (isReadyToFireOff)
        {
            isReadyToFireOff = false;
        }
    }

    public override void UpdateShooting()
    {
        if (!isReadyToFireOff)
        {
            ShootRing();
        }
    }
}
