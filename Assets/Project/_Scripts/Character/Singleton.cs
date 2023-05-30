using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; private set; }
    
    public Transform Transform { get; private set; }
    
    private void Awake()
    {
        Transform = GetComponent<Transform>();

        Instance = this;
        if(Instance != this) Destroy(gameObject);
    }
}
