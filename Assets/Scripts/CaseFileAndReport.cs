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
        CaseFileController case_file_controller = GetComponent<CaseFileController>();
        case_file_controller.UpdateText();
        openedCaseFile.SetActive(true);
        camera_controller.canMove = false;
        if (camera_controller.game_status == gameState.incoming_mission)
        {
            camera_controller.game_status = gameState.mission_preparation;
        }
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
            ReportFileController report_file_controller = GetComponent<ReportFileController>();
            report_file_controller.ResolveMission();
        }
    }
    public void HideReport()
    {
        openedReport.SetActive(false);
        camera_controller.canMove = true;
        camera_controller.game_status = gameState.incoming_mission;
        camera_controller.ShowAgent();
        camera_controller.StartNewMission();
        RemoveOldReport();
    }

    private void RemoveOldReport()
    {
        // TODO change the sprite of the fax machine
        throw new NotImplementedException();
    }
}
