using UnityEngine;

public class ZigzagAnimalMove : AnimalMoving
{
    [SerializeField] private float frequency = 10.0f;
    [SerializeField] private float magnitude = 1.0f;

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
