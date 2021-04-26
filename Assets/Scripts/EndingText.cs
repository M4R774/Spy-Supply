using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndingText : MonoBehaviour
{
    TextMeshProUGUI body;

    void Awake()
    {
        body = GetComponent<TextMeshProUGUI>();
        body.text =
        "The resent failures of our agents around the globe has lead to the disbanding of the whole Secret Agent Service, including the armoury.\n\nSuccessful missions: " + Stats.number_of_successful_misisons + "\nFailed Missions: " + Stats.number_of_failed_misisons;
    }
}
