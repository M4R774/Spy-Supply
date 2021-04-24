using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missions : MonoBehaviour
{
    public List<Mission> missions;

    // Start is called before the first frame update
    void Awake()
    {
        Mission mission = new Mission();  // Test mission
        missions.Add(mission);
        
        mission = new Mission(
            "Title",
            "description",
            2,
            "win_result",
            "loss_result",
            new Dictionary<string, int>
            {
                {"helmet", 1},
                {"radio", -3}
            }
        );
        missions.Add(mission);
    }

    public Mission GetRandomMission()
    {
        return missions[Random.Range(0, missions.Count - 1)];
    }
}
