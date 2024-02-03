using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public class PlayerInteraction : MonoBehaviour
    {
        public float interactionDistance = 2f;

        // Обновление каждый кадр
        void Update()
        {
            // Проверка нажатия клавиши F
            if (Input.GetKeyDown(KeyCode.F))
            {
                // Вызываем метод для поиска и взаимодействия с предметом
                TryInteractWithFlashlight();
            }
        }

        // Метод для поиска и взаимодействия с предметом
        void TryInteractWithFlashlight()
        {
            // Определение направления перед игроком
            Vector3 forward = transform.TransformDirection(Vector3.forward);

            RaycastHit hit;

            // Проверка, есть ли объект с тегом "Flashlight" перед игроком
            if (Physics.Raycast(transform.position, forward, out hit, interactionDistance))
            {
                if (hit.collider.CompareTag("Flashlight"))
                {
                    // Здесь может быть код для взаимодействия с фонариком, например, его активации/деактивации
                    Debug.Log("Flashlight interacted!");
                }
            }
        }
    }
}

