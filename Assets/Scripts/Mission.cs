using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    // Case file
    public string title;
    public string description;
    public int difficulty;
    public string win_result;
    public string loss_result;
    public Dictionary<string, int> item_modifiers;

    // Player input
    public List<GameObject> luggage;

    // Mission outcome
    public List<GameObject> reward_items;

    public Mission(string title_parameter, 
        string description_parameter, 
        int difficulty_parameter, 
        string win_result_parameter, 
        string loss_result_parameter,
        Dictionary<string, int> item_modifiers_parameter) 
    {
        title = title_parameter;
        description = description_parameter;
        difficulty = difficulty_parameter;
        win_result = win_result_parameter;
        loss_result = loss_result_parameter;
        item_modifiers = item_modifiers_parameter;
        luggage.Clear();
        reward_items.Clear();
    }

    
    // Mission constructor without input parameters for testing purposes
    public Mission()
    {
        title = "testi missio ilman inputtia";
        description = "Koska mission constructeria kutsuttiin ilman input parametreja, luotiin tyhjä missio testaamista varten. Tehtävän vaikeustaso on 2.";
        difficulty = 2;
        win_result = "VOITIT PELIN!";
        loss_result = "hävisit pelin :(";
        item_modifiers = new Dictionary<string, int>();  // empty
        luggage.Clear();
        reward_items.Clear();
    }

    public void AddItemToLuggage(GameObject item_to_be_added)
    {
        luggage.Add(item_to_be_added);
    }

    public bool CalculateAndGetMissionResult()
    {
        // TODO:
        return true;
        /*     
        Item List (Modifiers: -3 to +3)
        1. Gun +1
        2. Snowshoe -3
        3. Safari helmet +3
        (4.) Torch +1
        (5.) Bulletproof vest +3

        sum(items) = 1
        max_modifier = 3
        max_items = 3
        difficulty = 2
        max_difficulty = 5

        odds = (1 - difficulty / (2 * max_difficulty)) + sum(items) * difficulty / (2 * max_difficulty) / (max_modifier * max_items)
            = (1 - 0.2) + 3 * + 0.2 / (3 * 3) = 0.86 = 86 % chance of success
        */
    }
}
