using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damageAmount, Vector2 knockbackForce);
}