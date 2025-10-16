using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Inscribed")]
    public float lifeSeconds = 3f;
    public int damage = 1;
    public string targetTag = "Player";

    void Start()
    {
        Destroy(gameObject, lifeSeconds);
    }

    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.CompareTag(targetTag))
        {
            if (targetTag == "Enemy")
            {
                EnemyController e = c.gameObject.GetComponent<EnemyController>();
                if (e != null)
                {
                    e.TakeDamage(damage);
                }
            }
            else if (targetTag == "Player")
            {
                PlayerHealth h = c.gameObject.GetComponent<PlayerHealth>();
                if (h != null)
                {
                    h.TakeDamage(damage);
                }
            }
        }
        
        Destroy(gameObject);
    }
}
