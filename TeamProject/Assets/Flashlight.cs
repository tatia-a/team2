using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float interactionDistance = 2f;

        // ���������� ������ ����
        void Update()
        {
            // �������� ������� ������� F
            if (Input.GetKeyDown(KeyCode.F))
            {
                // �������� ����� ��� ������ � �������������� � ���������
                TryInteractWithFlashlight();
            }
        }

        // ����� ��� ������ � �������������� � ���������
        void TryInteractWithFlashlight()
        {
            // ����������� ����������� ����� �������
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            RaycastHit hit;

            // ��������, ���� �� ������ � ����� "Flashlight" ����� �������
            if (Physics.Raycast(transform.position, forward, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag("Flashlight"))
                {
                    // ����� ����� ���� ��� ��� �������������� � ���������, ��������, ��� ���������/�����������
                    Debug.Log("Flashlight interacted!");
                }
            }
        }
    }
}

