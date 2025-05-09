using UnityEngine;
public class DashState : PlayerState
{
    private float dashTimer;
    public DashState(Player _player, PlayerStateMachine _playerSM, EntityData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
    {

    }
    public override void Enter()
    {
        base.Enter();
        dashTimer = playerData.dashTime;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void UpdateLogics()
    {
        base.UpdateLogics();
        dashTimer -= Time.deltaTime;
        if (dashTimer < 0)
        {
            playerSM.ChangeState(player.idleState);
            
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        player.SetVelocity(playerData.dashSpeed * player.directionX, 0);
    }
}
