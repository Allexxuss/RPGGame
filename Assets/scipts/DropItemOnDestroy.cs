using UnityEngine;

public sealed class DropItemOnDestroy : MonoBehaviour
{
    public GameObject itemToSpawn;

    public void OnDamagableDestroy()
    {
        if (Application.isPlaying)
            Instantiate(itemToSpawn.gameObject, transform.position + new Vector3(0, 1f, 0), transform.rotation);
    }
}