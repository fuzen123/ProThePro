using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    public LayerMask hittargets;
    private MeshRenderer mr;
    private float rad;
    private Wave shooterwave = null;
    private Vector3 startSize;
    public Vector3 waverange = new Vector3(2f, 1f, 2f);
    public float spreadSpeed = 2f;
    private RaycastHit[] hits = new RaycastHit[10];
    public void Init(Wave sw)
    {
        shooterwave = sw;
        startSize = transform.localScale;
        mr = GetComponent<MeshRenderer>();
        rad = mr.bounds.extents.x;
    }

    public void Play()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, waverange, spreadSpeed * Time.deltaTime);
        if(transform.localScale.x >= waverange.x)
        {
            shooterwave.ShootSwitch = false;
            transform.localScale = startSize;

        }
        int n = Physics.SphereCastNonAlloc(transform.position, transform.localScale.x * rad, Vector3.up, hits, 1f, hittargets.value);
        for (int i = 0; i < n; i++)
        {
            hits[i].transform.GetComponent<DestroyableTargets>().TargetHit();
        }
    }
}
