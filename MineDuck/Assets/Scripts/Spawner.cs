using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Collectible[] _objectsToPool;
    private List<Collectible> _spawnedObjects = new List<Collectible>();
    [SerializeField]
    private float _spawnTime = 6f;
    [SerializeField]
    private float _spawnRangeX = 10f;
    [SerializeField]
    private float _spawnRangeZ = 17f;
    [SerializeField]
    private int _amountToPool;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Transform _obsticles;
    
    private Vector3 _spawnPosition;
    private void Awake()
    {
        InstantiateObjects();
    }
    void Start()
    {
        InvokeRepeating("Spawn", _spawnTime, _spawnTime);
    }

    private void InstantiateObjects()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            var obsticle = Instantiate(_objectsToPool[UnityEngine.Random.Range(0, _objectsToPool.Length - 1)], _obsticles);
            _spawnedObjects.Add(obsticle);
            obsticle.gameObject.SetActive(false);
        }
    }

    private void Spawn()
    {
        GetSpawnPosition();
        var go = _spawnedObjects[Random.Range(0, _spawnedObjects.Count - 1)];
        if (!go.gameObject.activeSelf)
        {
            go.gameObject.transform.position = _spawnPosition;
            go.gameObject.SetActive(true);
        }
        else 
        {
           go = Instantiate(_objectsToPool[UnityEngine.Random.Range(0, _objectsToPool.Length - 1)], _spawnPosition, Quaternion.identity);
            _spawnedObjects.Add(go);
        }
    }

    private void GetSpawnPosition()
    {
        _spawnPosition.x = Random.Range(_target.position.x - _spawnRangeX, _target.position.x + _spawnRangeX);
        _spawnPosition.y = -0.5f;
        _spawnPosition.z = Random.Range(_target.position.z + _spawnRangeZ / 2, _target.position.z + _spawnRangeZ);
    }
}