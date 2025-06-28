using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform PhaoTransform;
    public RaycastChecker raycastChecker;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transform enemy = raycastChecker.TargetEnemy;
            if (enemy != null)
            {
                Shoot(enemy.position);
            }
        }
    }

    void Shoot(Vector3 target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, PhaoTransform.rotation);
        bullet.GetComponent<Bullet>().SetTarget(target);
    }
}
