using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveOnCircle : MonoBehaviour
{
    public float angularVelocity = 1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.right, angularVelocity * 7f * Time.deltaTime);
    }
}
