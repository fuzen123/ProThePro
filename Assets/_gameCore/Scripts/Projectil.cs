
using UnityEngine;

public class Projectil : MonoBehaviour
{
    private float _maxVelocity = 1f;
    public RaycastHit Hit { get; private set; }
    public void StartFly(Vector3 direction, float maxVelocity)
    {
        _maxVelocity = maxVelocity;
        transform.rotation = Quaternion.LookRotation(direction);
    }
    public void Moving()
    {
        transform.Translate(Vector3.forward * _maxVelocity * Time.deltaTime, Space.Self);
    }
    public bool DetectHit()
    {
        if(Physics.SphereCast(transform.position, 1f, transform.forward, out RaycastHit hit, 1f))
        {
            Hit = hit;
            return true;
        }
        return false;
    }
}
