using UnityEngine;

[CreateAssetMenu]
public class Potion : Item
{
    public float hpRestored;
    public override void OnUse()
        => Debug.Log("potion was used");
}