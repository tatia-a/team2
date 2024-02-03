using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public class PlayerController : MonoBehaviour
    {
        public float jumpForce = 5f;
        public bool isGrounded;

        // Проверка нахождения на земле
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }

        // Обработка прыжка при нажатии клавиши
        void Update()
        {
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        // Метод для выполнения прыжка
        void Jump()
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
