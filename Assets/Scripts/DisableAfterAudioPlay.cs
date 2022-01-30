using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableAfterAudioPlay : MonoBehaviour
{
    [SerializeField]
    AudioSource source;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(PlayThenDisable());
        }
    }

    IEnumerator PlayThenDisable()
    {
        source.Play();
        while (source.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
