using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitPoints = 5;
    public HealthbarBehaviour Healthbar;

    void Start()
    {
        Hitpoints = MaxHitPoints;

        if (Healthbar != null)
        {
            Healthbar.SetHealth(Hitpoints, MaxHitPoints);
        }
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;

        if (Healthbar != null)
        {
            Healthbar.SetHealth(Hitpoints, MaxHitPoints);
        }

        if (Hitpoints <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Có thể thêm hiệu ứng nổ tại đây
        Destroy(gameObject);
    }
}
