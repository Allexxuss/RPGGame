using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Image HealthIMG;
    public Damagable CurrentHp;
    
    void Awake()
    {
        HealthIMG = GetComponent<Image>();
    }

    void Update()
    {
        HealthIMG.fillAmount = CurrentHp.HPFraction;
    }
}
