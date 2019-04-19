using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image HealthIMG;
    public float smoothTime = 0.2f;
    float currentVelocity;
    Damagable CurrentHp;
    
    void Awake()
    {
        HealthIMG = GetComponent<Image>();
    }

    void Update()
    {
        // try to get component from parent (for enemies)
        if (!CurrentHp)
            CurrentHp = GetComponentInParent<Damagable>();

        // try to assign player's health bar
        if (!CurrentHp)
            CurrentHp = FindObjectOfType<Inventory>().GetComponent<Damagable>();

        HealthIMG.fillAmount = Mathf.SmoothDamp(
            current: HealthIMG.fillAmount,
            target: CurrentHp.HPFraction,
            ref currentVelocity,
            smoothTime: smoothTime
        );
    }
}
