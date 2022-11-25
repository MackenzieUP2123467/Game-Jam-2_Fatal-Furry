
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Players : MonoBehaviour
{
    public LayerMask enemyLayer;
    public Transform attckPoint;
    public float attackRange =0.5f;
    private int attackDamage;
    public float attackRate = 2f;
    


    private int Direction;
    


    [SerializeField] private bool IsfacingRight;
    [SerializeField] private LayerMask PlatformLayerMask;
    [SerializeField] private float JumpHeight;
    [SerializeField] private float MovmentSpeed;

    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private BoxCollider2D BC;

    [SerializeField] private float AttackCoolDown;
    private float timeBtweenAttack;



    // Start is called before the first frame update
    void Start()
    {
       
        
        Direction = 1;
       
       Rigidbody2D RB2 = transform.GetComponent<Rigidbody2D>();
       BoxCollider2D BC2 = transform.GetComponent<BoxCollider2D>();
        timeBtweenAttack = AttackCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
       

       
            
           
        
    }
    public void Movement(int player)
    {
    if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) && player == 1 || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) && player == 2)
        {
            RB.velocity = new Vector2(0, RB.velocity.y);
            animator.SetBool("IsWalking", false);
        }
        else if (Input.GetKey(KeyCode.D) && player == 1 || Input.GetKey(KeyCode.RightArrow) && player == 2)
        {
            Direction = 1;
            RB.velocity = new Vector2 (Direction * MovmentSpeed, RB.velocity.y);
            animator.SetBool("IsWalking", true);
            Debug.Log(Direction);
            
        }
        else if (Input.GetKey(KeyCode.A) && player == 1 || Input.GetKey(KeyCode.LeftArrow) && player == 2)
        {
            Direction = -1;
            RB.velocity = new Vector2(Direction * MovmentSpeed, RB.velocity.y);
            animator.SetBool("IsWalking", true);
            
        }
        else
        {
            RB.velocity = new Vector2(0, RB.velocity.y);
            animator.SetBool("IsWalking", false);
        }
       
    }

    public void  Flip()
    {
           
        if (IsfacingRight && Direction < 0f || !IsfacingRight && Direction > 0f)
        {
            
            IsfacingRight = !IsfacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            
        }
  
    }

    public void Jump() 
    {
        
            RB.velocity = new Vector2(RB.velocity.x, JumpHeight);
            animator.SetTrigger("Jump");
            Debug.Log("IsJumping");
            Debug.Log(IsfacingRight);

    }

    public bool IsGrounded()
    {
       RaycastHit2D raycasthit2d = Physics2D.BoxCast(BC.bounds.center, BC.bounds.size, 0f, Vector2.down, .1f, PlatformLayerMask);
        Debug.Log(raycasthit2d.collider);
        return raycasthit2d.collider != null;
    }
    public void Attack()
    {

        if (IsGrounded())
        {
            animator.SetTrigger("Attack");
            attackDamage = 12;
            attackRange = 0.6f;
        }
        if (!IsGrounded())
        {
            animator.SetTrigger("JumpKick");
            attackDamage = 15;
            attackRange = 1.4f;
        }
              
         Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attckPoint.position, attackRange, enemyLayer);
        foreach (Collider2D Enemy in hitEnemies)
        {
            Debug.Log("epic");
            Enemy.GetComponent<Health>().TakeDamage(attackDamage);
        
         //  Enemy.GetComponent<Player_2>().GetComponent<Rigidbody2D>().AddForce(new Vector2(Direction * 60f, 0), ForceMode2D.Impulse);
            //Enemy.GetComponent<Player_1>().GetComponent<Rigidbody2D>().AddForce(new Vector2(Direction * 60f, 0), ForceMode2D.Impulse);




        }

       
    }
    void OnDrawGizmosSelected()
    {
        if (attckPoint == null)
        {
            return;
        }


        Gizmos.DrawWireSphere(attckPoint.position, attackRange);
    }

}
