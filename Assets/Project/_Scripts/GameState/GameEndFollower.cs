using System;
using UnityEngine;

public class GameEndFollower : MonoBehaviour
{
    private void Start() => GameStateSingleton.Instance.GameState.GameEndedEvent += OnGameEnd;

    private void OnDestroy() => GameStateSingleton.Instance.GameState.GameEndedEvent -= OnGameEnd;

    private void OnGameEnd() => gameObject.SetActive(false);
}
