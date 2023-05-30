using System;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private Character _character;

    public event Action GameEndedEvent;

    private void OnPlayerDeath() => GameEndedEvent?.Invoke();
    private void OnEnable() => _character.DeathEvent += OnPlayerDeath;
    private void OnDisable() => _character.DeathEvent -= OnPlayerDeath;
}
