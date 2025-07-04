using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1f; // Sát thương mặc định của viên đạn
    public float speed = 10f;
    private Vector3 targetPosition;

    private Animator animator;
    private bool isImpacting = false;

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if (isImpacting) return; // Dừng di chuyển khi đang nổ

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            TriggerImpact();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isImpacting) return;

        if (collision.CompareTag("Enemy"))
        {
         
            // Gây sát thương cho enemy nếu có component EnemyBehaviour
            EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
            Debug.Log(enemy);
            if (enemy != null)
            {
                enemy.TakeHit(damage);
            }

            TriggerImpact(); // Gọi animation nổ
        }
    }


    void TriggerImpact()
    {
        isImpacting = true;
        animator.SetTrigger("impact"); // Kích hoạt animation
    }

    // Gọi từ Animation Event (cuối animation Impact)
    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
