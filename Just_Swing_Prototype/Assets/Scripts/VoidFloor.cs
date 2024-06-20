using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidFloor : MonoBehaviour
{

    public Transform player, destination;

    public GameObject playerG;

    public Rigidbody PlayerRB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider c)
    {

        if (c.gameObject.name == "Player")  
        {
            playerG.SetActive(false);

            player.position = destination.position;

            playerG.SetActive(true);

            PlayerRB.velocity = Vector3.zero;

            Debug.Log("Player Detected");
        }
    }
}
