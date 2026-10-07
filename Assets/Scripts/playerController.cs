
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;

    private float speed;
    private Rigidbody2D rb;
    public bool isSprinting {get; private set;}
    public bool isAttacking {get; private set;}
    public bool isRight {get; private set;}  = true;

    public bool finalAttack = false;
    public bool nextAttack {get; private set;}  = false;
    public bool isMoving => moveInput.SqrMagnitude() > 0.01f;

    public Vector2 moveInput {get; private set;}

    private AttackController atkController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atkController = GetComponent<AttackController>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (isAttacking)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        } 


        rb.linearVelocity = moveInput * speed;
    }

    private void facingDirection()
    {
        if (moveInput.x > 0f && !isRight)
        {
            isRight = !(isRight);
        } else if (moveInput.x < 0f && isRight)
        {
            isRight = !(isRight);
        }
    }

    public void Sprint(InputAction.CallbackContext context)
    {   
        
        if(context.performed)
        {
            speed = sprintSpeed;
            isSprinting = true;
        } else if (context.canceled)
        {
            speed = walkSpeed;
            isSprinting = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {

        moveInput = context.ReadValue<Vector2>();
        facingDirection();
    }

    public void onAttack(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;

        if (!isAttacking)
        {
            isAttacking = true;
        }

        else if (!finalAttack)
        {
            nextAttack = true;
        }
    }

    public void attackHit()
    {
        atkController.attack();
        Debug.Log("attack");
    }

    public void endAttack()
    {
        if (finalAttack)
        {
            nextAttack = false;
            finalAttack = false;
        }
        if (!nextAttack)
        {
            isAttacking = false;
        }
        
    }
}
