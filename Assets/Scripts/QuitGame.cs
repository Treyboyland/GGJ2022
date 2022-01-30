using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class QuitGame : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quit"))
        {
            Debug.LogWarning("Reached Quit");
#if UNITY_STANDALONE
            Application.Quit();
#elif UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            //Do Nothing
#endif
        }
    }
}
