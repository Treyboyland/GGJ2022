using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    List<Color> colors;

    [SerializeField]
    float secondsBetweenTransitions;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorLoop());
    }

    IEnumerator ColorLoop()
    {
        int currentIndex = 0;
        while (true)
        {
            Color start = colors[currentIndex];
            int nextColor = (currentIndex + 1) % colors.Count;
            Color end = colors[nextColor];

            float elapsed = 0;
            while (elapsed < secondsBetweenTransitions)
            {
                elapsed += Time.deltaTime;
                sprite.color = Color.Lerp(start, end, elapsed / secondsBetweenTransitions);
                yield return null;
            }

            currentIndex = nextColor;
        }
    }
}
