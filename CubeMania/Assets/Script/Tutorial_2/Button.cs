using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    float upPos = -0.25f;
    float downPos = -0.40f;

    bool pressed = false;

    public int state = (int)State.READY;

    public GameObject button;

    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update()
    {
        if (!pressed)
        {
            if (button.transform.position.y < upPos)
            {
                button.transform.Translate(new Vector3(0, 0.15f * Time.deltaTime, 0));
            }
            button.GetComponent<Renderer>().material.color = Color.blue;
        }

        if (pressed)
        {
            if (button.transform.position.y > downPos)
            {
               button.transform.Translate(new Vector3(0, -0.15f * Time.deltaTime, 0));
            }
            else
            {
                state = (int)State.FINISHED;
            }
        }

        if(state == (int)State.FINISHED)
        {
            enabled = false;
            button.GetComponent<Renderer>().material.color = Color.green;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        if (normal == -transform.up && button.transform.position.y > downPos)
        {
            pressed = true;
        }

    }

    void OnCollisionExit(Collision collision)
    {
        pressed = false;
    }
}
