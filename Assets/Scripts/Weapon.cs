using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class Weapon : MonoBehaviour
{
    // Public variables
    [Header("Weapon Settings")]
    [Range(1, 100)]
    public float range = 10f;
    [Range(1, 100)]
    public float weaponDamage = 15;
    [Range(0, 10)]
    public float fireRate = 1.0f;

    [Header("Weapon Effects")]
    public AudioClip fireAudio;
    public GameObject laserPrefab;
    public GameObject firePosition;

    [Header("Haptic Feedback On Fire")]
    public bool hapticFeedbackOn = true;
    [Range(0, 1)]
    public float leftHapticStrength = .25f;
    [Range(0, 1)]
    public float rightHapticStrength = .25f;
    [Range(0, 5)]
    public float durationInSeconds = .2f;

    // Private variables
    private StarterAssetsInputs sai;
    private RaycastHit hit;
    private AudioSource audioSource;
    private Camera playerCamera;
    private float nextFireTime;

    private void Awake()
    {
        // When the scene loads connect to started assets
        sai = GetComponent<StarterAssetsInputs>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Sets player camera to the main camera in the scene
        playerCamera = Camera.main;

        // Connects to the audio source
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Check to see if the shoot button is pressed
        if (sai.shoot)
        {
            Fire();
        }
    }

    void Fire()
    {
        // Tests to see if we can fire yet
        if (Time.time > nextFireTime)
        {

            // Play the animation
            gameObject.GetComponent<Animator>().SetTrigger("shoot");


            // Looks outward from the camera's position
            Vector3 fwd = playerCamera.transform.TransformDirection(Vector3.forward);

            // Create a laser at the end of the gun
            GameObject newLaser = Instantiate(laserPrefab,firePosition.transform.position, Quaternion.identity);

            // Looks to see if we hit anything with a RB within the range
            if (Physics.Raycast(playerCamera.transform.position, fwd, out hit, range))
            {
                // Draw the laser from the gun to the object
                newLaser.GetComponent<Laser>().drawLaser(hit.point);

                // Checks to see if that thing is tagged as an enemy
                if (hit.transform.tag == "Enemy")
                {
                    // Calls the take damage within the enemy
                    // hit.transform.root.gameObject.GetComponent<Enemy>().takeDamage();
                    hit.transform.gameObject.GetComponent<Enemy>().takeDamage();
                }
            }
            else
            {
                // Find the center of the screen
                Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                // Calculate the end point based off the range
                Vector3 endPoint = ray.GetPoint(range);
                // Draw the laser
                newLaser.GetComponent<Laser>().drawLaser(endPoint);
            }
            // Destroy the laser
            Destroy(newLaser, .1f);

            // If haptic feedback is on
            if (hapticFeedbackOn && Gamepad.current != null)
            {
                // Vibrate controller
                StartCoroutine(PlayHaptics());
            }

            // Play the fire sound
            audioSource.PlayOneShot(fireAudio);

            // Figure out the next time we can fire
            nextFireTime = Time.time + fireRate;
        }
    }

    IEnumerator PlayHaptics()
    {
        // Starts the vibration
        Gamepad.current.SetMotorSpeeds(leftHapticStrength, rightHapticStrength);

        // Waits for time to pass
        yield return new WaitForSeconds(durationInSeconds);

        // Turns off the haptics
        InputSystem.ResetHaptics();
    }

    private void OnDestroy()
    {
        // Makes sure the haptics are turned off before the scene ends
        InputSystem.ResetHaptics();
    }
}