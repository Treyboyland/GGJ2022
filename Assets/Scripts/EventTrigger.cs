using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    [SerializeField]
    int cameraIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            GameManager.Manager.OnMoveCameraToPosition.Invoke(cameraIndex);
        }
    }
}
