using AG3953;
using Unity.FPS.Game;
using UnityEngine;

public class DamagableShootingTarget : Damageable
{
    public Renderer objectRenderer;
    public Color swapColor = Color.red;
    public Color originalColor;
    public bool colorSwapped = false;

    private void Start()
    {
        if (objectRenderer == null)
        {
            objectRenderer = GetComponent<Renderer>();
        }

        originalColor = objectRenderer.material.color;
    }

    public override void InflictDamage(float damage, bool isExplosionDamage, GameObject damageSource)
    {
        base.InflictDamage(damage, isExplosionDamage, damageSource);
        SwapColor();

        ShootingRangeGameManager.Instance?.RegisterHit(); // <<== New line
    }

    public void SwapColor()
    {
        if (!colorSwapped)
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
}