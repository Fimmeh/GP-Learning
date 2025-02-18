using UnityEngine;

namespace AG3953
{
    public class ThingFinder : MonoBehaviour
    {
        [SerializeField] private GameObject targetForDragNDropWay;
        [SerializeField] private GameObject targetForNameFinding;
        [SerializeField] private GameObject targetForTagFinding;
        [SerializeField] private GameObject targetForTypeFinding;
        [SerializeField] private ThingToFind targetForGetComponentFinding;
        [SerializeField] private ThingToFind targetForGetComponentInChildrenFinding;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            targetForNameFinding = GameObject.Find("SpeedDemon");

            targetForTagFinding = GameObject.FindGameObjectWithTag("Target");

            targetForTypeFinding = GameObject.FindFirstObjectByType<ThingToFind>().gameObject;

            targetForGetComponentFinding = GetComponent<ThingToFind>();

            targetForGetComponentInChildrenFinding = GetComponentInChildren<ThingToFind>();

        }

        // Update is called once per frame
        void Update()
        {

        }
    } 
}
