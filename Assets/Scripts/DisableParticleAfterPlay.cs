using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableParticleAfterPlay : MonoBehaviour
{
    [SerializeField]
    ParticleSystem ps;

    private void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(WaitThenDisable());
        }
    }

    IEnumerator WaitThenDisable()
    {
        while (ps.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }



}
