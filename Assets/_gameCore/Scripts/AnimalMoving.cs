using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoving : MonoBehaviour
{
    public float speed = 1f;
    public void Set(Vector3 pos, Quaternion dir)
    {
        transform.position = pos;
        transform.rotation = dir;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
