using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [Header("Inscribed")]
    public float dashMultiplier = 3f;
    public float dashDuration = 0.3f;
    public float dashCooldown = 3.0f;

    [Header("Dynamic")]
    public bool isDashing = false;
    public float dashTimer = 0f;
    public float cooldownTimer = 0f;

    private PlayerController pc;
    private float baseSpeed;

    void Start()
    {
        pc = GetComponent<PlayerController>();
        if (pc != null)
        {
            baseSpeed = pc.speed;
        }
        GetComponent<TrailRenderer>().material.color = Color.white;
    }

    void Update()
    {
        if (dashTimer > 0f)
        {
            dashTimer -= Time.deltaTime;

            if (dashTimer <= 0f)
            {
                pc.speed = baseSpeed;
                isDashing = false;
                cooldownTimer = dashCooldown;
                GetComponent<TrailRenderer>().material.color = Color.white;
            }
        }

        if (cooldownTimer > 0f)
            cooldownTimer -= Time.deltaTime;

        if (!isDashing && cooldownTimer <= 0f && Input.GetAxis("Jump") == 1)
        {
            isDashing = true;
            pc.speed = baseSpeed * dashMultiplier;
            dashTimer = dashDuration;
            GetComponent<TrailRenderer>().material.color = Color.cyan;
        }

    }
}
