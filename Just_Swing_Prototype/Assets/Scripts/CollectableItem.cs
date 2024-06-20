using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{

    public int points = 0;
    protected GameManager gameManager;

    

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, 20f * Time.deltaTime, Space.Self);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Coin Collected");

        this.gameManager.UpdateScore(1);
        this.gameObject.SetActive(false);

        Destroy(gameObject);

        

    }
}
