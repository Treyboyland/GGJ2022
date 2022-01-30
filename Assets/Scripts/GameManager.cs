using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent<Vector3> OnEnemyDefeatedAtLocation = new UnityEvent<Vector3>();

    public UnityEvent OnPlayerDonatedSouls = new UnityEvent();

    public UnityEvent OnPlayerAttacked = new UnityEvent();

    static GameManager _instance;

    public static GameManager Manager { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
    }
}
