using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightKill : MonoBehaviour
{
    public float range = 100f; // ������������ ��������� ����
    public float destructionDelay = 2f; // ����� � ��������, ����������� ��� ����������� �������

    private GameObject currentTarget; // ������� ���� ����
    private float timer = 0f; // ������ ��� ������� ������� ��������� ���� �� �������

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        RaycastHit hit;
        // ��������� ��� �� ������� ������� � ����������� �������
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // ���������, ����� �� ������, � ������� ����� ���, ��� "Eye"
            if (hit.collider.tag == "Eye")
            {
                // ���������, �������� �� ���� ������ ������� �����
                if (currentTarget == hit.collider.gameObject)
                {
                    currentTarget.GetComponent<Eye>().SwitchAnimation(true);
                    // ����������� ������, ���� ��� ��� ��� �� �������
                    timer += Time.deltaTime;
                    // ���������, ������ �� ������ ������������ ������� ��� �����������
                    if (timer >= destructionDelay)
                    {
                        // ���������� ������ � ���������� ������ � ����
                        Destroy(currentTarget);
                        currentTarget = null;
                        timer = 0f;
                    }
                }
                else
                {
                    // ���� ��� ����� � ����� ������, ��������� ������� ���� � ���������� ������
                    currentTarget = hit.collider.gameObject;
                    timer = 0f;
                }
            }
            else
            {
                // ���� ��� �� �� ������� � ����� "eye", ���������� ������ � ������� ����
                ResetTarget();
            }
        }
        else
        {
            // ���� ��� �� ����� �� � ���� ������, ���������� ������ � ������� ����
            ResetTarget();
        }
    }

    // ����� ��� ������ ������� ���� � �������
    void ResetTarget()
    {
        Eye eye;
        if (currentTarget != null && currentTarget.TryGetComponent<Eye>(out eye))
        {
            eye.SwitchAnimation(false);
        }
        currentTarget = null;
        timer = 0f;
    }
}