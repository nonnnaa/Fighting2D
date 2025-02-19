using UnityEngine;

public class Enemy_SkeletonWalkState : Enemy_SkeletonGroundedState
{
    public Enemy_SkeletonWalkState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Skeleton _skeleton) : base(_enemy, _enemySM, _enemyData, _enemyState, _skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicsUpdate()
    {
        base.LogicsUpdate();
        
        if (skeleton.isTouchingWall() || !skeleton.isGrounded())
        {
            skeleton.Flip();
            enemySM.ChangeState(skeleton.idleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        skeleton.SetVelocity(enemyData.speedWalk * skeleton.directionX, skeleton.rb.velocity.y);
    }
}
