using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{

    #region Skeleton State
    public Enemy_SkeletonGroundedState groundedState {  get; private set; }
    public Enemy_SkeletonIdleState idleState {  get; private set; }
    public Enemy_SkeletonWalkState walkState { get; private set; }
    public Enemy_SkeletonBattleState battleState { get; private set; }

    public Enemy_SkeletonAttackState attackState { get; private set; }
    #endregion  
    protected override void Awake()
    {
        base.Awake();
        groundedState = new Enemy_SkeletonGroundedState(this, enemyStateMachine, data, E_CharactorState.Idle, this);
        idleState = new Enemy_SkeletonIdleState(this, enemyStateMachine, data, E_CharactorState.Idle, this);
        walkState  = new Enemy_SkeletonWalkState(this, enemyStateMachine, data, E_CharactorState.Walk, this);
        battleState = new Enemy_SkeletonBattleState(this, enemyStateMachine, data, E_CharactorState.Walk, this);
        attackState = new Enemy_SkeletonAttackState(this, enemyStateMachine, data, E_CharactorState.Attack, this);
    }
    protected override void Start()
    {
        base.Start();
        enemyStateMachine.Initialize(idleState);
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void Update()
    {
        base.Update();
        //Debug.Log(IsPlayerDetected().collider?.gameObject?.name + " I SEE");
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        //Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + 10
        //    * directionX, wallCheck.position.y, wallCheck.position.z));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + data.distanceToAttack *
            directionX, wallCheck.position.y, wallCheck.position.z));
    }
    public bool CanAttack()
    {
        if (data.attackCoolDown <= (Time.time - lastTimeAttacked))
        {
            return true;
        }
        return false;
    }
}
