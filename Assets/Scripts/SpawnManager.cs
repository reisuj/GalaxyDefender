using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private bool _playerisAlive = true;    
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _enemyContainer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (_playerisAlive)
        {
            float randomX = Random.Range(-9.0f, 9.0f);
            GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(randomX, 8.0f, 0), Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(5.0f);
        }
    }

    public void PlayerIsDead()
    {
        _playerisAlive = false;
    }
}
