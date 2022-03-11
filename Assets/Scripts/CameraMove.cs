using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    int currentCameraIndex;

    int startingTransitionIndex = int.MinValue;

    [SerializeField]
    List<Vector2> cameraPositions;

    [SerializeField]
    float secondsToMove;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnMoveCameraToPosition.AddListener(index =>
        {
            if (index != startingTransitionIndex)
            {
                StartCoroutine(LerpToPosition(index));
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator LerpToPosition(int index)
    {
        //Debug.LogWarning("Index: " + index + " Num Positions: " + cameraPositions.Count);
        startingTransitionIndex = index;
        Vector3 newPos = cameraPositions[index];
        newPos.z = transform.position.z;

        Vector3 startPos = transform.position;

        float elapsed = 0;

        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, newPos, elapsed / secondsToMove);
            yield return null;
        }

        transform.position = newPos;


        currentCameraIndex = index;
        startingTransitionIndex = int.MinValue;
    }
}
