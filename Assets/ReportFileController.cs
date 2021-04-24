using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ReportFileController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject header;
    public GameObject body;

    private CameraController camera_controller;
    TextMeshProUGUI header_text;
    TextMeshProUGUI body_text;

    void Awake()
    {
        camera_controller = cameraObject.GetComponent<CameraController>();
        header_text = header.GetComponent<TextMeshProUGUI>();
        body_text = body.GetComponent<TextMeshProUGUI>();
    }

    public void ResolveMission()
    {
        bool mission_success = camera_controller.current_mission.CalculateAndGetMissionResult();
        if (mission_success)
        {
            header_text.text = "MISSION SUCCESSFUL";
        }
        else
        {
            header_text.text = "MISSION FAILED";
        }
        body_text.text = camera_controller.current_mission.GetMissionResultText(mission_success);

        // TODO: Give option to choose reward
    }
}
