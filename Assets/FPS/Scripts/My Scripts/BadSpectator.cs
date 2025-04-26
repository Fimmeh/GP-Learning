using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections;

namespace AG3953
{
	public class BadSpectator : Character
	{
        public override void Cheer()
        {
            Debug.Log("Okay, I guess");
            StartCoroutine(SmoothMove(transform.position, transform.position + new Vector3(0, 0.5f, 0), 0.5f));
            StartCoroutine(ResetAfterAction());
        }

        public override void Boo()
        {
            Debug.Log("Kill yourself");
            StartCoroutine(SmoothMove(transform.position, transform.position + new Vector3(0, -1, 0), 0.5f));
            StartCoroutine(ResetAfterAction());


        }

        public override void Jump()
        {
            transform.position += new Vector3(0, 2, 0); 
        }

        private IEnumerator ResetAfterAction()
        {

            yield return new WaitForSeconds(0.5f);


            ResetPosition();
        }

    } 
}
