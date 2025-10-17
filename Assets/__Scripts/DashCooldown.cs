using UnityEngine;
using UnityEngine.UI;

public class DashCooldown : MonoBehaviour
{
    [Header("Inscribed")]
    public PlayerDash dash;
    public Text indicator;

    void Update()
    {
        if (dash.isDashing)
        {
            indicator.text = "Dash: Dashing!";
            return;
        }

        if (dash.cooldownTimer <= 0f)
        {
            indicator.text = "Dash: READY";
        }
        else
        {
            indicator.text = "Dash: " + dash.cooldownTimer.ToString("F1") + "s";
        }
    }
}
