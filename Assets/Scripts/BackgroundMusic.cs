using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField]
    MusicLoop normalAudio;

    [SerializeField]
    MusicLoop bitAudio;

    [SerializeField]
    AnimationCurve audioCurve;

    static BackgroundMusic _instance = null;

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Debug.LogWarning("Destroy: " + gameObject.name);
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        //Takes 2 arguments (current scene, scene that is getting loaded)
        SceneManager.activeSceneChanged += (unused, unused2) =>
        {
            GameManager.Manager.OnFillAmountSet.AddListener(SetAudioLevel);
            GameManager.Manager.OnMoveCameraToPosition.AddListener(BonusMusicTrack);
        };
    }


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnFillAmountSet.AddListener(SetAudioLevel);
        GameManager.Manager.OnMoveCameraToPosition.AddListener(BonusMusicTrack);
    }

    void BonusMusicTrack(int index)
    {
        if (index != 0)
        {
            normalAudio.Volume = normalAudio.MaxVolume * .75f;
            bitAudio.Volume = bitAudio.MaxVolume * 1.25f;
        }
        else
        {
            SetAudioLevel(0.5f);
        }
    }

    void SetAudioLevel(float fill)
    {
        float volume = audioCurve.Evaluate(fill);
        normalAudio.Volume = normalAudio.MaxVolume * volume;
        bitAudio.Volume = bitAudio.MaxVolume * (1 - volume);
    }
}
