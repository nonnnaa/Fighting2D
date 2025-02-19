using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonIdleState : Enemy_SkeletonGroundedState
{
    public Enemy_SkeletonIdleState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Skeleton _skeleton) : base(_enemy, _enemySM, _enemyData, _enemyState, _skeleton)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = 1f;
        skeleton.SetVelocity(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicsUpdate()
    {
        base.LogicsUpdate();
        if (timer < 0)
        {
            enemySM.ChangeState(skeleton.walkState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
