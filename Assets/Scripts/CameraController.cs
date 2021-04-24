using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float caseFilePos;
    [SerializeField] private float itemsPos;
    [SerializeField] private float reportsPos;
    [SerializeField] private float cameraSpeed;
    [SerializeField] private Coroutine thisCoroutine;

    void Start()
    {
       cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            MoveToCaseFile();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            MoveToItems();
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            MoveToReports();
        }
    }
    public void MoveToCaseFile()
    {
        StopAllCoroutines();
        thisCoroutine = null;
        thisCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, caseFilePos));
    }
    public void MoveToItems()
    {
        StopAllCoroutines();
        thisCoroutine = null;
        thisCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, itemsPos));
    }
    public void MoveToReports()
    {
        StopAllCoroutines();
        thisCoroutine = null;
        thisCoroutine = StartCoroutine(MoveCamera(cam.transform.position.x, reportsPos));
    }

    IEnumerator MoveCamera(float startPos, float endPos)
    {
        float timeElapsed = 0;
        float newPos = 0;
        while(timeElapsed < cameraSpeed)
        {
            newPos = Mathf.Lerp(startPos, endPos, timeElapsed/cameraSpeed);
            cam.transform.position = new Vector3(newPos,0,0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        newPos = endPos;
        cam.transform.position = new Vector3(newPos,0,0);
        yield return null;
    }
}
