using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public Transform start, end;
    public float radius;
    public float damage = 10;
    Damagable self;

    void Awake()
    {
        enabled = false;
        self = GetComponentInParent<Damagable>();
    }

    void Update()
    {
        var colliders = Physics.OverlapCapsule(start.position, end.position, radius);

        foreach (var collider in colliders)
        {
            var damagable = collider.GetComponentInParent<Damagable>();
            if (!damagable || damagable == self)
                return;

            Debug.Log($"{transform.root.gameObject} dealing {damage} damage to {damagable}");
            damagable.DealDamage(damage);
            if (damagable.BloodPrefab)
            {
                var blood = Instantiate(damagable.BloodPrefab, end.position, Random.rotation);
                Destroy(blood, t: 5f);
            }
            enabled = false;
            return;
        }
    }

    void OnDrawGizmosSelected() => Gizmos.DrawRay(start.position, end.position - start.position);
}
