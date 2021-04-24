using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles opening and closing both CaseFile and Report.
// Camera movement is blocked while viewing either.
public class CaseFileAndReport : MonoBehaviour
{
    [SerializeField] private GameObject openedCaseFile;
    [SerializeField] private GameObject openedReport;
    [SerializeField] private Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        
    }
    public void ShowCaseFile()
    {
        openedCaseFile.SetActive(true);
        cam.GetComponent<CameraController>().canMove = false;
    }
    public void HideCaseFile()
    {
        openedCaseFile.SetActive(false);
        cam.GetComponent<CameraController>().canMove = true;
    }
    public void ShowReport()
    {
        openedReport.SetActive(true);
        cam.GetComponent<CameraController>().canMove = false;
    }
    public void HideReport()
    {
        openedReport.SetActive(false);
        cam.GetComponent<CameraController>().canMove = true;
    }
}
