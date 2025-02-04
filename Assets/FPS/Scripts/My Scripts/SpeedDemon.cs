using UnityEngine;

namespace AG3953
{
    public class SpeedDemon : MonoBehaviour
    {
        // SerializedField means that the variables are changable in inspector
        [SerializeField] private Transform[] targetEndPoints;
        [SerializeField] private float minSize = 0.5f; 
        [SerializeField] private float maxSize = 2f;  
        [SerializeField] private float minJumpForce = 5f; 
        [SerializeField] private float maxJumpForce = 15f;

        private Transform target;
        private int currentEndPointIndex = 0;
        public float speed = 3.0f;
        public Rigidbody rb;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            target = targetEndPoints[0];
        }

        // Update is called once per frame
        void Update()
        {
            // Move our position a step closer to the target.
            var step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // Check if the position of the cube and sphere are approximately equal.
            if (Vector3.Distance(transform.position, target.position) < 0.001f)
            {
                // Swap the position of the cylinder.
                SwapEndPointTarget();
                RandomSize();
                RandomJump();
            }
        }

        void SwapEndPointTarget()
        {
            currentEndPointIndex++;
            currentEndPointIndex %= targetEndPoints.Length;
            target = targetEndPoints[currentEndPointIndex];
        }

        public void RandomSize()
        {
            float randomSize = Random.Range(1f, 3f);
            transform.localScale = new Vector3(randomSize, randomSize, randomSize);
        }

        public void RandomJump()
        {
            float jumpForce = Random.Range(1f, 10f);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
