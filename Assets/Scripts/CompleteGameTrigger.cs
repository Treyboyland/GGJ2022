using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteGameTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.GetComponentInChildren<PlayerAttack>();
        if (player != null)
        {
            GameManager.Manager.OnCompleteGame.Invoke();
        }
    }
}
