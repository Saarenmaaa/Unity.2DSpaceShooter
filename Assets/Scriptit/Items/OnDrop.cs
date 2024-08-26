using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDrop : MonoBehaviour
{
    public GameObject heal;

    public float dropChanceHeal = 0.3f;

    private void Start()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
    }

    public void DropItem()
    {
        float randomValue = Random.value;

        if (Random.value <= dropChanceHeal)
        {
            Instantiate(heal, transform.position, Quaternion.identity);
        }
    }
}
