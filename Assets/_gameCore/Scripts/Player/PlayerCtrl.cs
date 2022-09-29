using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private ShootingType shootStyle;
    [SerializeField] private CharacterRotating charRotate;
    [SerializeField] private Shooting shooting;

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
