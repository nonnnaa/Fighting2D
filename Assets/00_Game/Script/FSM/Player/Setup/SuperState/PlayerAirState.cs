using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    
    public PlayerAirState(Player _player, PlayerStateMachine _playerSM, EntityData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
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
        if(player.rb.velocity.y == 0 && player.isGrounded())
        {
            playerSM.ChangeState(player.idleState);
        }

        if(player.isTouchingWall())
        {
            playerSM.ChangeState(player.wallSlideState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (player.inputHandler.movementInput.x != 0)
        {
            player.SetVelocity(playerData.fallRatioVelocityX * player.inputHandler.movementInput.x * playerData.speedRun, player.rb.velocity.y);
        }
        //player.SetVelocity(player.rb.velocity.x, player.rb.velocity.y);

    }
}
