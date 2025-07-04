using System.Collections.Generic;
using UnityEngine;

public class RaycastChecker : MonoBehaviour
{
    public float rayDistance = 15f;
    public LayerMask targetLayer;
    public Transform barrelTransform;

    private Transform targetEnemy;
    private List<Transform> enemiesInRange = new List<Transform>();

    void Update()
    {
        // Loại bỏ enemy đã bị hủy hoặc null
        enemiesInRange.RemoveAll(e => e == null || !e.gameObject.activeInHierarchy);

        // Tìm enemy gần nhất theo khoảng cách
        FindClosestTarget();

        if (targetEnemy != null)
        {
            // Quay pháo hướng tới target
            Vector2 directionToEnemy = (targetEnemy.position - barrelTransform.position).normalized;
            float angle = Mathf.Atan2(directionToEnemy.y, directionToEnemy.x) * Mathf.Rad2Deg - 90f;
            barrelTransform.rotation = Quaternion.Euler(0, 0, angle);

            // Raycast để debug
            Vector2 origin = barrelTransform.position;
            Vector2 direction = barrelTransform.up;
            Debug.DrawRay(origin, direction * rayDistance, Color.red);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & targetLayer) != 0 && collision.CompareTag("Enemy"))
        {
            if (!enemiesInRange.Contains(collision.transform))
            {
                enemiesInRange.Add(collision.transform);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (enemiesInRange.Contains(collision.transform))
        {
            enemiesInRange.Remove(collision.transform);
        }

        if (collision.transform == targetEnemy)
        {
            targetEnemy = null;
        }
    }

    // Tìm enemy gần nhất về khoảng cách
    private void FindClosestTarget()
    {
        float minDistance = float.MaxValue;
        Transform closest = null;

        foreach (Transform enemy in enemiesInRange)
        {
            float distance = Vector2.Distance(barrelTransform.position, enemy.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closest = enemy;
            }
        }

        targetEnemy = closest;
    }

    public Transform TargetEnemy => targetEnemy;

    // (Tùy chọn) Vẽ vùng trigger để debug trong Scene
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rayDistance);
    }
}
