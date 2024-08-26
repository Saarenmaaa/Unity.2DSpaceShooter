using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        OffScreen();
    }

    void OffScreen()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPoint.x < 0 || screenPoint.x > Screen.width || screenPoint.y < 0 || screenPoint.y > Screen.height)
        {
            Destroy(gameObject);
        }   
    }
}
