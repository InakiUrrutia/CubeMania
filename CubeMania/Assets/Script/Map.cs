using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State
{
    READY = 1,
    FINISHED = 2
}
public class Map : MonoBehaviour
{

    public GameObject player;

    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<Player>().startPosition = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider collider)
    {
        player.GetComponent<Player>().ResetPosition();
    }
}
