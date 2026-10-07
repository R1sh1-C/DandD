using UnityEngine;

public class EnemyController : MonoBehaviour, IDamageable
{

    [SerializeField] movementConfig movementConfig;
    [SerializeField] float MaxHealth;
    public GameObject dropsItem;
    public Transform target;

    private Rigidbody2D rb;
    private enemyMovement enemyMovement;
    private enemyAnimateController enemyAnimateController;
    private enemyHealth health;
    private Animator animator;

    private bool hit;   




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        enemyMovement = new enemyMovement(transform, rb, movementConfig);

        enemyAnimateController = new enemyAnimateController();
        enemyAnimateController.setAnimator(animator);

        health = new enemyHealth(MaxHealth);

    }

    private void OnEnable() => health.onDied += HandleDeath;

    private void OnDisable() => health.onDied -= HandleDeath;


    // Update is called once per frame
    void Update()
    {

        if(!hit)
        {
            enemyMovement.onUpdate(target);
            enemyAnimateController.onUpdate(enemyMovement.isMoving, enemyMovement.moveDirection);
        }
        
    }

    void FixedUpdate()
    {
        if(!hit)
        {
            enemyMovement.onFixedUpdate();
        }
    }

    public void TakeDamage (int damage, Vector2 knockback)
    {
        hit = true;
        health.damage(damage);
        rb.linearVelocity = knockback * 2f;
        enemyAnimateController.onHit(hit);
        Debug.Log("hit");
        
    }

    public void endHit() => hit = false;

    private void HandleDeath()
    {
        Instantiate(dropsItem, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
