using UnityEngine;
public class EnemyAnimationEvents : MonoBehaviour
{
    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void TriggerEndAttack() => enemy.enemyStateMachine.currentState.EndAnimationTrigger();

    public void TriggerDamage()
    {
        Collider2D[] collider2D = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.getData().attackCheckRadius);
        foreach(Collider2D collider in collider2D)
        {
            collider.gameObject.GetComponent<Player>()?.Damage();
        }
    }
}
