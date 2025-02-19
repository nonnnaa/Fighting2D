using UnityEngine;
public class AttackState : PlayerState
{
    private int comboCounter;
    private float lastAttackTime;
    private float comboTime = 2f;
    public AttackState(Player _player, PlayerStateMachine _playerSM, EntityData _playerData, E_CharactorState _playerState) : base(_player, _playerSM, _playerData, _playerState)
    {
    }
    public override void EndAnimationTrigger()
    {
        base.EndAnimationTrigger();
    }
    public override void Enter()
    {
        base.Enter();
        if (comboCounter > 2 || (Time.time - lastAttackTime >= comboTime))
            comboCounter = 0;
        player.animator.SetInteger(PlayerString.attackId, comboCounter);
    }

    public override void Exit()
    {
        base.Exit();
        lastAttackTime = Time.time;
        comboCounter++;
    }

    public override void UpdateLogics()
    {
        base.UpdateLogics();
        if (endAnimTrigger)
        {
            playerSM.ChangeState(player.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }
}
