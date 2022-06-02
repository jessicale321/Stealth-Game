// WASD movement for player
// moves by using rigidbody velocity

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MvmtBasic : MonoBehaviour
{
    public float speed = 3f;
    float horTranslation;
    float vertTranslation;
    public Rigidbody rb; 
    Vector3 moveVector = new Vector3(0, 0, 0);

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    // Get player input
    void Update()
    {
        horTranslation = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime;
        vertTranslation = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime;

        moveVector = new Vector3(horTranslation, 0, vertTranslation).normalized;
    }

    void FixedUpdate() {
        rb.velocity = moveVector * speed;
    }
}
