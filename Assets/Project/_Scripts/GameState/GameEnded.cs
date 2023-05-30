using System;
using UnityEngine;

[RequireComponent(typeof(GameState))]
public class GameEnded : MonoBehaviour
{
    private GameState _gameState;

    [SerializeField] private GameObject _endMenu;
    [SerializeField] private GameObject[] _objectsToDestroy;

    private void Awake() => _gameState = GetComponent<GameState>();

    private void OnGameEnded()
    {
        _endMenu.SetActive(true);
        Array.ForEach(_objectsToDestroy, x => x.SetActive(false));
        UnlockCursor();
    }

    private void UnlockCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void OnEnable() => _gameState.GameEndedEvent += OnGameEnded;
    private void OnDisable() => _gameState.GameEndedEvent -= OnGameEnded;
}