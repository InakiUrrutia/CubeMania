using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    CUBE = 1,
    BALL = 2
}

public class Player : MonoBehaviour
{

    public Rigidbody _body;
    public GameObject player;
    public Camera mainCamera;

    public float speed = 5f;
    public float horSpeed;
    public float verSpeed;
    public float jumpHeight = 200f;

    public bool isJumping = false;

    public Vector3 _inputs;

    public Mesh sphere;
    public Mesh cube;
    public BoxCollider boxCollider;
    public SphereCollider sphereCollider;

    public int shape = 1;

    public Vector3 startPosition = new Vector3(0.0f, 0.5f, -7.0f);

    void Start()
    {}

    // Update is called once per frame
    void Update()
    {

        horSpeed = Input.GetAxisRaw("Horizontal");
        verSpeed = Input.GetAxisRaw("Vertical");
        _inputs = new Vector3(horSpeed, 0f, verSpeed);
        if ( _inputs != Vector3.zero) // Rotates the cube
        {
            _body.AddTorque(verSpeed * 90, 0, -horSpeed * 90);
        }

        if (Input.GetButtonDown("Jump") && !isJumping) // Jumps when press spacebar
        {
            _body.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            isJumping = true;
        }

        if (isJumping) // Move while in air
        {
            _body.MovePosition(_body.position + _inputs * (speed / 2.5f) * Time.deltaTime);
        }
        else
        {
            _body.MovePosition(_body.position + _inputs * (speed / 5.0f) * Time.deltaTime);
        }

        if (Input.GetKeyDown("tab"))
        {
            player.GetComponent<MeshFilter>().mesh = sphere;
            boxCollider.enabled = false;
            sphereCollider.enabled = true;
            ChangeShape();
        }

        UpdateCamera();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isJumping)
        {
            isJumping = false;
        }
    }

    void ChangeShape()
    {
        if(shape == (int) Shape.CUBE)
        {
            shape = (int)Shape.BALL;
            BuildSphere();
            return;
        }
        shape = (int)Shape.CUBE;
        BuildCube();
        return;
    }

    void BuildCube()
    {
        player.GetComponent<MeshFilter>().mesh = cube;
        boxCollider.enabled = true;
        sphereCollider.enabled = false;
    }

    void BuildSphere()
    {
        player.GetComponent<MeshFilter>().mesh = sphere;
        boxCollider.enabled = false;
        sphereCollider.enabled = true;
    }

    void UpdateCamera()
    {
        mainCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 4.5f, player.transform.position.z - 8.0f);
        mainCamera.transform.LookAt(player.transform.position);
    }

    public void resetPosition()
    {
        player.transform.position = startPosition;
    }
}
