using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : Entity
{
    #region State
    public PlayerStateMachine playerSM{ get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerGroundedState groundedState { get; private set; }
    public IdleState idleState { get; private set; }
    public RunState runState { get; private set; }
    public JumpState jumpState { get; private set; }
    public DashState dashState { get; private set; }
    public WallSlideState wallSlideState { get; private set; }

    public WallJumpState wallJumpState { get; private set; }

    public AttackState attackState { get; private set; }
    #endregion

    public PlayerInputHandler inputHandler { get; private set;}
    public int jumpCount {get; private set; }
    protected override void Awake()
    {
        base.Awake();
        playerSM = new PlayerStateMachine();
        // Parrent state
        airState = new PlayerAirState(this, playerSM, data, E_CharactorState.Jump);
        groundedState = new PlayerGroundedState(this, playerSM, data, E_CharactorState.Idle);

        // Sub state
        idleState = new IdleState(this, playerSM, data, E_CharactorState.Idle);
        runState = new RunState(this, playerSM, data, E_CharactorState.Run);
        jumpState = new JumpState(this, playerSM, data, E_CharactorState.Jump);
        dashState = new DashState(this, playerSM, data, E_CharactorState.Dash);
        wallSlideState = new WallSlideState(this, playerSM, data, E_CharactorState.WallSlide);
        wallJumpState = new WallJumpState(this, playerSM, data, E_CharactorState.Jump);
        attackState = new AttackState(this, playerSM, data, E_CharactorState.Attack);

        inputHandler = GetComponent<PlayerInputHandler>(); 
    }


    protected override void Start()
    {
        base.Start();
        playerSM.InitState(idleState);
        jumpCount = data.jumpCount;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        playerSM.currentState.UpdatePhysics();
    }

    protected override void Update()
    {
        base.Update();
        playerSM.currentState.UpdateLogics();
    }
}
