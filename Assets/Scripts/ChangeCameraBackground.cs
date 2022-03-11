using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeCameraBackground : MonoBehaviour
{
    [SerializeField]
    Camera gameCamera;

    [SerializeField]
    TMP_Text text;

    [SerializeField]
    Color blackWins;

    [SerializeField]
    Color whiteWins;

    [SerializeField]
    Color grayWins;

    public void SetColor(bool blackWinner)
    {
        gameCamera.backgroundColor = blackWinner ? blackWins : whiteWins;
        text.faceColor = blackWinner ? whiteWins : blackWins;
    }

    public void SetColorEnd()
    {
        gameCamera.backgroundColor = grayWins;
    }
}
