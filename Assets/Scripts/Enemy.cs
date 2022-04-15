using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;



public class Enemy : MonoBehaviour
{
    [Header("Enemy Settings")]
    
    [Range(1,100)]
    public int points = 5;
    public GameObject brokenEnemy;

    

    [Header("Haptic Settings")]
    public bool haptics = true;
    [Range(0f, 5f)]
    public float leftSpeed = .5f;
    [Range(0f, 5f)]
    public float rightSpeed = .5f;
    [Range(0f, 5f)]
    public float duration = .1f;
    
    
    

    private void Awake()
    {
        
        
    }
        
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

       
    }

    

    IEnumerator PlayHaptics()
    {
        Gamepad.current.SetMotorSpeeds(leftSpeed, rightSpeed);
        yield return new WaitForSeconds(duration);
        InputSystem.ResetHaptics();
    }

    private void OnDestroy()
    {
        InputSystem.ResetHaptics();
    }

    public void takeDamage()
    {
        GameManager.Instance.score += points;
        GameObject go =Instantiate(brokenEnemy, gameObject.transform.position, gameObject.transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(-go.transform.forward * 4000);
        Destroy(gameObject);
    }
}
