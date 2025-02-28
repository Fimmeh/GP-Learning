using UnityEngine;

namespace AG3953
{
    public class ActivateShootingRange : MonoBehaviour
    {

        [SerializeField] GameObject []popUpTargets;
        

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
            if (popUpTargets == null || popUpTargets.Length == 0)
            {
                Debug.LogWarning("No targets assigned to ActivateShootingRange");
                return;
            }

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
                        Debug.LogWarning($"Object '{obj.name}' is missing the ShootingTarget script");
                    }
                }
                else
                {
                    Debug.LogWarning("Object in popUpTargets array is null");
                }
            }
        }
    } 
}
