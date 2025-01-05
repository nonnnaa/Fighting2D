using UnityEditor.Tilemaps;
using UnityEngine;
public class RunState : PlayerGroundedState
{
    public RunState(Player _player, PlayerStateMachine _playerSM, PlayerData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
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
        if (player.inputHandler.movementInput.x == 0)
        {
            playerSM.ChangeState(player.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        player.SetVelocity(player.inputHandler.movementInput.x * playerData.speedRun, player.rb.velocity.y);
    }
}
