using System;
using UnityEngine;

namespace AG3953
{
    public abstract class Character : MonoBehaviour, ISkills
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                Cheer();
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.V))
            {
                Boo();               
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                Neutral();
            }
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
    }
}