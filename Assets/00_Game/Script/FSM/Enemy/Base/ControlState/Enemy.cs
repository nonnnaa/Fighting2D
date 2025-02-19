using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;
    [HideInInspector] public float lastTimeAttacked;
    public EnemyStateMachine enemyStateMachine { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        enemyStateMachine = new EnemyStateMachine();
    }
    protected override void Start()
    {
        base.Start();
        
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        enemyStateMachine.currentState.PhysicsUpdate();
    }
    protected override void Update()
    {
        base.Update();
        enemyStateMachine.currentState.LogicsUpdate();
        
    }
    public RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, transform.right, 50, whatIsPlayer);
}
