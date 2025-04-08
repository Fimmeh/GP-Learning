using Unity.FPS.Gameplay;
using UnityEngine;

namespace AG3953
{
    public class WallRunning : MonoBehaviour
    {
        public CharacterController character;
        public Transform cameraTransform;
        public float tiltAngle = 15f;
        public GameObject player;

        private bool isTilting = false;
        public bool isRunning = false;

        private PlayerCharacterController movementScript;

        // Store original values to restore after wall running
        private float originalGravity;
        private float originalJumpForce;

        private float currentGravity;
        private float gravityTransitionSpeed = 0.2f; // Speed at which gravity returns to original value

        void Start()
        {
            player = GameObject.FindWithTag("Player");

            if (player != null)
            {
                character = player.GetComponent<CharacterController>();
                movementScript = player.GetComponent<PlayerCharacterController>();

                if (movementScript != null)
                {
                    originalGravity = movementScript.GravityDownForce;
                    originalJumpForce = movementScript.JumpForce;
                    currentGravity = originalGravity; // Initialize current gravity to original
                }
            }

            if (cameraTransform == null)
            {
                cameraTransform = Camera.main.transform;
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
                Debug.Log("Player exited - Resetting tilt and gravity");
                isTilting = false;
                isRunning = false;

                // Immediately reset gravity when exiting wall running
                if (movementScript != null)
                {
                    movementScript.GravityDownForce = originalGravity;
                    movementScript.JumpForce = originalJumpForce;
                }
            }
        }

        void LateUpdate()
        {
            if (isTilting)
            {
                cameraTransform.localRotation = Quaternion.Euler(0, 0, tiltAngle);
            }
            else
            {
                cameraTransform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }

        public void ZeroGravity()
        {
            if (isRunning && isTilting && movementScript != null)
            {
                // Set gravity to 0 when wall running, immediately set jump force to 1
                movementScript.GravityDownForce = 0f;
                movementScript.JumpForce = 1f;
            }
            else if (!isRunning && currentGravity != originalGravity)
            {
                // Smoothly transition back to the original gravity
                currentGravity = Mathf.Lerp(currentGravity, originalGravity, gravityTransitionSpeed * Time.deltaTime);
                movementScript.GravityDownForce = currentGravity;
            }
        }

        void Update()
        {
            ZeroGravity();
        }
    } 
}
