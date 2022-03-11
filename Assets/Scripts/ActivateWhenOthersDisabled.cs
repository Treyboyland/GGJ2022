using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWhenOthersDisabled : MonoBehaviour
{
    [SerializeField]
    GameObject toActivate;

    [SerializeField]
    List<GameObject> others;

    bool checkComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        toActivate.SetActive(false);
    }

    bool AreAnyActive()
    {
        foreach (var obj in others)
        {
            if (obj.activeInHierarchy)
            {
                return true;
            }
        }

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!checkComplete && !AreAnyActive())
        {
            checkComplete = true;
            toActivate.SetActive(true);
        }
    }
}
