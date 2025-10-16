using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 2f;
    public float shootDelay = 2f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public int health = 1;

    [Header("Dynamic")]
    private Transform player;
    private float nextShotTime = 0f;

    void Awake()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null)
        {
            player = p.transform;
        }
    }

    void Update()
    {
        Vector3 dir = (player.position - transform.position);
        dir.y = 0f;
        if (dir.sqrMagnitude > 0.0001f)
        {
            transform.rotation = Quaternion.LookRotation(dir.normalized, Vector3.up);
            transform.position += dir.normalized * speed * Time.deltaTime;
        }

        if (Time.time >= nextShotTime)
        {
            Shoot();
            nextShotTime = Time.time + shootDelay;
        }
    }

    void Shoot()
    {
        GameObject b = Instantiate(bulletPrefab, transform.position + transform.forward, transform.rotation);
        Rigidbody rb = b.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = transform.forward * bulletSpeed;
        }
    }

    public void TakeDamage(int dmg = 1)
    {
        health -= dmg;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
