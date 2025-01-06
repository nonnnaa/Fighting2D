using UnityEngine;
public class IdleState : PlayerGroundedState
{
    public IdleState(Player _player, PlayerStateMachine _playerSM , PlayerData _playerData, E_CharactorState _playerState) 
        : base(_player, _playerSM, _playerData, _playerState)
    {
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Enter Idle State");
        player.SetVelocity(player.inputHandler.movementInput.x * playerData.speedRun, 0);
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("Exit Idle State");
    }

    public override void UpdateLogics()
    {
        base.UpdateLogics();
        //Debug.Log("Update Logics Idle State");
        if (player.inputHandler.movementInput.x != 0)
        {
            playerSM.ChangeState(player.runState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //Debug.Log("Update Physics Idle State");
    }
}
