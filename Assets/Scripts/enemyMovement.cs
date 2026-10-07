using UnityEngine;
using UnityEngine.EventSystems;


[System.Serializable]
public struct movementConfig
{
    public float speed;
    public float enemyRange;
}
public class enemyMovement
{
    
    public Vector2 moveDirection {get; private set;}
    bool targetinRng = false;
    public bool isMoving {get; private set;}

    private Transform transform;
    private movementConfig movementConfig;
    private Rigidbody2D rb;

    
    public enemyMovement(Transform enemy, Rigidbody2D rb, movementConfig movementConfig)
    {
        transform = enemy;
        this.rb = rb;
        this.movementConfig = movementConfig;

    }

    // Update is called once per frame
    public void onUpdate(Transform target)
    {
        Vector3 distanceVector = target.position - transform.position;
        if ((distanceVector).sqrMagnitude < movementConfig.enemyRange && (distanceVector).sqrMagnitude > 0.5f)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction; 
            targetinRng = true;
        } 
            else
        {
            targetinRng = false;
        
        }
        
    }

    public void onFixedUpdate()
    {
        if (targetinRng)
        {
            rb.linearVelocity = moveDirection * movementConfig.speed;
            isMoving = true;
        } else
        {
            rb.linearVelocity = Vector2.zero;
            isMoving = false;
            
        }

        
    }
}

  
