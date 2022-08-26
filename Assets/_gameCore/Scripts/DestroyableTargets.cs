using UnityEngine;
public abstract class DestroyableTargets : MonoBehaviour
{
    public abstract void SetOnStart(Vector3 pos, Quaternion direction);
    public abstract void TargetHit();
}
