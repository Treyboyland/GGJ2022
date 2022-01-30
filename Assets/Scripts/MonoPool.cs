using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField]
    T prefab;

    List<T> pool = new List<T>();

    T CreateObject()
    {
        var inst = Instantiate(prefab, transform);
        inst.gameObject.SetActive(false);
        return inst;
    }

    public bool AnyActive()
    {
        foreach (var p in pool)
        {
            if (p.gameObject.activeInHierarchy)
            {
                return true;
            }
        }


        return false;
    }


    public T GetObject()
    {
        foreach (var p in pool)
        {
            if (!p.gameObject.activeInHierarchy)
            {
                return p;
            }
        }

        return CreateObject();
    }
}
