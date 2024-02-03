using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{


    public class PlayerController : MonoBehaviour
    {
        public float jumpForce = 5f;
        public bool isGrounded;

        // �������� ���������� �� �����
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                isGrounded = true;
            }
        }

        // ��������� ������ ��� ������� �������
        void Update()
        {
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                Jump();
            }
        }

        // ����� ��� ���������� ������
        void Jump()
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

    }
}
