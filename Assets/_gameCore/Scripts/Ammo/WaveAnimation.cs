using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    [SerializeField] private LayerMask hittargets;
    [SerializeField] private Vector3 waverange = new Vector3(2f, 1f, 2f);
    [SerializeField] private float spreadSpeed = 2f;

    private float rad;
    private Wave shooterwave = null;
    private Vector3 startSize;
    private RaycastHit[] hits = new RaycastHit[10];

    public float Progress { get { return (transform.localScale.x - startSize.x) / (waverange.x - startSize.x); } }
    public void Init(Wave sw)
    {
        shooterwave = sw;
        startSize = transform.localScale;
        var mr = GetComponent<MeshRenderer>();
        rad = mr.bounds.extents.x;
    }

    public void Play()
    {
        transform.localScale = Vector3.MoveTowards(transform.localScale, waverange, spreadSpeed * Time.deltaTime);
        if(transform.localScale.x >= waverange.x)
        {
            shooterwave.ShootSwitch = false;
            transform.localScale = startSize;

        }
        int n = Physics.SphereCastNonAlloc(transform.position, transform.localScale.x * rad, Vector3.up, hits, 1f, hittargets.value);
        for (int i = 0; i < n; i++)
        {
            hits[i].transform.GetComponent<DestroyableTargets>().TargetHit();
        }
    }
}
