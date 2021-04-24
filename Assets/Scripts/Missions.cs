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
            "Rumble In The Jungle",
            "Our sources tell disturbing news from the deep jungle. Foreign intelligence agencies have sold guns to the enemies of our allies. Intercept the next shipment!",
            2,
            "Our agent tracked down and disarmed the arms dealers! $BEST_ITEM proved to be especially helpful. Local people were conflicted but they had no say in the matter.",
            "Few months later, lone traveller brings news that a foreigner had disappeared in bushes after a firefight. Only $WORST_ITEM had been found...",
            new Dictionary<string, int>
            {
                {"military_helmet", 2},
                {"goggles", 0},
                {"radio", 1},
                {"sturdy_boots", 1},
                {"snowshoes", -3},
                {"camo_pants", 2},
                {"sniper_scope", 2},
                {"poison_pill", -3},
                {"salt_shaker", -2},
                {"cross-country_skis", -3}
            }
        );
        missions.Add(mission);

        mission = new Mission(
            "Freight fright",
            "A giant container ship has spun out of control and blocked Suez Canal, a major passage of global trade. We need to do something! Although... Why does this keep happening?!",
            2,
            "After excruciating hours of digging sand with a tiny excavator, our agent, and her trusty $BEST_ITEM unblocked the ship and secured the billion-dollar merchandise aboard.",
            "Our agent was caught trying to bribe and official with $WORT_ITEM and was promptly escorted out of the target country. Disappointing, clearly more anti-corruption training is needed for our personnel.",
            new Dictionary<string, int>
            {
                {"military_helmet", 1},
                {"goggles", 1},
                {"radio", 1},
                {"sturdy_boots", 2},
                {"snowshoes", -2},
                {"camo_pants", 1},
                {"sniper_scope", -1},
                {"poison_pill", -2},
                {"salt_shaker", 2},
                {"cross-country_skis", -2}
            }
        );
        missions.Add(mission);
    }

    public Mission GetRandomMission()
    {
        return missions[Random.Range(0, missions.Count - 1)];
    }
}
