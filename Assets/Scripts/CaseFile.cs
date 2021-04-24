using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseFile : MonoBehaviour
{
    [SerializeField] private GameObject openedCaseFile;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void ShowCaseFile()
    {
        openedCaseFile.SetActive(true)
;    }
    public void HideCaseFile()
    {
        openedCaseFile.SetActive(false);
    }
}
