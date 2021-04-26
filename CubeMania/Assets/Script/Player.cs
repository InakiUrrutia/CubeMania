using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody _body;

    public float speed = 5f;
    public float horSpeed;
    public float verSpeed;
    public float jumpHeight = 20f;

    public bool isJumping = false;

    private float distToGround;

    public Vector3 _inputs;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        this.horSpeed = Input.GetAxisRaw("Horizontal");
        this.verSpeed = Input.GetAxisRaw("Vertical");
        this._inputs = new Vector3(this.horSpeed, 0f, this.verSpeed);
        if (this._inputs != Vector3.zero) // Rotates the cube
        {
            this._body.AddTorque(this.verSpeed * 90, 0, -this.horSpeed * 90);
        }

        if (Input.GetButtonDown("Jump")) // Jumps when press spacebar
        {
            this._body.AddForce(Vector3.up * Mathf.Sqrt(this.jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            this.isJumping = true;
        }

        if (this.isJumping) // Move while in air
        {
            this._body.MovePosition(_body.position + _inputs * speed * Time.deltaTime);
        }
        else
        {
            this._body.MovePosition(_body.position + _inputs * (speed / 5.0f) * Time.deltaTime);
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.isJumping)
        {
            this.isJumping = false;
        }
    }
}
