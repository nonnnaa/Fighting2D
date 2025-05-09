using System.Collections;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Transform collision check
    [Header("Transform colision check")]
    [SerializeField]
    protected Transform wallCheck;
    [SerializeField]
    private Transform groundCheck;
    //[SerializeField]
    public Transform attackCheck;
    [SerializeField]
    private LayerMask groundMask;
    #endregion

    private EntityFX fx;

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
    public bool isKnockedBack {  get; private set; }
    public EntityData getData() => data;

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
        fx = GetComponentInChildren<EntityFX>();
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
        if (isKnockedBack) return;
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
        Gizmos.DrawWireSphere(attackCheck.position, data.attackCheckRadius);

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

    public virtual void Damage()
    {
        fx.StartCoroutine("OnHitFx");
        Debug.Log("Enemy get Damage");
        StartCoroutine("HitKnockBack");
    }

    protected virtual IEnumerator HitKnockBack()
    {
        Debug.Log("Start courotine");
        isKnockedBack = true;
        rb.velocity = new Vector2(data.knockBackDirection.x * -directionX, data.knockBackDirection.y);
        yield return new WaitForSeconds(data.knockBackDuration);
        isKnockedBack = false;
    }
}
