using UnityEngine;

public class SpiralAnimalMove : AnimalMoving
{
    private void DirectionOrient()
    {
        direction = _player.position - transform.position;
        direction = Quaternion.Euler(0f, 50f, 0f) * direction;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public override void Update()
    {
        DirectionOrient();
        base.Update();
    }
}
