using UnityEngine;
using System.Collections;

namespace AG3953
{
    public class ShootingTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] targetEndPoints;
        [SerializeField] private float speed = 1.0f;

        private Transform target;
        private int currentEndPointIndex = 0;
        private bool isMoving = false;

        // Public property to control speed safely
        public float Speed
        {
            get => speed;
            set => speed = Mathf.Max(0, value);
        }


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (targetEndPoints.Length > 0)
            {
                target = targetEndPoints[0];
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        // Starts movement if it is not already active and there are targets
        public void ActivateMovement()
        {
            if (targetEndPoints == null || targetEndPoints.Length == 0)
            {
                Debug.LogError("No target end points assigned to " + gameObject.name);
                return;
            }

            target = targetEndPoints[0]; // Set initial target
            StartMovement();
        }

        private IEnumerator MoveToTargets()
        {
            if (target == null) // Check before starting movement
            {
                Debug.LogError("Target is null in MoveToTargets on " + gameObject.name);
                yield break;
            }

            while (true)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

                if (Vector3.Distance(transform.position, target.position) < 0.001f)
                {
                    SwapEndPointTarget();
                }

                yield return null;
            }
        }

        private void SwapEndPointTarget()
        {
            // Move to the next target in the list, looping back to the start if needed
            currentEndPointIndex = (currentEndPointIndex + 1) % targetEndPoints.Length;
            target = targetEndPoints[currentEndPointIndex];
        }
        private void StartMovement()
        {
            StartCoroutine(MoveToTargets());
        }
        
           

        public void StopMovement()
        {
            // Stops movement if needed
            isMoving = false;
        }

        public void Activate()
        {
            Debug.Log("Activated");
        }
    }

}