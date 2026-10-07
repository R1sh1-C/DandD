using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] public List<AttackProfile> Attacks;
    [SerializeField] private LayerMask targetLayer;

    private int currentAttack = 0;

    private playerController playerController;
    private bool isRight = true;
    
    private bool disHit = true;
    // Update is called once per frame

    void Start() => playerController = GetComponent<playerController>();
    public Vector2 calcPoint()
    {
        float xOffset = isRight ? Attacks[currentAttack].offset.x : -Attacks[currentAttack].offset.x;
        return (Vector2)transform.position + new Vector2(xOffset, Attacks[currentAttack].offset.y);
    }

    public void attack()
    {
        if (playerController.nextAttack)
        {
            currentAttack = Mathf.Min(currentAttack + 1, Attacks.Count - 1);
        }
        
        isRight = playerController.isRight;
        Vector2 attackPoint = calcPoint();
        
        Collider2D[] enemies = Physics2D.OverlapBoxAll(attackPoint, Attacks[currentAttack].size, 0f, targetLayer);

        foreach (Collider2D enemyObject in enemies)
        {
            IDamageable target = enemyObject.GetComponentInParent<IDamageable>();
            Vector2 knockbackDir = isRight ? Attacks[currentAttack].knockback : new Vector2(-Attacks[currentAttack].knockback.x, Attacks[currentAttack].knockback.y);
            target.TakeDamage(Attacks[currentAttack].damage, knockbackDir);
        }


        if (currentAttack == Attacks.Count - 1)
        {
            playerController.finalAttack = true;
            currentAttack = 0;
        }
    }

    public void showhit() => disHit = !disHit;
    private void OnDrawGizmosSelected()
    {
        if (Attacks[currentAttack] == null || disHit) return;

        Gizmos.color = Color.red;
        Vector2 centre = calcPoint();
        Gizmos.DrawWireCube(centre, Attacks[currentAttack].size);
    }
}