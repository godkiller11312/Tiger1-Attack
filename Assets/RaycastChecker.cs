using UnityEngine;

public class RaycastChecker : MonoBehaviour
{
    public float rayDistance = 5f;
    public LayerMask targetLayer;

    void Update()
    {
        Vector2 origin = transform.position;
        Vector2 direction = Vector2.up; // hoặc transform.up nếu muốn theo hướng object xoay

        RaycastHit2D hit = Physics2D.Raycast(origin, direction, rayDistance, targetLayer);

        if (hit.collider != null)
        {
            Debug.Log("Phát hiện: " + hit.collider.name);

            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy ở phía trên!");
            }
        }

        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }

}
