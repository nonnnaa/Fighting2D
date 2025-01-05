using UnityEngine;

public class DashState : PlayerState
{
    private float dashTimer;
    private float currentYVelocity;
    private float currentXVelocity;
    public DashState(Player _player, PlayerStateMachine _playerSM, PlayerData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
    {
    }

    public override void Enter()
    {
        base.Enter();
        dashTimer = playerData.dashTime;
        currentXVelocity = playerData.dashSpeed * player.directionX;
        currentYVelocity = player.rb.velocity.y;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void UpdateLogics()
    {
        base.UpdateLogics();
        dashTimer -= Time.deltaTime;
        if (dashTimer < 0f)
        {
            playerSM.ChangeState(player.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        player.SetVelocity(currentXVelocity, 0);
    }
}
