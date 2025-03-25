using UnityEngine;
using UnityEngine.TextCore.Text;

namespace AG3953
{
	public class BadSpectator : Character
	{
        public Vector3 startPosition;

        public void Start()
        {
            startPosition = transform.position;
        }

        public override void Cheer()
        {
            Debug.Log("Okay, I guess");
        }

        public override void Boo()
        {
            Debug.Log("Kill yourself");
            transform.position = startPosition;
        }

        public new void Neutral()
        {
            base.Neutral();
        }

        public override void Jump()
        {
            transform.position = transform.position + new Vector3(0, 1, 0);
        }
    } 
}
