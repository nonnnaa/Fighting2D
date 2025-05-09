public class Enemy_SlimeDeadState : Enemy_SlimeState
{
    public Enemy_SlimeDeadState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState, Enemy_Slime _slime) : base(_enemy, _enemySM, _enemyData, _enemyState, _slime)
    {
    }

    public override void EndAnimationTrigger()
    {
        base.EndAnimationTrigger();
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
