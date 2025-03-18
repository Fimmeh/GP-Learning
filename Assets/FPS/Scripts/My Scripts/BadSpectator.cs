using UnityEngine;
using UnityEngine.TextCore.Text;

namespace AG3953
{
	public class BadSpectator : Character
	{
        public override void Cheer()
        {
            base.Cheer();
            Debug.Log("Okay, I guess");
        }
    } 
}
