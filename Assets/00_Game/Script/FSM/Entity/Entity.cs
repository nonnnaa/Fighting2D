using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Transform collision check
    [Header("Transform colision check")]
    [SerializeField]
    protected Transform wallCheck;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;
    #endregion

    #region Direction
    public bool isFacingLeft { get; private set; }
    public float directionX { get; private set; } = 1;
    #endregion


    private RaycastHit2D[] hits = new RaycastHit2D[1];

    [SerializeField] 
    protected EntityData data;
    public Rigidbody2D rb { get; private set; }
    public Animator animator { get; private set; }

    public float dashTimer; //{  get; private set; }

    #region Unity Lifecycle Methods
    protected virtual void Awake()
    {
        dashTimer = 0;
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    protected virtual void Start()
    {
        directionX = 1;
    }
    protected virtual void FixedUpdate()
    {
        
    }
    protected virtual void Update()
    {
        dashTimer -= Time.deltaTime;
    }

    #endregion

    #region Function Update Variables
    public void SetVelocity(float _x, float _y)
    {
        rb.velocity = new Vector2(_x, _y);
    }
    public void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0, 180, 0);
        SetDirX();
    }
    public void SetDirX() => directionX = -directionX;
    public void ResetDashTimer() => dashTimer = data.dashCooldown;
    public void SetJumpCount(int number) => data.jumpCount = number;
    #endregion

    #region Gizmos
    protected virtual void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(groundCheck.position, data.groundCheckDistance);
        Gizmos.DrawLine(groundCheck.position,
        new Vector3(groundCheck.position.x, groundCheck.position.y - data.groundCheckDistance, groundCheck.position.z));

        Gizmos.DrawLine(wallCheck.position,
        new Vector3(wallCheck.position.x + data.wallCheckDistance * directionX, wallCheck.position.y, wallCheck.position.z));

        Gizmos.DrawLine(wallCheck.position,
        new Vector3(wallCheck.position.x + data.distanceToAttack * directionX, wallCheck.position.y, wallCheck.position.z));
    }
    //public bool isGrounded() => Physics2D.OverlapCircle(groundCheck.position, data.groundCheckDistance, groundMask);
    public bool isGrounded() => Physics2D.Raycast(groundCheck.position, transform.up * -1, data.groundCheckDistance, groundMask);
    public bool isTouchingWall() => Physics2D.Raycast(wallCheck.position, transform.right, data.wallCheckDistance, groundMask);

    //public bool isTouchingWall()
    //{
    //    int hitCount = Physics2D.RaycastNonAlloc(wallCheck.position, transform.right, hits, data.wallCheckDistance, groundMask);
    //    return hitCount > 0;
    //}
    #endregion
}
