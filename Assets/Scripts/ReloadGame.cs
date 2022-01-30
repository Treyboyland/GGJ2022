using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    [Tooltip("Remember to inclue relative path if not in \"Scenes\" folder")]
    [SerializeField]
    string sceneName;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Reload"))
        {
            Debug.LogWarning("Reached Reload");
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
