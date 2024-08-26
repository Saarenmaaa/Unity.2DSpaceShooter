using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed = 3f;
    public float rotateSpeed = 0.025f;
    private Rigidbody2D rb;
    [SerializeField] float maxHealth;
    [SerializeField] FloatHealthBar healthBar;
    private float healthNow;
    public OnDrop dropSystem;

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatHealthBar>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthNow = maxHealth;
        healthBar.UpdateHealthBar(healthNow, maxHealth);

    }
    private void Update()
    {
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }

    private void RotateTowardsTarget()
    {
        if (target != null)
        {
            Vector2 targetDirection = target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        }
    }
    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }
    public void TakeDamage(float damageAmount)
    {
        healthNow -= damageAmount;
        healthBar.UpdateHealthBar(healthNow, maxHealth);
        Debug.Log(healthNow);
        if (healthNow <= 0)
        {
            dropSystem.DropItem();
            Destroy(gameObject);
        }
    }
}
