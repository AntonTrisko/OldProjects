using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler<T> : MonoBehaviour where T : MonoBehaviour
{
    public static int objectID = 1;
    private List<T> pooledObjects;
    private T _objectToPool;
    private int _amountToPool;
    private bool _shouldExpand;
    private GameObject _container;
  

    public ObjectPooler(GameObject container,T objectToPool, int amountToPool, bool shouldExpand)
    {
        _container = container;
        _objectToPool = objectToPool;
        _amountToPool = amountToPool;
        _shouldExpand = shouldExpand;
        Init();
    }
    public void Init()
    {
        pooledObjects = new List<T>();
        for (int i = 0; i < _amountToPool; i++)
        {
            T obj = Instantiate(_objectToPool,_container.transform);
            obj.name = _objectToPool.name + objectID;
            objectID++;
            obj.gameObject.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public T GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].gameObject.activeSelf)
            {
                pooledObjects[i].gameObject.SetActive(true);
                return pooledObjects[i];
            }
        }
        if (_shouldExpand)
        {
            T obj = Instantiate(_objectToPool,_container.transform);
            obj.name = _objectToPool.name + objectID;
            objectID++;
            obj.gameObject.SetActive(true);
            pooledObjects.Add(obj);
            return obj;
        }
        else
        {
            return null;
        }
    }
}
