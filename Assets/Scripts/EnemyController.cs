using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float worldLimtmin;
    [SerializeField] private float worldLimtmax;



    private Raycast ray;
    private Stats stats;
    private CharacterAnimations characterAnimations;
    public bool isJumping;
    public bool isFacingRight;
    public bool isGrounded;

    private float move;
    private Rigidbody2D rb;
    private GameObject PlayerTarget;
    [SerializeField] private float jumpspeed;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float attackDistance = 2f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    private float JumpTimer = 0f;
    private float AttackTimer = 0f;
    [SerializeField] private float jumpcooldown = 4;
    [SerializeField] private float attackCooldown = 4;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    public GameObject leftTarget;
    public GameObject rightTarget;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        characterAnimations = GetComponent<CharacterAnimations>();
        ray = GetComponent<Raycast>();
        stats = GetComponent<Stats>();
        Flip();
    }

    private void Update()
    {
        if (!GameManager.INSTANCE.isGameStarted) return;
        if (stats.currentHealth < 1) return;

        AILogic();
        GroundCheck();

    }

    private void AILogic()
    {
        if (worldLimtmin < transform.position.x && worldLimtmax > transform.position.x) {

            leftTarget = ray.LookLeft();
            rightTarget = ray.LookRight();

            if (ray.LookRight().tag == "Player") {
                PlayerTarget = ray.LookRight();

            

                float distance = Vector3.Distance(transform.position, ray.LookRight().transform.position);

                if(!isFacingRight) {
                    isFacingRight = true;
                    Flip();
                }

                Debug.Log("Right");

                if (distance < attackDistance) {

                    AttackTimer += Time.deltaTime;
                    if (AttackTimer > attackCooldown) {
                        Attack();


                        Stats playerStats = ray.LookRight().GetComponent<Stats>();
                        GameManager.uIManager.TakeDamage(UIManager.CharacterType.Player1, playerStats);

                        AttackTimer = 0;
                    }
                }
                else {

                    transform.position = Vector2.MoveTowards(transform.position, ray.LookRight().transform.position, movementSpeed * Time.deltaTime);
                    characterAnimations.states = CharacterAnimations.States.Walk;

                }
            }
            else if (ray.LookLeft().tag == "Player") {
                PlayerTarget = ray.LookLeft();

                float distance = Vector3.Distance(transform.position, ray.LookLeft().transform.position);

                if (isFacingRight) {
                    isFacingRight = false;
                    Flip();
                }

                isFacingRight = false;

                Debug.Log("Left");
                if (distance < attackDistance) {

                    AttackTimer += Time.deltaTime;
                    if (AttackTimer > attackCooldown) {
                        Attack();
                        Stats playerStats = ray.LookLeft().GetComponent<Stats>();
                        GameManager.uIManager.TakeDamage(UIManager.CharacterType.Player1, playerStats);
                        AttackTimer = 0;
                    }
                }
                else {

                    transform.position = Vector2.MoveTowards(transform.position, ray.LookLeft().transform.position, movementSpeed * Time.deltaTime);
                    characterAnimations.states = CharacterAnimations.States.Walk;
                }
            }
            else {

                isFacingRight = true;
                //     Flip();
            }

            if (isGrounded) {
                JumpTimer += Time.deltaTime;
                if (JumpTimer > jumpcooldown) {
                    Jump();
                    JumpTimer = 0;
                }
            }
        }

        else {

            //     Flip();
            isFacingRight = false;
            characterAnimations.states = CharacterAnimations.States.Idle;
        }
    }





    //private void FacingRight()
    //{
    //    isFacingRight = true;
    //    transform.Rotate(new Vector3(0, 0, 0));
    //}

    //private void FacingLeft()
    //{
    //    isFacingRight = false;
    //    transform.Rotate(new Vector3(0, 180, 0));
    //}

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Attack()
    {
        characterAnimations.Punch();
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        isJumping = true;
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckCollider.position, groundCheckRadius, groundLayer);
    }
}















