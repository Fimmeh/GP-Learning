using UnityEngine;

namespace AG3953
{
    public abstract class Character : MonoBehaviour, ISkills
    {

        public virtual void Cheer()
        {
            Debug.Log("Yippee, way to go!");
        }

        public virtual void Boo()
        {
            Debug.Log("You suck!");
        }
    }

}