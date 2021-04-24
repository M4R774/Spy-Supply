using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    [TextArea(5,10)]
    public string description;

    Item(string name_parameter, string description_parameter)
    {
        name = name_parameter;
        description = description_parameter;
    }

    // For testing
    Item()
    {
        name = "testi itemi";
        description = "rakentajalle ei annettu parametreja joten luotiin vain tyhjä itemi";
    }

    public string GetName()
    {
        return name;
    }
}
