using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;

namespace AG3953
{
	public class GoodSpectator : Character
	{
        public override void Cheer()
        {
            Debug.Log("WAY TO GO!");
            StartCoroutine(SmoothMove(transform.position, transform.position + new Vector3(0, 2, 0), 0.5f));
            StartCoroutine(ResetAfterAction());
        }

        public override void Boo()
        {
            Debug.Log("That wasn´t great but you´ll get it next time!");
            StartCoroutine(SmoothMove(transform.position, transform.position + new Vector3(0, 0, -2), 0.5f));
            StartCoroutine(ResetAfterAction());

            // The reason to use coroutines instead of calling directly for ResetPosition is to make sure the previous action happens.
            // Could call directly but would need to make sure that the previous action is done to avoid complication. Easier this way.
        }

        public override void Jump()
        {
            transform.position += new Vector3(0, 5, 0); // Make the character "Jump" upwards.
        }

        private IEnumerator ResetAfterAction()
        {

            yield return new WaitForSeconds(0.5f); // Make sure the character has reached the peak before calling the method from Character.


            ResetPosition(); // Resets the position.
        }

    } 
}
