using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Inscribed")]
    public float dashMultiplier = 3f;     // how much faster during dash
    public float dashDuration = 0.2f;     // seconds the dash lasts
    public float dashCooldown = 1.0f;     // seconds before dash is ready again

    [Header("Dynamic")]
    public bool isDashing = false;
    public float dashTimer = 0f;
    public float cooldownTimer = 0f;

    private PlayerController pc;
    private float baseSpeed;

    void Start()
    {
        pc = GetComponent<PlayerController>();
        if (pc != null) baseSpeed = pc.speed;
    }

    void Update()
    {
        if (pc == null) return;

        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                pc.speed = baseSpeed;
                isDashing = false;
                cooldownTimer = dashCooldown;
            }
        }

        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        if (!isDashing && cooldownTimer <= 0f && Input.GetAxis("Jump") == 1)
        {
            isDashing = true;
            pc.speed = baseSpeed * dashMultiplier;
            dashTimer = dashDuration;
        }
    }
}
