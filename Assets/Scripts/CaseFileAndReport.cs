using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles opening and closing both CaseFile and Report.
// Camera movement is blocked while viewing either.
public class CaseFileAndReport : MonoBehaviour
{
    [SerializeField] private GameObject openedCaseFile;
    [SerializeField] private GameObject openedReport;
    private CameraController camera_controller;
    void Start()
    {
        camera_controller = Camera.main.GetComponent<CameraController>();
    }

    public void ShowCaseFile()
    {
        openedCaseFile.SetActive(true);
        camera_controller.canMove = false;
    }
    public void HideCaseFile()
    {
        openedCaseFile.SetActive(false);
        camera_controller.canMove = true;
    }
    public void ShowReport()
    {
        if (camera_controller.game_status == gameState.mission_debriefing)
        {
            openedReport.SetActive(true);
            camera_controller.canMove = false;
        }
        ReportFileController report_file_controller = openedReport.GetComponentInChildren<ReportFileController>();
        report_file_controller.ResolveMission();
    }
    public void HideReport()
    {
        openedReport.SetActive(false);
        camera_controller.canMove = true;
        RemoveOldReport();
        camera_controller.game_status = gameState.incoming_mission;
        // TODO give new mission? Or maybe this should be done in the casefilecontroller?
    }

    private void RemoveOldReport()
    {
        // TODO change the sprite of the fax machine and make it
        // not clickable
        throw new NotImplementedException();
    }
}
