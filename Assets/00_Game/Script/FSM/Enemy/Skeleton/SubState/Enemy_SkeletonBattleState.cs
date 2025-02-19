using UnityEngine;

public class Enemy_SkeletonBattleState : Enemy_SkeletonState
{
    private Transform player;
    private float moveDir = 1;
    
    public Enemy_SkeletonBattleState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Skeleton _skeleton) : base(_enemy, _enemySM, _enemyData, _enemyState, _skeleton)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicsUpdate()
    {
        base.LogicsUpdate();
        if ((!skeleton.isGrounded() || skeleton.isTouchingWall()))
        {
            
            enemySM.ChangeState(skeleton.walkState);
        }

        // Check Player Direction to Move

        if ((skeleton.transform.position.x > player.position.x))
        {
            if(!skeleton.isFacingLeft)
            {
                skeleton.Flip();
            }
            moveDir = -1;
        }
        else
        {
            if (skeleton.isFacingLeft)
            {
                skeleton.Flip();
            }
            moveDir = 1;
        }

        var tmp = skeleton.IsPlayerDetected();
        if (tmp.collider != null && tmp.distance <= enemyData.distanceToAttack)
        {
            if(skeleton.CanAttack())
                enemySM.ChangeState(skeleton.attackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        // Check Distance to Attack
        skeleton.SetVelocity(enemyData.speedWalk * moveDir, skeleton.rb.velocity.y);
    }
}
