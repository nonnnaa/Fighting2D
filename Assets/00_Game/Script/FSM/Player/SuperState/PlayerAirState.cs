using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _playerSM, PlayerData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
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
        if (player.rb.velocity.y == 0)
        {
            if(player.rb.velocity.x != 0)
            {
                playerSM.ChangeState(player.runState);
            }else 
                playerSM.ChangeState(player.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        
    }
}
