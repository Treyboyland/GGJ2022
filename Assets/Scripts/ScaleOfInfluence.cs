using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOfInfluence : MonoBehaviour
{
    [SerializeField]
    Deity whiteDeity;

    [SerializeField]
    Deity blackDeity;

    [SerializeField]
    int maxSoulDiff;

    [SerializeField]
    FillLerp balance;

    [Tooltip("Less than x, more than y")]
    [SerializeField]
    Vector2 boundsForShake;

    public void TipScales()
    {
        int amount = whiteDeity.CurrentSouls - blackDeity.CurrentSouls;
        float fill = (1.0f / maxSoulDiff) * amount + 0.5f;
        bool startRift = fill <= boundsForShake.x || fill >= boundsForShake.y;
        GameManager.Manager.OnStartRift.Invoke(startRift);
        if (Mathf.Abs(amount) >= maxSoulDiff)
        {
            //True if dark deity wins
            GameManager.Manager.OnEndGame.Invoke(amount < 0);
        }
        balance.LerpToNewAmount(fill);
    }
}
