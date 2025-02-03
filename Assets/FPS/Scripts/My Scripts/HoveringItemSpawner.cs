using System.Collections.Generic;
using UnityEngine;

namespace AA0000
{
    public class HoveringItemSpawner : MonoBehaviour
    {
        public int numberOfHoveringItems = 3;
        public List<GameObject> hoveringItemGameObjects;
        public List<HoveringItem> hoveringItems;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            //HoveringItem hoveringItem = new HoveringItem();
            //HoveringItem hoveringItem = GetComponent<HoveringItem>();


        
            
            GameObject hoveringObject = new GameObject();
            hoveringObject.AddComponent<HoveringItem>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
