using UnityEngine;

namespace AG3953
{
    public class ActivateShootingRange : MonoBehaviour
    {

        public GameObject []popUpTargets;
        

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void Start()
        {
            
        }

        // Update is called once per frame
        public void Update()
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                ActivateAllObjects();
            }
        }

        public void ActivateAllObjects()
        {
            foreach (var obj in popUpTargets)
            {
                if (obj != null)
                {
                    var objectsScript = obj.GetComponent<ShootingTarget>();
                    if (objectsScript != null)
                    {
                        objectsScript.ActivateMovement();
                    }
                    else
                    {
                        Debug.LogWarning("Nothing attached");
                    }
                }
                else
                {
                    Debug.LogWarning("Object in array is null");
                }
            }
        }
    } 
}
