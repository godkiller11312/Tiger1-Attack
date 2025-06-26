using UnityEngine;
using UnityEngine.UI;

public class HealthbarBehaviour : MonoBehaviour
{
    public Slider Slider;
    public Vector3 Offset;

    public void SetHealth(float health, float maxHealth)
    {
        Slider.gameObject.SetActive(health < maxHealth);
        Slider.value = health;
        Slider.maxValue = maxHealth;

        // Bỏ phần đổi màu theo lượng máu
        // Nếu muốn giữ 1 màu cố định, set sẵn trong prefab
    }

    private void Update()
    {
        if (Camera.main != null)
        {
            Slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + Offset);   
        }
    }
}
