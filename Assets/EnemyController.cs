using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float worldLimtmin;
    [SerializeField] private float worldLimtmax;

    private Raycast ray;
    private Stats stats;
    private CharacterAnimations characterAnimations;
    public bool IsJumping;
    public bool IsFacingRight;
    public bool IsFacingLeft;
    public bool isGrounded;
    private Rigidbody2D rb;
    private GameObject PlayerTarget;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    private float JumpTimer = 0f;
    [SerializeField] private float jumpcooldown;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        characterAnimations = GetComponent<CharacterAnimations>();
        ray = GetComponent<Raycast>();
        stats = GetComponent<Stats>();
        IsJumping = true;
        IsFacingRight = true;
        IsFacingLeft = true;

    }

    private void Update()
    {
        AILogic();
        GroundCheck();

    }

    private void AILogic()
    {
        if (worldLimtmin < transform.position.x && worldLimtmax > transform.position.x)
        {
            if (IsFacingRight)
            {


                if (ray.LookRight().tag == "Player")
                {

                    PlayerTarget = ray.LookRight();

                    float distance = Vector3.Distance(transform.position, ray.LookRight().transform.position);

                    Debug.Log("Right");
                    FacingRight();
                    if (distance < attackDistance)
                    {
                        Attack(PlayerTarget);
                    }
                    else
                    {

                        transform.position = Vector2.MoveTowards(transform.position, ray.LookRight().transform.position, movementSpeed * Time.deltaTime);
                        characterAnimations.states = CharacterAnimations.States.Walk;

                    }
                }
                else
                {

                    FacingLeft();
                    characterAnimations.states = CharacterAnimations.States.Idle;
                }
            }
            else
            {
                if (ray.LookLeft().tag == "Player")
                {
                    PlayerTarget = ray.LookLeft();


                    float distance = Vector3.Distance(transform.position, ray.LookLeft().transform.position);

                    Debug.Log("Left");
                    FacingLeft();
                    if (distance < attackDistance)
                    {

                        Attack(PlayerTarget);

                    }
                    else
                    {

                        transform.position = Vector2.MoveTowards(transform.position, ray.LookLeft().transform.position, movementSpeed * Time.deltaTime);
                        characterAnimations.states = CharacterAnimations.States.Walk;

                    }
                }
                else
                {

                    FacingRight();

                }
                JumpTimer += Time.deltaTime;
                if (JumpTimer > jumpcooldown)
                {
                    Jump();
                    JumpTimer = 0;
                }

                if (IsFacingRight)
                {
                    FacingLeft();
                }
                if (ray.LookLeft().tag == "Player")
                {
                    FacingLeft();
                    IsFacingLeft = false;
                    IsFacingRight = true;


                    if (IsFacingLeft)
                    {
                        FacingRight();
                    }
                    if (ray.LookLeft().tag == "Player")
                    {
                        FacingRight();
                        IsFacingLeft = false;
                        IsFacingRight = true;






                    }
                }
        }

       


    }




}

    private void FacingRight()
    {
        IsFacingRight = true;

        transform.Rotate(new Vector3(0, 0, 0));

    }

    private void Attack(GameObject target)
    {
        characterAnimations.Punch();
        target.GetComponent<Stats>().TakeDamage(stats.damage);
    }

    private void FacingLeft()
    {
        transform.Rotate(new Vector3(0, 0, 0));
        IsFacingRight = false;
    }

    private void Jump()
    {


        rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        IsJumping = true;
    }
        void GroundCheck()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheckCollider.position, groundCheckRadius, groundLayer);
        }
    }















