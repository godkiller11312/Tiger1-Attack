using UnityEngine;

public class RaycastChecker : MonoBehaviour
{
    public float rayDistance = 15f;
    public LayerMask targetLayer;
    public Transform barrelTransform; // Gắn pháo (Phao)

    private Transform targetEnemy;

    void Update()
    {
        if (targetEnemy != null)
        {
            // Tính hướng tới enemy
            Vector2 directionToEnemy = (targetEnemy.position - barrelTransform.position).normalized;

            // Tính góc quay (sprite hướng mặc định là lên trên)
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg - 90f;

            // Chỉ xoay trục Z
            barrelTransform.rotation = Quaternion.Euler(0, 0, angle);

            // Raycast theo hướng pháo (transform.up)
            Vector2 origin = barrelTransform.position;
            Vector2 direction = barrelTransform.up;

            RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance, targetLayer);

            if (hit.collider != null)
            {
                Debug.Log("Phát hiện: " + hit.collider.name);

                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy trúng raycast!");
                }
            }

            Debug.DrawRay(origin, direction * rayDistance, Color.red);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & targetLayer) != 0)
        {
            if (collision.CompareTag("Enemy"))
            {
                Debug.Log("Enemy vào vùng phát hiện!");
                targetEnemy = collision.transform;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == targetEnemy)
        {
            Debug.Log("Enemy rời khỏi vùng phát hiện!");
            targetEnemy = null;
        }
    }
}
