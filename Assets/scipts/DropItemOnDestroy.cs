using System.Linq;
using UnityEngine;


public sealed class DropItemOnDestroy : MonoBehaviour
{
    public GameObject[] itemToSpawn;

    public void OnDamagableDestroy()
    {
        if (Application.isPlaying)
            Instantiate(itemToSpawn.FirstRandom(), transform.position + new Vector3(0, 1f, 0), transform.rotation);
    }

    void OnValidate()
    {
        if (itemToSpawn.Length == 0)
            Debug.LogError("ItemsToSpawn length is equal zero", this);

        int nullItems = itemToSpawn.Count(x => x == null);

        if (nullItems > 0)
            Debug.LogError($"{nullItems} items in ItemsToSpawn are null", this);
    }
}