using UnityEngine;
public class PlayerAnimationEvents : MonoBehaviour 
{
    private Player player;
    private void Start()
    {
        player = GetComponentInParent<Player>();
    }
    public void TriggerEndAttack() => player.playerSM.currentState.EndAnimationTrigger();
    public void TriggerDamage()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(player.attackCheck.position, player.getData().attackCheckRadius);
        foreach(Collider2D collider2d in collider)
        {
            collider2d.gameObject.GetComponent<Enemy>()?.Damage();
        }
    }
}
