public class Enemy_Slime : Enemy
{

    #region State
    public Enemy_SlimeGroundedState groundedState {  get;private set; }
    public Enemy_SlimeIdleState idleState { get;private set; }
    public Enemy_SlimeRunState runState { get;private set; }
    public Enemy_SlimeAttackState attackState { get;private set; }  
    public Enemy_SlimeDeadState deadState { get;private set; }
    #endregion
    protected override void Awake()
    {
        base.Awake();
        groundedState = new Enemy_SlimeGroundedState(this, enemyStateMachine, data, E_CharactorState.Idle, this);
        idleState = new Enemy_SlimeIdleState(this, enemyStateMachine, data, E_CharactorState.Idle, this);
        runState = new Enemy_SlimeRunState(this, enemyStateMachine, data, E_CharactorState.Run, this);
        attackState = new Enemy_SlimeAttackState(this, enemyStateMachine, data, E_CharactorState.Attack, this);

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    
}
