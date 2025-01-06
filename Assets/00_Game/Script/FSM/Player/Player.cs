using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    #region Animation
    public Animator animator {  get; private set; } // Must have in Children
    public PlayerStateMachine playerStateMachine { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerGroundedState groundedState { get; private set; }
    public IdleState idleState { get; private set; }
    public RunState runState { get; private set; }
    public JumpState jumpState { get; private set; }
    public FallState fallState { get; private set; }
    public DashState dashState { get; private set; }
    public WallSlideState wallSlideState { get; private set; }
    #endregion

    #region Transform collision check
    [Header("Transform colision check")]
    [SerializeField]
    private Transform wallCheck;
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private LayerMask groundMask;
    #endregion

    [SerializeField]
    private PlayerData playerData;
    public PlayerInputHandler inputHandler { get; private set;}
    public Rigidbody2D rb { get; private set; }
    public bool isFacingLeft { get; private set; }
    public float directionX { get; private set; }
    public float dashTimer {  get; private set; }
    public int jumpCount {get; private set; }
    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine();
        // Parrent state
        airState = new PlayerAirState(this, playerStateMachine, playerData, E_CharactorState.Jump);
        groundedState = new PlayerGroundedState(this, playerStateMachine, playerData, E_CharactorState.Idle);

        // Sub state
        idleState = new IdleState(this, playerStateMachine, playerData, E_CharactorState.Idle);
        runState = new RunState(this, playerStateMachine,playerData, E_CharactorState.Run);
        jumpState = new JumpState(this, playerStateMachine, playerData, E_CharactorState.Jump);
        dashState = new DashState(this, playerStateMachine, playerData, E_CharactorState.Dash);
        wallSlideState = new WallSlideState(this, playerStateMachine, playerData, E_CharactorState.WallSlide); 

        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        
    }


    void Start()
    {
        playerStateMachine.InitState(idleState);
        directionX = 1;
        jumpCount = playerData.jumpCount;
    }
    private void FixedUpdate()
    {
        playerStateMachine.currentState.UpdatePhysics();
    }

    void Update()
    {
        dashTimer -= Time.deltaTime;
        playerStateMachine.currentState.UpdateLogics();
        Debug.Log(isTouchingWall());
    }


    #region Function Update Variable
    public void SetVelocity(float _x, float _y)
    {
        rb.velocity = new Vector2(_x, _y);
    }
    public void Flip()
    {
        isFacingLeft = !isFacingLeft;
        transform.Rotate(0, 180, 0);
        directionX *= -1;
    }
    public void ResetDashTimer() => dashTimer = playerData.dashCooldown;
    public void SetJumpCount(int number) => jumpCount = number;
    #endregion


    #region Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, playerData.groundCheckDistance);
        Gizmos.DrawLine(wallCheck.position,
            new Vector3(wallCheck.position.x + playerData.wallCheckDistance * directionX, wallCheck.position.y, wallCheck.position.z));
    }
    public bool isGrounded() => Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckDistance, groundMask);

    public bool isTouchingWall() => Physics2D.Raycast(wallCheck.position, transform.right, playerData.wallCheckDistance, groundMask);
    
    #endregion


}
