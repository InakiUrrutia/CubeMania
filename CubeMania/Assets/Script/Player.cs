using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody _body;

    public float speed = 100f;
    public float JumpHeight = 2f;

    private float distToGround;

    public Vector3 _inputs;

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update(){

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");
        _inputs = new Vector3(hor, 0f, ver).normalized;
        if(_inputs!= Vector3.zero)
        {
            transform.forward = _inputs;
        }
        transform.rotation = Quaternion.Euler(0,0,0);
        if (Input.GetButtonDown("Jump") && isGrounded() )
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
        }

    }

    void FixedUpdate()
    {
        _body.MovePosition(_body.position + _inputs * speed * Time.fixedDeltaTime);
   
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f);
    }
}
