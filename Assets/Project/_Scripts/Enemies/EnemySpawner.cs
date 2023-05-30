using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _respawnDelayInSeconds;

    private GameObject _currentEnemyObject;
    private Enemy _currentEnemy;

    public event Action EnemyDeadEvent;

    private void Start() => Respawn();

    private void Respawn()
    {
        if (_currentEnemyObject != null)
            Destroy(_currentEnemyObject);

        _currentEnemyObject = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity);
        _currentEnemy = _currentEnemyObject.GetComponent<Enemy>();

        _currentEnemy.DiedEvent += OnEnemyDie;
    }

    private void OnEnemyDie(Vector3 deathPosition)
    {
        _currentEnemy.DiedEvent -= OnEnemyDie;
        EnemyDeadEvent?.Invoke();

        StartCoroutine(RespawnWithDelay(_respawnDelayInSeconds));
    }

    private IEnumerator RespawnWithDelay(float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);
        
        Respawn();
    }
}