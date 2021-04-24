using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Report : MonoBehaviour
{
    [SerializeField] private GameObject openedReport;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ShowReport()
    {
        openedReport.SetActive(true)
;    }
    public void HideReport()
    {
        openedReport.SetActive(false);
    }
}
