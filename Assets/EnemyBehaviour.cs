using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float MaxHitPoints = 5;
    public HealthbarBehaviour Healthbar;

    void Start()
    {
        Hitpoints = MaxHitPoints;
        Healthbar.SetHealth(Hitpoints, MaxHitPoints);

    }

    public void TakeHit(float damage)
    {
       
        Hitpoints -= damage;
        Healthbar.SetHealth(Hitpoints, MaxHitPoints);
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeHit(2); // Gọi khi nhấn phím Space
        }
    }


}
