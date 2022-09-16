using System.Collections;
using UnityEngine;


public class ZigzagAnimalMove : AnimalMoving
{
    public float frequency = 10.0f; // Speed of sine movement
    public float magnitude = 1.0f; //  Size of sine movement, its the amplitude of the side curve

    public override void Update()
    {
        SetZigZagDirection();
        base.Update();
    }

    private void SetZigZagDirection()
    {
        direction = _player.position - transform.position;
        float angle = Mathf.Sin(Time.time * frequency) * magnitude;
        direction = Quaternion.Euler(0f, angle, 0f) * direction;

        transform.rotation = Quaternion.LookRotation(direction);
    }
}
