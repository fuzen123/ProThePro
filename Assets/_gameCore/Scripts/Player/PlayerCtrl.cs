using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private CharacterRotating charRotate;
    [SerializeField] private Shooting shooting;

    private void Update()
    {
        charRotate.UpdateRotation();
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
    }
}
