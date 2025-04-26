using System;
using UnityEngine;
using System.Collections;

namespace AG3953
{
    public abstract class Character : MonoBehaviour, ISkills
    {
        private Vector3 startPosition;

        public Vector3 StartPosition
        {
            get { return startPosition; }
            private set { startPosition = value; } // Using get/set to make the startPosition encapsulated.
        }

        public void Start()
        {
            startPosition = transform.position; // Sets the intial positions inside the character class already for the spectators.
        }

        public virtual void Cheer()
        {
            
        }

        public virtual void Boo()
        {
            
        }

        public virtual void Neutral()
        {
            Debug.Log("Neutral noices");
        }

        public abstract void Jump();

        protected IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float duration)
        {
            float elapsed = 0f;
            while (elapsed < duration)
            {
                transform.position = Vector3.Lerp(startPos, endPos, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }
            transform.position = endPos; // Make sure we land exactly at the end

            
        }

        public virtual void ResetPosition()
        {
            StartCoroutine(SmoothMove(transform.position, startPosition, 1f)); // Resets the position of the spectators.
        }
    }
}