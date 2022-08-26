
using UnityEngine;

public class AnimalBig : DestroyableTargets
{
    private bool isAlive = true;
    private AnimalMoving animalMoving;

    private void Awake()
    {
        animalMoving = GetComponent<AnimalMoving>();
    }
    public override void TargetHit()
    {
        if (isAlive)
        {
            gameObject.SetActive(false);
            isAlive = false;
        }

    }
    public override void SetOnStart(Vector3 pos, Quaternion direction)
    {
        animalMoving.Set(pos, direction);
    }
}