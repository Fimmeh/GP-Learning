using UnityEngine;

public class WallRunning : MonoBehaviour
{
    public Transform cameraTransform; // Assign this in the Inspector
    private bool isTilting = false; // Track if the player is inside the trigger
    public bool isRunning = false;
    public float tiltAngle = 15f; // Adjust this for more or less tilt
    GameObject player = GameObject.FindWithTag("Player");
    [SerializeField] public Transform pointA;


    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform; // Auto-assign main camera if not set
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered - Tilting camera");
            isTilting = true;
            isRunning = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited - Resetting tilt");
            isTilting = false;
        }
    }

    void LateUpdate() // Ensures tilt is applied after movement updates
    {
        if (isTilting)
        {
            cameraTransform.localRotation = Quaternion.Euler(0, 0, tiltAngle);
        }
        else
        {
            cameraTransform.localRotation = Quaternion.Euler(0, 0, 0); // Reset to normal
        }
    }
    
    public void WallRunning()
    {
        if (isRunning && isTilting)
        {
            player.transform.position = pointA.position;
        }
    }

    public void Update()
    {
        WallRunning();
    }
}
