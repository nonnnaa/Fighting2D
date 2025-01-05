public class PlayerStateMachine 
{
    public PlayerState currentState {  get; private set; }
    public virtual void InitState(PlayerState _initState)
    {
        currentState = _initState;
        currentState.Enter();
    }
    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
