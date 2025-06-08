using UnityEngine;

public class TankMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private int moveDirection = 0; // -1: trái, 1: phải, 0: đứng yên

    void Update()
    {
        if (moveDirection !=0)
        {         // Di chuyển theo hướng đang giữ nút
            transform.Translate(Vector3.right * moveDirection * moveSpeed * Time.deltaTime);
        }    

    }

    // Gọi khi bắt đầu giữ nút trái
    public void StartMoveLeft()
    {
        moveDirection = -1;
    }

    // Gọi khi bắt đầu giữ nút phải
    public void StartMoveRight()
    {
        moveDirection = 1;
    }

    // Gọi khi thả nút (trái hoặc phải)
    public void StopMove()
    {
        moveDirection = 0;
    }
}
