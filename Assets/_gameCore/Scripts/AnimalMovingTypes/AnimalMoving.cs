using UnityEngine;

public class AnimalMoving : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    
    protected Transform _player = null;
    protected Vector3 direction = Vector3.up;
    public virtual void Set(Vector3 pos, Quaternion dir)
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = pos;
        transform.rotation = dir;
        enabled = true;
    }

    public virtual void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        ReachGoal();
    }

    private void ReachGoal()
    {
        if (Vector3.Distance(transform.position, _player.position) < 5.0f)
            gameObject.SetActive(false);
    }
}
