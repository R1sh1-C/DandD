using UnityEngine;

public class enemyAnimateController
{

    private EnemyController enemyController;
    private Animator animator;

    public void setAnimator(Animator animator) => this.animator = animator;
    public void onUpdate(bool isMoving, Vector2 moveDirection)
    {
        animator.SetBool("isMoving", isMoving);

        if (isMoving)
        {
            animator.SetFloat("XDir", moveDirection.x);
            animator.SetFloat("YDir", moveDirection.y);
        }

    }

    public void onHit(bool hitState) => animator.SetTrigger("hit");


}
