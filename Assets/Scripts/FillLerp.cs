using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillLerp : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    float secondsToLerp;

    float target = 0.5f;

    public void LerpToNewAmount(float newAmount)
    {
        target = newAmount;
        StopAllCoroutines();
        StartCoroutine(Transition());
    }


    IEnumerator Transition()
    {
        float time = 0;
        float start = image.fillAmount;

        while (time < secondsToLerp)
        {
            time += Time.deltaTime;
            image.fillAmount = Mathf.Lerp(start, target, time / secondsToLerp);
            yield return null;
        }

        image.fillAmount = target;
    }
}
