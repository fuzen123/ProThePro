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

    public override void Shoot()
    {
        if(isReadyToFireOff)
        {
            isReadyToFireOff = false;
            StartCoroutine(PlayShoot());
        }
    }
    private IEnumerator PlayShoot()
    {
        while(!isReadyToFireOff)
        {
            ShootRing();
            yield return null;
        }
    }
}
