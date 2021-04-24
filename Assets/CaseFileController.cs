using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaseFileController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject header;
    public GameObject body;

    public CameraController camera_controller;
    public TextMeshProUGUI header_text;
    public TextMeshProUGUI body_text;
    
    void Start()
    {
        Debug.Log("jippii");
        camera_controller = cameraObject.GetComponent<CameraController>(); 
        header_text = header.GetComponent<TextMeshProUGUI>();
        body_text = body.GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        body_text.text = camera_controller.current_mission.description;
        header_text.text = camera_controller.current_mission.title;
    }
}
