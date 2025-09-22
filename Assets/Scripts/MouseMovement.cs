using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    public float mouseSensitivity = 500f; // Tốc độ nhạy của chuột

    float xRotation = 0f; // Góc xoay theo trục X
    float yRotation = 0f; // Góc xoay theo trục Y

    public float topClamp = -90f;
    public float bottomClamp = 90f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Khóa chuột
    }

    void Update()
    {
        // đầu vào chuột
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        // Cập nhật góc xoay
        xRotation -= mouseY;
        yRotation += mouseX;
        // Giới hạn góc xoay theo trục X để tránh quay quá mức
        xRotation = Mathf.Clamp(xRotation, topClamp, bottomClamp);
        // Áp dụng góc xoay cho đối tượng
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
