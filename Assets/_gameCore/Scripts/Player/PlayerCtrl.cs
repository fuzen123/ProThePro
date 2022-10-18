using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private CharacterRotating charRotate;
    [SerializeField] private Shooting shooting;
    [SerializeField] private TargetCircle targetcircle;

    private void Start()
    {
        targetcircle.Initialize(this);
    }
    private void Update()
    {
        charRotate.UpdateRotation();
        targetcircle.UpdateTargetCircle();
        shooting.Tick();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shooting.InitShoot(charRotate.LookingDirection());
        }
        if(Input.GetKeyDown(KeyCode.Z))
        {
            shooting.NextShootType();
        }
        if(Input.GetKeyDown(KeyCode.U))
        {
            shooting.UpgradeShoot();
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
