using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWave : MonoBehaviour
{
    public WaveAnimation WaveAnim;

    public bool ShootSwitch { set { isReadyToFireOff = value; } }
    private bool isReadyToFireOff = true;

    void Start()
    {
        WaveAnim.Init(this);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isReadyToFireOff)
        {
            isReadyToFireOff = false;
            
        }
        if(!isReadyToFireOff)
        {
            WaveAnim.Play();
            //Physics.
        }
    }
}
