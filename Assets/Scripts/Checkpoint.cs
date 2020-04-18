using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

   // Deathzone deathzone;
    // Start is called before the first frame update
    Checkpoints checkpoints;
    private void Start()
    {
       // deathzone = GameObject.Find("Deathzone").GetComponent<Deathzone>();
        checkpoints = transform.parent.gameObject.GetComponent<Checkpoints>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            checkpoints.NextCheckpoint();
            //deathzone.respawnPositions = gameObject.transform.position;
            //gameObject.SetActive(false);
        }
    }
}
