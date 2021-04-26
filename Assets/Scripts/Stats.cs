using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Stats
{
    public static int number_of_successful_misisons;
    public static int number_of_failed_misisons;

    static Stats()
    {
        ResetStats();
    }

    public static void MissionSuccessful()
    {
        number_of_successful_misisons++;
    }

    public static void MissionFailed()
    {
        number_of_failed_misisons++;
    }

    public static bool ThePlayerHasLost()
    {
        if (number_of_failed_misisons >= 3)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void ResetStats()
    {
        number_of_successful_misisons = 0;
        number_of_failed_misisons = 0;
    }
}
