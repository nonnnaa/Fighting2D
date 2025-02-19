using UnityEngine;
public class Enemy_SkeletonAttackState : Enemy_SkeletonState
{
    
    public Enemy_SkeletonAttackState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Skeleton _skeleton) : base(_enemy, _enemySM, _enemyData, _enemyState, _skeleton)
    {

    }

    public override void Enter()
    {
        base.Enter();
        skeleton.SetVelocity(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.lastTimeAttacked = Time.time;
    }

    public override void LogicsUpdate()
    {
        base.LogicsUpdate();
        var tmp = skeleton.IsPlayerDetected();
        if ((tmp.collider == null || tmp.distance > enemyData.distanceToAttack) && endAnimTrigger)
        {
            enemySM.ChangeState(skeleton.battleState);
        }
        else if(endAnimTrigger)
        {
            
            enemySM.ChangeState(skeleton.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
