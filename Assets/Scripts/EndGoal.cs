using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        

        // Check to see if the object is the player
        if (other.tag == "Player")
        {
            GameObject t = GameObject.Find("UI");
            float min = t.GetComponent<Timer>().minutes;
            float sec = t.GetComponent<Timer>().seconds;
            GameManager.Instance.minutes = min;
            GameManager.Instance.seconds = sec;

            // Turn the cursor on
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Go to end screen
            GameManager.Instance.goToLevel(2);
        }
    }

}
