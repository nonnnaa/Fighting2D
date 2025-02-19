using UnityEngine;
public class PlayerAnimationEvents : MonoBehaviour 
{
    private Player player;
    private void Start()
    {
        player = GetComponentInParent<Player>();
    }
    public void TriggerAttack() => player.playerSM.currentState.EndAnimationTrigger();
}
