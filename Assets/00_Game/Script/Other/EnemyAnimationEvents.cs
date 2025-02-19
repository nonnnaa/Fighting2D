using UnityEngine;

public class EnemyAnimationEvents : MonoBehaviour
{
    private Enemy enemy;
    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }
    public void TriggerAttack() => enemy.enemyStateMachine.currentState.EndAnimationTrigger();
}
