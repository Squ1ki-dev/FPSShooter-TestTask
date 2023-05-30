using UnityEngine;
using TMPro;

public class EnemiesDeathCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private TMP_Text _deathCountText;

    private int _deathCount;

    private void Start() => Init();

    private void Init()
    {
        _deathCount = 0;
        UpdateDeathCountText();
    }

    private void OnEnemyDie()
    {
        _deathCount++;
        UpdateDeathCountText();
    }

    private void UpdateDeathCountText() => _deathCountText.text = _deathCount.ToString();
    
    private void OnEnable() => _enemySpawner.EnemyDeadEvent += OnEnemyDie;
    private void OnDisable() => _enemySpawner.EnemyDeadEvent -= OnEnemyDie;
}
