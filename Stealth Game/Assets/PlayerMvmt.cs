using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmt : MonoBehaviour
{
    public CharacterController playerController;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f; // so player direction does not snap to place
    private float turnSmoothVelocity;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f) { // not sure why this is necessary, maybe it accounts for controller drift?
            
            // rotate player y-direction to point where they are going
            // Atan2(a, b) -> returns angle (rad) btwn x-axis & vector starting at (0,0) terminating at (a, b)
            // in this case, 0 degrees is when player is forward (normally 90 degrees)
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // smooth turning
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            // point the right way, and move in the right way
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            playerController.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        
    }
}
