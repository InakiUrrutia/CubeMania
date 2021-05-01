using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableRoof : MonoBehaviour
{

    public GameObject roof;
    public GameObject button;

    float downPos = -3.0f;

    public int state = (int)State.READY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<Button>().state == (int)State.FINISHED)
        {
            if (roof.transform.position.y > downPos)
            {
                roof.transform.Translate(new Vector3(0, -0.5f * Time.deltaTime, 0));
            }
        }

        if (roof.transform.position.y <= downPos)
        {
            enabled = false;
        }
    }
}
