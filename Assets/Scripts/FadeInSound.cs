using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInSound : MonoBehaviour
{
    [SerializeField]
    float maxSoundLevel;

    [SerializeField]
    float secondsToChange;

    [SerializeField]
    AudioSource source;

    bool started = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlaySound(bool start)
    {
        if (start && !started)
        {
            StopAllCoroutines();
            StartCoroutine(Fade(source.volume, maxSoundLevel, start));
        }
        else if (!start && started)
        {
            StopAllCoroutines();
            StartCoroutine(Fade(source.volume, 0, start));
        }
    }

    IEnumerator Fade(float start, float end, bool val)
    {
        float time = 0;
        while (time < secondsToChange)
        {
            time += Time.deltaTime;
            source.volume = Mathf.Lerp(start, end, time / secondsToChange);
            yield return null;
        }

        source.volume = end;
        started = val;
    }
}
