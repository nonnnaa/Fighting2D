using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : PlayerAirState
{
    public FallState(Player _player, PlayerStateMachine _playerSM, PlayerData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
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
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
