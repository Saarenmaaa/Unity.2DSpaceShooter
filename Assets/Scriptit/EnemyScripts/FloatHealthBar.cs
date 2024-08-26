using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    public Color lowHealthColor = new Color(1.0f, 0.5f, 0.5f);
    public Color fullHealthColor = new Color(0.5f, 1.0f, 0.5f);

    private void Start()
    {
        camera = Camera.main;
    }
    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        float healthPercentage = currentValue / maxValue;
        slider.value = healthPercentage;

        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(lowHealthColor, fullHealthColor, healthPercentage);
    }

    void Update()
    {
        transform.parent.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }

    
}
