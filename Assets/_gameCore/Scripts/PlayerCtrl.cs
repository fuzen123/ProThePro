using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private ShootStyle shootStyle;
    [SerializeField] private CharacterRotating charRotate;

    private void Update()
    {
        charRotate.UpdateRotation();
        shootStyle.UpdateShooting();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootStyle.Shoot(charRotate.LookingDirection());
        }
    }
}
