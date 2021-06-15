using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHeatlh(float health)
    {
        slider.value = health;
    }

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        
    }
}
