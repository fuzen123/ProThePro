using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoystick : MonoBehaviour
{
    public EasyJoystick.Joystick joystick;
    private Rigidbody charRB;
    private bool isGrounded = true;
    private bool inJump = false;
    public LayerMask ground;
    public LayerMask jumpObstacle;
    void Start()
    {
        charRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(joystick.Horizontal(), 0f, joystick.Vertical());
        if(!inJump)
            transform.Translate(m * 5f * Time.deltaTime, Space.World);

        if(Physics.Raycast(transform.position+new Vector3(0f, 0.5f, 0f), transform.forward, 2f, jumpObstacle.value))
        {
            Jump();
        }
    }
    private void FixedUpdate()
    {
        if (inJump)
        {
            isGrounded = false;
            if (Physics.Raycast(transform.position, Vector3.down, 1f, ground.value))
            {
                isGrounded = true;
                inJump = false;
            }
            
        }
    }
    private void Jump()
    {
        if (isGrounded && !inJump)
        {
            charRB.AddRelativeForce(0f, 6f, 5f, ForceMode.Impulse);
            inJump = true;
            Debug.Log("hej");
        }
        //isGrounded = false;
    }
    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(0.1f);
        inJump = false;
    }
}
