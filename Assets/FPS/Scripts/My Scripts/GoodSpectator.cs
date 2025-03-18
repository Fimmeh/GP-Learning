using UnityEngine;
using UnityEngine.TextCore.Text;

namespace AG3953
{
	public class GoodSpectator : Character
	{
        public override void Cheer()
        {
            base.Cheer();
            Debug.Log("WAY TO GO!");
        }
    } 
}
