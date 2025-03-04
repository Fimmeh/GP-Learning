using UnityEngine;

namespace AG3953
{
    public class RecapThingFinder : MonoBehaviour
    {
        [SerializeField] private GameObject recapThingy;
         private GameObject parentThing;
         private GameObject randomThing;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            parentThing = this.transform.parent.gameObject;
            randomThing = GameObject.Find("SpeedDemon");
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
