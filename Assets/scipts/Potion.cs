using UnityEngine;

[CreateAssetMenu]
public class Potion : Item
{
    public float HPRestored;
    public float ShieldRestored;
    public override void OnUse()
        => Debug.Log("potion was used");
}