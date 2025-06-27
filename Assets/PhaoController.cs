using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaoController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Lấy Animator từ GameObject này
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Kiểm tra nếu nhấn phím Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Fire");
        }
    }
}
