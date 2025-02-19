using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : PlayerAirState
{
    
    public JumpState(Player _player, PlayerStateMachine _playerSM, EntityData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(player.rb.velocity.x, playerData.jumpForce);
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogics()
    {
        base.UpdateLogics();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if(player.rb.velocity.y < 0)
        {
            playerSM.ChangeState(player.airState);
        }
    }
}
