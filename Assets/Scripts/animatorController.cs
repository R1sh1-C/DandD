using UnityEngine;

public class animatorController : MonoBehaviour
{

    private Animator animator;
    private playerController playerController;
    private float lastInputX = 1.0f;
    private float lastInputY = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<playerController>();
    }

    void Update()
    {
        animator.SetBool("isWalking", playerController.isMoving);
        animator.SetBool("isSprinting", playerController.isSprinting);
        animator.SetBool("isAttacking", playerController.isAttacking);
        animator.SetFloat("isRight", playerController.isRight ? 1 : 0);
        animator.SetBool("nextAttack", playerController.nextAttack);

        if(playerController.moveInput.x != 0)
        {
            lastInputX = playerController.moveInput.x;
            lastInputY = playerController.moveInput.y;
        }
        

        if(playerController.isMoving == false)
        {
            animator.SetFloat("lastInputX", lastInputX);
            animator.SetFloat("lastInputY", lastInputY);
        }
        else
        {
            if(playerController.moveInput.x != 0)
            {
                animator.SetFloat("InputX", playerController.moveInput.x);
            }
            animator.SetFloat("InputY", playerController.moveInput.y);
        }

    }


    public void AttackAnimEnd() => playerController.endAttack();
}
