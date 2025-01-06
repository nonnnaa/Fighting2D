using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlideState : PlayerState
{
    public WallSlideState(Player _player, PlayerStateMachine _playerSM, PlayerData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
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

    public override void UpdateLogics()
    {
        base.UpdateLogics();
        if((player.inputHandler.movementInput.x != 0 && 
            player.directionX * player.inputHandler.movementInput.x > 0) || player.isGrounded())
        {
            playerSM.ChangeState(player.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if(player.inputHandler.movementInput.y < 0)
        {
            player.SetVelocity(player.inputHandler.movementInput.x * playerData.speedRun, player.rb.velocity.y);
        }
        else player.rb.velocity = new Vector2(player.inputHandler.movementInput.x * playerData.speedRun, player.rb.velocity.y * playerData.slideRatio);
    }
}
