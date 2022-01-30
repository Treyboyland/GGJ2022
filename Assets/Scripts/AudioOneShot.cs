using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOneShot : MonoBehaviour
{
    [SerializeField]
    MonoPool<DisableAfterAudioPlay> pool;

    public void PlayAudio()
    {
        var obj = pool.GetObject();
        obj.gameObject.SetActive(true);
    }
}
