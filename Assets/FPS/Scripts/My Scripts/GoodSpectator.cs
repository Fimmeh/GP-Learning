using UnityEngine;
using UnityEngine.TextCore.Text;

namespace AG3953
{
	public class GoodSpectator : Character
	{
        public Vector3 startPosition;

        public void Start()
        {
            startPosition = transform.position;
        }

        public override void Cheer()
        {           
            Debug.Log("WAY TO GO!");
        }

        public override void Boo()
        {
            Debug.Log("That wasn´t great but you´ll get it next time!");
            transform.position = startPosition;
        }

        public override void Neutral()
        {
            base.Neutral();
        }

        public override void Jump()
        {
            transform.position = transform.position + new Vector3(0, 2, 0);

        }
    } 
}
