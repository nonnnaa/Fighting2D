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
        if(player.isGrounded())
        {
            playerSM.ChangeState(player.idleState);
        }
        if(player.inputHandler.isJump)
        {
            playerSM.ChangeState(player.wallJumpState);
            return;
        }
        if(!player.isTouchingWall())
        {
            playerSM.ChangeState(player.airState);
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        player.SetVelocity(0, playerData.slideRatio * player.rb.velocity.y);
    }
}
