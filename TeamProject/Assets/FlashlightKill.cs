using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightKill : MonoBehaviour
{
    public float range = 100f; // Максимальная дальность луча
    public float destructionDelay = 2f; // Время в секундах, необходимое для уничтожения объекта

    private GameObject currentTarget; // Текущая цель луча
    private float timer = 0f; // Таймер для отсчета времени удержания луча на объекте

    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        RaycastHit hit;
        // Испускаем луч из текущей позиции в направлении взгляда
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            // Проверяем, имеет ли объект, в который попал луч, тег "Eye"
            if (hit.collider.tag == "Eye")
            {
                // Проверяем, является ли этот объект текущей целью
                if (currentTarget == hit.collider.gameObject)
                {
                    currentTarget.GetComponent<Eye>().SwitchAnimation(true);
                    // Увеличиваем таймер, если луч все еще на объекте
                    timer += Time.deltaTime;
                    // Проверяем, достиг ли таймер необходимого времени для уничтожения
                    if (timer >= destructionDelay)
                    {
                        // Уничтожаем объект и сбрасываем таймер и цель
                        Destroy(currentTarget);
                        currentTarget = null;
                        timer = 0f;
                    }
                }
                else
                {
                    // Если луч попал в новый объект, обновляем текущую цель и сбрасываем таймер
                    currentTarget = hit.collider.gameObject;
                    timer = 0f;
                }
            }
            else
            {
                // Если луч не на объекте с тегом "eye", сбрасываем таймер и текущую цель
                ResetTarget();
            }
        }
        else
        {
            // Если луч не попал ни в один объект, сбрасываем таймер и текущую цель
            ResetTarget();
        }
    }

    // Метод для сброса текущей цели и таймера
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