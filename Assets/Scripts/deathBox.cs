using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class deathBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Fall Detected");

            GameManager.Instance.deaths += 1;

            other.GetComponent<CharacterController>().enabled = false;
            other.transform.position = GameManager.Instance.lastSpawnPoint.transform.position;
            other.GetComponent<CharacterController>().enabled = true;
        }
    }
}
