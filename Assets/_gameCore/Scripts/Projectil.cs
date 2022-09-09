using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 1f;
    StraightShoot shooter;
    private float timerr = 0f;
    private float destroyTime = 1f;
    public void StartFly(StraightShoot ss, Vector3 direction)
    {
        transform.rotation = Quaternion.LookRotation(direction);
        shooter = ss;
        enabled = true;
    }

    private void Update()
    {
        timerr += Time.deltaTime;
        if(timerr > destroyTime)
        {
            shooter.ResetShoot();
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * maxVelocity * Time.deltaTime, Space.Self);

        if(Physics.SphereCast(transform.position, 1f, transform.forward, out RaycastHit hit, 1f))
        {
            shooter.ResetShoot();
            Destroy(hit.transform.gameObject);
            Destroy(gameObject);
        }
    }
}
