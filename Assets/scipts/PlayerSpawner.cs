using UnityEngine;


[CreateAssetMenu]
public class PlayerSpawner : MonoBehaviour
{
    public GameObject prefab;
    public int CountofLife = 3;
    private GameObject instance;

    void Awake() => Update();

    void Update()
    {
        if(instance == null && CountofLife != 0)
        {
            instance = Instantiate(prefab, transform.position, transform.rotation);
            Object.FindObjectOfType<UnityStandardAssets.Cameras.FreeLookCam>().SetTarget(instance.transform);
            instance.GetComponent<CamRotation>().PosTarget = Object.FindObjectOfType<UnityStandardAssets.Cameras.FreeLookCam>().transform.GetChild(0);
            CountofLife--;
        }
    }
}