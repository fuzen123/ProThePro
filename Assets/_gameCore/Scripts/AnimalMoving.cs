using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalMoving : MonoBehaviour
{
    public float speed = 1f;
    Transform _player;
    public void Set(Vector3 pos, Quaternion dir)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = pos;
        transform.rotation = dir;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = _player.position - transform.position;
        direction = Quaternion.Euler(0f, 50f, 0f) * direction;
        transform.rotation = Quaternion.LookRotation(direction);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, _player.position) < 4.5f)
            gameObject.SetActive(false);
    }
}
