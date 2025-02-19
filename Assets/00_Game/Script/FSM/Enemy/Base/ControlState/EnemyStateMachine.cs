public class EnemyStateMachine
{
    public Enemy enemy { get; private set; }
    public EnemyState currentState {  get; private set; }

    public void Initialize(EnemyState enemyState)
    {
        currentState = enemyState;
        currentState.Enter();
    }
    public void ChangeState(EnemyState enemyState)
    {
        currentState.Exit();
        currentState = enemyState;
        currentState.Enter();
    }
}
