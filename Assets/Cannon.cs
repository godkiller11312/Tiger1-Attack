using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public Transform PhaoTransform;
    public RaycastChecker raycastChecker;

    public float fireCooldown = 1.5f;
    private float lastFireTime = -Mathf.Infinity;

    private Animator animator;

    void Start()
    {
        animator = PhaoTransform.GetComponent<Animator>();
    }

    void Update()
    {
        Transform enemy = raycastChecker.TargetEnemy;

        if (enemy != null && Time.time >= lastFireTime + fireCooldown)
        {
            animator.SetTrigger("Fire");

            Shoot(enemy.position);
            lastFireTime = Time.time;
        }
    }

    void Shoot(Vector3 target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, PhaoTransform.rotation);
        bullet.GetComponent<Bullet>().SetTarget(target);
    }
}
