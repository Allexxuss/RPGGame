using UnityEngine;
using UnityEngine.UI;

public class ArmorUI : MonoBehaviour
{
    public Image armor1, armor2, armor3;
    float velocity1, velocity2, velocity3;
    public float smoothTime = 0.2f;
    Damagable playerDamagable;
    Inventory playerInventory;


    void Awake()
    {
        playerDamagable = GetComponent<Damagable>();
        playerInventory = GetComponent<Inventory>();
    }

    void Start()
    {
        if (playerInventory.CurrentShield)
            UpdateArmorPoints(playerInventory.CurrentShield.ShieldPoints);
        else
            UpdateArmorPoints(0);
    }

    public void UpdateArmorPoints(int armorPoints)
    {
        armor1.transform.parent.gameObject.SetActive(false);
        armor2.transform.parent.gameObject.SetActive(false);
        armor3.transform.parent.gameObject.SetActive(false);

        if (armorPoints >= 1)
            armor1.transform.parent.gameObject.SetActive(true);

        if (armorPoints >= 2)
            armor2.transform.parent.gameObject.SetActive(true);

        if (armorPoints >= 3)
            armor3.transform.parent.gameObject.SetActive(true);
    }

    void Update()
    {
        var shield = playerInventory.CurrentShield;

        if (!shield)
            return;

        var hpPerPoint = shield.ShieldHpPerPoint;
        var current = shield.CurrentShieldHp;
        UpdateShieldHpBar(armor1, min: hpPerPoint * 0, max: hpPerPoint * 1, current, ref velocity1);
        UpdateShieldHpBar(armor2, min: hpPerPoint * 1, max: hpPerPoint * 2, current, ref velocity2);
        UpdateShieldHpBar(armor3, min: hpPerPoint * 2, max: hpPerPoint * 3, current, ref velocity3);
    }

    void UpdateShieldHpBar(Image bar, float min, float max, float current, ref float currentVelocity)
    {
        float t = Mathf.InverseLerp(min, max, current);
        
        bar.fillAmount = Mathf.SmoothDamp(
            current: bar.fillAmount,
            target: t,
            ref currentVelocity,
            smoothTime: smoothTime
        );
    }
}