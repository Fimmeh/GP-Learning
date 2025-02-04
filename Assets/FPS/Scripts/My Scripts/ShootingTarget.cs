using UnityEngine;
using System.Collections;

namespace AG3953
{
    public class ShootingTarget : MonoBehaviour
    {
        [SerializeField] private Transform[] targetEndPoints;
        private Transform target;
        private int currentEndPointIndex = 0;
        public float speed = 1.0f;



        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }


        public void ActivateMovement()
        {
            target = targetEndPoints[0];
            StartMovement();
        }

        private void StartMovement()
        {
            StartCoroutine(MoveToTargets());
        }

        private IEnumerator MoveToTargets()
        {
            while (true)
            {
                // Move our position a step closer to the target.
                var step = speed * Time.deltaTime; // calculate distance to move
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);

                // Check if the position of the cube and sphere are approximately equal.
                if (Vector3.Distance(transform.position, target.position) < 0.001f)
                {
                    // Swap the position of the cylinder.
                    SwapEndPointTarget();
                }

                yield return null;
            }
        }

        void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex %= targetEndPoints.Length;
            target = targetEndPoints[currentEndPointIndex];
        }

        public void Activate()
        {
            Debug.Log("Activated");
        }
    }

}