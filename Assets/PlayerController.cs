using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float worldLimtmin;
    [SerializeField] private float worldLimtmax;

    [SerializeField] private float speed;
    [SerializeField] private float jumpspeed;

    private Stats stats;
    private Raycast ray;
    private CharacterAnimations characterAnimations;
    private Rigidbody2D rb;

    private float move; 
    public bool isJumping;
    public bool isGrounded;
    public bool IsFacingRight;

    [SerializeField] private bool isFacingRight;

    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;


    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        characterAnimations = GetComponent<CharacterAnimations>();
        stats= GetComponent<Stats>();
        ray= GetComponent<Raycast>();
    }

    // Update is called once per frame
    void Update() {

       // Physics2D.IgnoreLayerCollision(6, 7);

        GroundCheck();
        move = Input.GetAxis("Horizontal");


        rb.velocity = new Vector2(speed * move, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {

            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        }

        if (Input.GetKeyDown(KeyCode.Z)) {
            Attack();

        }

       // Physics2D.IgnoreLayerCollision(6, 7);

        if (move >= 0.1f || move <= -0.1f) {

            characterAnimations.states = CharacterAnimations.States.Walk;


            if (!isFacingRight && move > 0f) {
                Flip();
            }
            else if (isFacingRight && move < 0f) {
                Flip();
            }
        }
        else { characterAnimations.states = CharacterAnimations.States.Idle; }

        void GroundCheck() {
            isGrounded = Physics2D.OverlapCircle(groundCheckCollider.position, groundCheckRadius, groundLayer);
        }
    }

    private void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    private void Attack() {
        characterAnimations.Punch();

        if (ray.LookRight() == null) return;

        if (IsFacingRight)
        {

            float distance = Vector3.Distance(transform.position, ray.LookRight().transform.position);
        }
          

        else
        {

            float distance = Vector3.Distance(transform.position, ray.LookLeft().transform.position);
        


        if (distance < 2f) {
            ray.LookRight().GetComponent<Stats>().TakeDamage(stats.damage);
            }
               
        }
    }


    }

    












