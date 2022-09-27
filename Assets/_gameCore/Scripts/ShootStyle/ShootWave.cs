using UnityEngine;
using System.Collections;
public class ShootWave : ShootStyle
{
    public WaveAnimation WaveAnim;

    public bool ShootSwitch { set { isReadyToFireOff = value; } }
    private bool isReadyToFireOff = true;

    private void ShootRing()
    {
        WaveAnim.Play();
    }
    void Start()
    {
        WaveAnim.Init(this);        
    }

    public override void Shoot(Vector3 dir)
    {
        if(isReadyToFireOff)
        {
            isReadyToFireOff = false;
        }
    }

    public override void UpdateShooting()
    {
        if(!isReadyToFireOff)
        {
            ShootRing();
        }
    }
}
