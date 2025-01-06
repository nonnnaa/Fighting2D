
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/PlayerData")]

public class PlayerData : ScriptableObject
{
    public string playerName;
    public float hp;
    public float speedRun;

    [Header("WallSlide")]
    [Range(0, 1)] public float slideRatio;


    [Header("Jump")]
    public float jumpForce;
    public int jumpCount;

    [Header("Dash info")]
    public float dashTime;
    public float dashSpeed;
    public float dashCooldown;


    [Header("Check collision info")]
    public float groundCheckDistance;
    public float wallCheckDistance;
}
