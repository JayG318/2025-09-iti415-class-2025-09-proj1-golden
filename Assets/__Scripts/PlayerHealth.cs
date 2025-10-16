using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Inscribed")]
    public int maxHealth = 3;
    public float restartDelay = 2f;
    public string gameOverMessage = "Game Over!";
    public Text HealthText;
    public Text GameOverText;

    [Header("Dynamic")]
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        if (GameOverText != null) 
        {
            GameOverText.text = "";
        }
        
        if (GameOverText != null) 
        {
            GameOverText.enabled = false;
        }

        if (HealthText != null) 
        {
            HealthText.text = "Health: " + currentHealth;
        }
    }

    public void TakeDamage(int dmg = 1)
    {
        currentHealth -= dmg;
        Debug.Log("Player hit! Health = " + currentHealth);

        if (HealthText != null) 
        {
            HealthText.text = "Health: " + currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log(gameOverMessage);
        if (GameOverText != null) 
        {
            GameOverText.text = gameOverMessage;
            GameOverText.enabled = true;
        }

        PlayerController pc = GetComponent<PlayerController>();
        if (pc != null) pc.enabled = false;

        PlayerDash pd = GetComponent<PlayerDash>();
        if (pd != null) pd.enabled = false;

        SurvivalScore ss = FindFirstObjectByType<SurvivalScore>();
        if (ss != null)
        {
            ss.StopScoring();
        }

        Invoke(nameof(RestartScene), restartDelay);
    }

    void RestartScene()
    {
        SceneManager.LoadScene("Map");
    }
}
