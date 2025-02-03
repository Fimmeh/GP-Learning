using Unity.FPS.Game;
using UnityEngine;

namespace AG3953
{
    /*public class DamagableShootingTarget : Damageable
    {
        public Renderer objectRenderer;
        public Color swapColor = Color.red;
        public Color originalColor;
        public bool colorSwapped = false;


        // Start is called once before the first execution of Update after the MonoBehaviour is created
        private void Start()
        {
            objectRenderer = GetComponent<Renderer>();
            originalColor = objectRenderer.material.color;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public override void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource)
        {
            base.InflictDamage(damage, isExplosionDamage, damageSource);

            SwapColor();
         
        }
        
        public void SwapColor()
        {
            if (!colorSwapped )
            {
                objectRenderer.material.color = swapColor;
            }
            else
            {
                objectRenderer.material.color = originalColor;
            }
            colorSwapped = !colorSwapped;
        }

        private void OnDisable()
        {
            objectRenderer.material.color = originalColor;
        }
    } */

}