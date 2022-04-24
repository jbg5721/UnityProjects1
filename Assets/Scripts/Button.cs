using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject platform;
    public Animator anim;
    public GameObject platform2;
    public Animator anim2;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            anim.Play("move1");
            anim2.Play("move1");
            
        }

    }
}
