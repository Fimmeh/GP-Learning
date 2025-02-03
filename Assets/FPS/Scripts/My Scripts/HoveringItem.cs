using UnityEngine;

namespace AA0000
{
    public class HoveringItem : MonoBehaviour
    {
        public Rigidbody attachedRigidbody;
        public float hoveringForce = 100.0f;        
        public float hoveringDistance = 1.5f;
        public Transform hoveringTresholdPoint;
        public string groundTag = "Ground";

		private void Start()
		{
            print("I live!");
		}
		public void SetTresholdPointLocation()
        {         
            hoveringTresholdPoint.position = transform.position - new Vector3(0f, hoveringDistance, 0f);
        }

        public void BeginHover()
        {
            print("Adding force to hover");
            // TODO: Implement hovering with (upwards) force
        }


		private void OnTriggerStay(Collider other)
		{
            if (other.CompareTag(groundTag))
            { 
			    BeginHover();            
            }
		}

	}

}