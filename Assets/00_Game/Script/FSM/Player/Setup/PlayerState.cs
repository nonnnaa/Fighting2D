using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerState {

    protected Player player;
    protected PlayerStateMachine playerSM;
    protected EntityData playerData;
    protected bool endAnimTrigger;
    private E_CharactorState playerEState;
    
    public PlayerState(Player _player, PlayerStateMachine _playerSM, EntityData _playerData, E_CharactorState _playerState)
    {
        player = _player;
        playerSM = _playerSM;
        playerData = _playerData;
        playerEState = _playerState;
    }
    public virtual void Enter()
    {
        player.animator.SetBool(playerEState.ToString(), true);
        endAnimTrigger = false;
    }
    public virtual void UpdateLogics()
    {
        player.animator.SetFloat(PlayerString.yVelocity, player.rb.velocity.y);

        if ((player.isFacingLeft && player.inputHandler.movementInput.x > 0) ||
        (!player.isFacingLeft && player.inputHandler.movementInput.x < 0)) player.Flip();
        if (player.inputHandler.isDash && player.dashTimer < 0f)
        {
            player.ResetDashTimer();
            playerSM.ChangeState(player.dashState);
        }
    }
    public virtual void UpdatePhysics()
    {

    }
    public virtual void Exit()
    {
        player.animator.SetBool(playerEState.ToString(), false);
    }

    public virtual void EndAnimationTrigger() => endAnimTrigger = true;
}
