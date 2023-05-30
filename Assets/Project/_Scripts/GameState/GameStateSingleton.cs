using UnityEngine;

[RequireComponent(typeof(GameState))]
public class GameStateSingleton : MonoBehaviour
{
    public static GameStateSingleton Instance { get; private set; }
    
    public GameState GameState { get; private set; }
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        GameState = GetComponent<GameState>();
    }
}
