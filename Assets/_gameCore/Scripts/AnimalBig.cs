public class AnimalBig : DestroyableTargets
{
    private bool isAlive = true;
    public override void TargetHit()
    {
        if (isAlive)
        {
            gameObject.SetActive(false);
            isAlive = false;
        }

    }
}