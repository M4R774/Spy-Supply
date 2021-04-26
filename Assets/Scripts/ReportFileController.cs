using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class ReportFileController : MonoBehaviour
{
    public GameObject cameraObject;
    public GameObject header;
    public GameObject body;

    private CameraController camera_controller;
    TextMeshProUGUI header_text;
    TextMeshProUGUI body_text;

    [SerializeField] private Inventory inventory;

    void Awake()
    {
        camera_controller = cameraObject.GetComponent<CameraController>();
        header_text = header.GetComponent<TextMeshProUGUI>();
        body_text = body.GetComponent<TextMeshProUGUI>();
    }

    public void ResolveMission()
    {
        float mission_odds = camera_controller.current_mission.CalculateMissionFinalOdds();
        float to_beat = (float) UnityEngine.Random.Range(0, 101) / 100;
        bool mission_success = mission_odds >= to_beat;

        Dictionary<int, string> possible_moods = new Dictionary<int, string>
            {
                {-10, "You did everything right but failed."},
                {-9, "You did everything right but failed."},
                {-8, "So unlucky!"},
                {-7, "Tough luck!"},
                {-6, "Tough luck!"},
                {-5, "Unfortunate but it happens."},
                {-4, "Unfortunate but it happens."},
                {-3, "It was a tough ask."},
                {-2, "It was a tough ask."},
                {-1, "It was impossible..."},
                {0, "It was impossible..."},
                {1, "Very Lucky!"},
                {2, "You beat the odds!"},
                {3, "You beat the odds!"},
                {4, "It was a coin flip!"},
                {5, "It was a coin flip!"},
                {6, "Nice one!"},
                {7, "Good job!"},
                {8, "Well prepared!"},
                {9, "Easy peasy!"},
                {10, "Quaranteed win."}
            };

        string mood = "";

        if (mission_success)
        {
            Stats.MissionSuccessful();
            header_text.text = "MISSION SUCCESSFUL";
            int moodkey = (int) Math.Floor(mission_odds * 10);
            possible_moods.TryGetValue(moodkey, out string real_mood);
            mood = mood+" "+real_mood;
        }
        else
        {
            Stats.MissionFailed();
            header_text.text = "MISSION FAILED";
            int moodkey = (int) Math.Ceiling(mission_odds * -10);
            possible_moods.TryGetValue(moodkey, out string real_mood);
            mood = mood+" "+real_mood;
        }
        body_text.text = camera_controller.current_mission.GetMissionResultText(mission_success)+mood;

        // TODO: Give option to choose reward
        inventory.BulkAddRandomItemToEmptySlot(1);
    }
}
