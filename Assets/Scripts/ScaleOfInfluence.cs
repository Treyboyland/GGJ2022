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


    private void Start()
    {
        GameManager.Manager.OnFillAmountSet.Invoke(0.5f);
    }

    public void TipScales()
    {
        int amount = Mathf.Abs(whiteDeity.CurrentSouls - blackDeity.CurrentSouls);
        Debug.LogWarning("Diff: " + amount);
        float portion = Mathf.Lerp(0, 0.5f, 1.0f * amount / maxSoulDiff);
        portion *= blackDeity.CurrentSouls > whiteDeity.CurrentSouls ? -1 : 1;

        float fill = 0.5f + portion;
        bool startRift = fill <= boundsForShake.x || fill >= boundsForShake.y;
        Debug.LogWarning("Fill amount: " + fill);
        GameManager.Manager.OnStartRift.Invoke(startRift);
        GameManager.Manager.OnFillAmountSet.Invoke(fill);
        if (Mathf.Abs(amount) >= maxSoulDiff)
        {
            //True if dark deity wins
            GameManager.Manager.OnEndGame.Invoke(amount < 0);
        }
        balance.LerpToNewAmount(fill);
    }

}
