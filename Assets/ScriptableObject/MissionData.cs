using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MissionData", menuName = "Data/MissionData", order = 1)]
public class MissionData : ScriptableObject
{
    public string title;
    [TextArea(15,20)]
    public string caseFileDescription;
    public int difficulty;
    [TextArea(15,20)]
    public string winResult;
    [TextArea(15,20)]
    public string lossResult;
    public int military_helmet;
    public int goggles;
    public int radio;
    public int sturdy_boots;
    public int snowshoes;
    public int camo_pants;
    public int sniper_scope;
    public int poison_pill;
    public int salt_shaker;
    public int cross_country_skis;
    public int shotgun;
    public Dictionary<string, int> bazooka;
    public List<KeyValuePair<string, int>> bazooka_1;
}   