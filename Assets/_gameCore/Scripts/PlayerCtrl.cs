using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] ShootStyle shootStyle;
    [SerializeField] CharacterRotating charRotate;

    void Update()
    {
        charRotate.UpdateRotation();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            shootStyle.Shoot(charRotate.LookingDirection());
        }
    }
}
