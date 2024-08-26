using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public WeaponScript weapon;
    Vector2 moveDirection;
    Vector2 mousePosition;
    float minX, maxX, minY, maxY;
    public float health = 5;
    void Start()
    {
        CameraCheck();
    }
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Shot();

        moveDirection = new Vector2(moveX, moveY).normalized;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
    void FixedUpdate()
    {
        MoveinLimit();
        Aim();
    }
    private void CameraCheck()
    {
        float offset = 0.5f;
        minX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        maxX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offset;
        minY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + offset;
        maxY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - offset;
    }
    private void Shot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
    }
    private void Aim()
    {
        Vector2 aim = mousePosition - rb.position;
        float aimAngle = Mathf.Atan2(aim.y, aim.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimAngle;
    }
    private void MoveinLimit()
    {
        float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(rb.position.y, minY, maxY);
        rb.position = new Vector2(clampedX, clampedY);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Enemy":
                health--;
                Destroy(other.gameObject);
                Debug.Log("Health: " + health);
                break;
            case "Health":
                health = 5;
                Destroy(other.gameObject);
                Debug.Log("Health: " + health);
                break;
            case "EnemyBullet":
                health--;
                Destroy(other.gameObject);
                Debug.Log("Health: " + health);
                break;
            case "Boss":
                health -= 2;
                Debug.Log("Health: " + health);
                break;
            default:
                break;
        }
    }
}
