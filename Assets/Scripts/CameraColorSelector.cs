using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColorSelector : MonoBehaviour
{
    [SerializeField]
    Color normalColor;

    [SerializeField]
    Color specialColor;

    [SerializeField]
    float secondsToChange;

    [SerializeField]
    Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnMoveCameraToPosition.AddListener((index) =>
        {
            StopAllCoroutines();
            var color = index == 0 ? normalColor : specialColor;
            if (gameCamera.backgroundColor != color)
            {
                StartCoroutine(ColorLerp(color));
            }
        });
    }


    IEnumerator ColorLerp(Color endColor)
    {
        float elapsed = 0;
        Color startColor = gameCamera.backgroundColor;


        while (elapsed < secondsToChange)
        {
            elapsed+= Time.deltaTime;
            gameCamera.backgroundColor = Color.Lerp(startColor, endColor, elapsed / secondsToChange);
            yield return null;
        }
        gameCamera.backgroundColor = endColor;
    }
}
