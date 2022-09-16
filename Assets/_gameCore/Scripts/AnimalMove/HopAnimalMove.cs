using System.Collections;
using UnityEngine;

public class HopAnimalMove : AnimalMoving
{
    [SerializeField] private float hopTime = 0.3f;
    [SerializeField] private float hopDelay = 0.2f;
    private float timeElapsed = 0f;
    private bool isMoving = false;
    
    private void HopingDot()
    {
        timeElapsed += Time.deltaTime;
        if(isMoving)
        {
            var y = timeElapsed*hopTime * Mathf.Sin(2f * Mathf.PI * Time.time);
            y = Mathf.Abs(y);
            direction = transform.forward * y;
            if (y > 1)
            {
                isMoving = false;
                timeElapsed = 0f;
            }
        }
        else
        {
            direction = Vector3.zero;
            if (timeElapsed > hopDelay)
            {
                timeElapsed = 0f;
                isMoving = true;
            }
        }
    }

    public override void Update()
    {
        HopingDot();
        base.Update();
    }
    public override void Set(Vector3 pos, Quaternion dir)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = pos;
        var orientDir = _player.position - transform.position;
        transform.rotation = Quaternion.LookRotation(orientDir);
        enabled = true;
    }
}