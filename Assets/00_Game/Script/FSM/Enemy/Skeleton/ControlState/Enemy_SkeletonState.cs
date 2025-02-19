using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_SkeletonState : EnemyState
{
    protected Enemy_Skeleton skeleton;
    public Enemy_SkeletonState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Skeleton _skeleton) : base(_enemy, _enemySM, _enemyData, _enemyState)
    {
        skeleton = _skeleton;
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
