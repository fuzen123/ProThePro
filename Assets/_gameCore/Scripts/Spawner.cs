using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private DestroyableTargets[] targetsObj;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float[] zPos = { -15f, 20f};
    [SerializeField] private float startDelay = 1f;
    [SerializeField] private float spawnInterval = 1.6f;

    private List<DestroyableTargets> liveTargets = new List<DestroyableTargets>();
    private void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }
    private void Spawn()
    {
        int rndTarget = Random.Range(0, targetsObj.Length);
        int rndZPos = Random.value < 0.61f ? 0 : 1;
        Quaternion dirR = Quaternion.Euler(0f, rndZPos == 0 ? 0f : 180f, 0f);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 0f, zPos[rndZPos]);
        DestroyableTargets go = (DestroyableTargets)Instantiate(targetsObj[rndTarget]);
        liveTargets.Add(go);
        go.SetOnStart(spawnPos, dirR);
    }
}
