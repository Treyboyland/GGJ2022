using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    [SerializeField]
    ParticlePool pool;

    public void SpawnParticle(Vector3 location)
    {
        var obj = pool.GetObject();
        obj.transform.position = location;
        obj.gameObject.SetActive(true);
    }
}
