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

    public void SetColor(bool blackWinner)
    {
        gameCamera.backgroundColor = blackWinner ? blackWins : whiteWins;
        text.faceColor = blackWinner ? whiteWins : blackWins;
    }
}
