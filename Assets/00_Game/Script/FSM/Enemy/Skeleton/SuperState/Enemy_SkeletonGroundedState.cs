using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonGroundedState : Enemy_SkeletonState
{
    public Enemy_SkeletonGroundedState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Skeleton _skeleton) : base(_enemy, _enemySM, _enemyData, _enemyState, _skeleton)
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
        if(skeleton.IsPlayerDetected() && skeleton.CanAttack())
        {
            enemySM.ChangeState(skeleton.battleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
