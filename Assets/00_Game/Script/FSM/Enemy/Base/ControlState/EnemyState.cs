using UnityEngine;

public class EnemyState 
{
    public Enemy enemy {  get; private set; }
    public EnemyStateMachine enemySM { get; private set; }
    private E_CharactorState enemyEState;
    protected EntityData enemyData;
    protected bool endAnimTrigger;
    protected float timer;


    public EnemyState(Enemy _enemy, EnemyStateMachine _enemySM, EntityData _enemyData, E_CharactorState _enemyState) 
    {
        enemy = _enemy;
        enemySM = _enemySM;
        enemyData = _enemyData;
        enemyEState = _enemyState;
    }

    public virtual void Enter()
    {
        enemy.animator.SetBool(enemyEState.ToString(), true);
        endAnimTrigger = false;
    }
    public virtual void LogicsUpdate()
    {
        if(timer > 0)
            timer -= Time.deltaTime;
    }
    public virtual void PhysicsUpdate()
    {

    }
    public virtual void Exit()
    {
        enemy.animator.SetBool(enemyEState.ToString(), false);
    }
    public virtual void EndAnimationTrigger()
    {
        endAnimTrigger = true;
    }
}
