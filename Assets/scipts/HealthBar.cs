using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image HealthIMG;
    public Damagable CurrentHp;
    public float smoothTime = 0.2f;
    float currentVelocity;
    
    void Awake()
    {
        HealthIMG = GetComponent<Image>();
    }

    void Update()
    {
        HealthIMG.fillAmount = Mathf.SmoothDamp(
            current: HealthIMG.fillAmount,
            target: CurrentHp.HPFraction,
            ref currentVelocity,
            smoothTime: smoothTime
        );
    }
}
