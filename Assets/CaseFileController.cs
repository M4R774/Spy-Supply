using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CaseFileController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject header;
    public GameObject body;
    
    void Awake()
    {
        CameraController camera_controller = cameraObject.GetComponent<CameraController>();
        
        TextMeshProUGUI header_text = header.GetComponent<TextMeshProUGUI>();
        header_text.text = camera_controller.current_mission.title;

        TextMeshProUGUI boxy_text = body.GetComponent<TextMeshProUGUI>();
        boxy_text.text = camera_controller.current_mission.description;
    }
}
