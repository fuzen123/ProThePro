using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] ShootStyle shootStyle;
    [SerializeField] CharacterRotating charRotate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        charRotate.UpdateRotation();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(charRotate.LookingDirection());
            shootStyle.Shoot();
        }
    }
}
