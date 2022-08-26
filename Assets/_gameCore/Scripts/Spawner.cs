using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public DestroyableTargets[] targetsObj;
    public float xRange = 10f;
    public float[] zPos = { -15f, 20f};
    public float startDelay = 1f;
    public float spawnInterval = 1.6f;

    public List<DestroyableTargets> liveTargets = new List<DestroyableTargets>();
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }
    private void Spawn()
    {
        int rnTrgt = Random.Range(0, targetsObj.Length);
        int rndZPos = Random.value < 0.61f ? 0 : 1;
        Quaternion dirR = Quaternion.Euler(0f, rndZPos == 0 ? 0f : 180f, 0f);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0f, zPos[rndZPos]);
        DestroyableTargets go = (DestroyableTargets)Instantiate(targetsObj[rnTrgt]);
        liveTargets.Add(go);
        go.SetOnStart(spawnPos, dirR);
    }
}
