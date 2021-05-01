using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{

    public Camera game_camera;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.GetComponent<Player>().control_camera)
        {
            game_camera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z - 4.0f);
            game_camera.transform.LookAt(player.transform.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Player>().control_camera = false;
    }

    void OnTriggerExit(Collider other)
    {
        player.GetComponent<Player>().control_camera = true;
    }
}
