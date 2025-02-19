using UnityEngine;

[CreateAssetMenu(fileName = "EntityData", menuName = "Data/EntityData")]
public class EntityData : ScriptableObject
{
    public string entityName;
    public float hp;
    public float speedRun;
    public float speedWalk;

    [Header("WallSlide")]
    [Range(0, 1)] public float slideRatio;


    [Header("Jump")]
    public float jumpForce;
    public int jumpCount;
    public float wallJumpForceX;
    public float fallRatioVelocityX;

    [Header("Dash info")]
    public float dashTime;
    public float dashSpeed;
    public float dashCooldown;

    [Header("Check collision info")]
    public float groundCheckDistance;
    public float wallCheckDistance;


    [Header("Attack Infor")]
    public float distanceToAttack;
    public float attackCoolDown;
}
