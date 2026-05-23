using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> PooledObjects;
    public GameObject ObjectToPool;
    public int AmountToPool;
    void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject temp;
        for(int i = 0; i < AmountToPool; i++)
        {
            temp = Instantiate(ObjectToPool);
            temp.SetActive(false);
            PooledObjects.Add(temp);
        }
    }

    // Update is called once per frame

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < AmountToPool; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        return null;
    }
}
