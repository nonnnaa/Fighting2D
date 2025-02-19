using UnityEngine;
public class IdleState : PlayerGroundedState
{
    public IdleState(Player _player, PlayerStateMachine _playerSM , EntityData _playerData, E_CharactorState _playerState) 
        : base(_player, _playerSM, _playerData, _playerState)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, 0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogics()
    {
        base.UpdateLogics();
        if(player.inputHandler.movementInput.x != 0 && player.isGrounded())
        {
            playerSM.ChangeState(player.runState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
