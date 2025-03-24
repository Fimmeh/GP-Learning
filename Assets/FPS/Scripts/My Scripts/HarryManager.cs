using AG3953;
using UnityEngine;

namespace AG3953
{
    public class HarryManager : MonoBehaviour
    {
        private Weapom currentWeapon;
        private Weapom magicMissile;
        private Weapom gat;

        public void Start()
        {
            magicMissile = new MagicMissile();
            gat = new Gat();

            currentWeapon = magicMissile;
            Debug.Log("Wand equipped");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (currentWeapon != null)
                {
                    Debug.Log("Attempting to attack");
                    currentWeapon.Attack();
                }
            }
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                currentWeapon = magicMissile;
                Debug.Log("Changed to wand");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                currentWeapon = gat;
                Debug.Log("Changed to glock18");
            }
        }
    }
}