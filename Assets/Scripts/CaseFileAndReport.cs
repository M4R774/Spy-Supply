using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles opening and closing both CaseFile and Report.
// Camera movement is blocked while viewing either.
public class CaseFileAndReport : MonoBehaviour
{
    [SerializeField] private Animator caseFileAnimator;
    [SerializeField] private GameObject openedCaseFile;
    [SerializeField] private Animator reportAnimator;
    [SerializeField] private GameObject openedReport;
    private CameraController camera_controller;
    public SoundEffectsController sound_effect_controller;
    // Move buttons
    [SerializeField] GameObject moveButtons;
    // Texts
    [SerializeField] private GameObject caseFileHeaderText;
    [SerializeField] private GameObject caseFileBodyText;
    [SerializeField] private GameObject caseFileImage;
    [SerializeField] private SceneLoader scene_loader;

    void Start()
    {
        camera_controller = Camera.main.GetComponent<CameraController>();
        moveButtons.SetActive(false);
        scene_loader = GetComponent<SceneLoader>();
    }

    public void ShowCaseFile()
    {
        caseFileAnimator.SetTrigger("opens");
        StartCoroutine(ShowTextDelay());

        CaseFileController case_file_controller = GetComponent<CaseFileController>();
        case_file_controller.UpdateText();
        openedCaseFile.SetActive(true);
        camera_controller.canMove = false;
        sound_effect_controller.PlayPaperSound();
        moveButtons.SetActive(false);
        if (camera_controller.game_status == gameState.incoming_mission)
        {
            camera_controller.game_status = gameState.mission_preparation;
            sound_effect_controller.PlayMissionBriefingSound();
        }
    }
    public void HideCaseFile()
    {
        caseFileAnimator.SetTrigger("closes");
        caseFileHeaderText.SetActive(false);
        caseFileBodyText.SetActive(false);
        caseFileImage.SetActive(false);
        moveButtons.SetActive(true);
        openedCaseFile.SetActive(false);
        camera_controller.canMove = true;
        sound_effect_controller.PlayPaperSound();
    }
    public void ShowReport()
    {
        if (camera_controller.game_status == gameState.mission_debriefing && reportAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "ReportIHasPrint")
        {
            openedReport.SetActive(true);
            camera_controller.canMove = false;
            ReportFileController report_file_controller = GetComponent<ReportFileController>();
            report_file_controller.ResolveMission();
            sound_effect_controller.PlayPaperSound();
        }
    }
    public void HideReport()
    {
        if (Stats.ThePlayerHasLost())
        {
            scene_loader.LoadEnding();
        }

        openedReport.SetActive(false);
        camera_controller.canMove = true;
        camera_controller.game_status = gameState.incoming_mission;
        camera_controller.ShowAgent();
        camera_controller.StartNewMission();
        sound_effect_controller.PlayPaperSound();
        // RemoveOldReport();
        moveButtons.SetActive(false);
        reportAnimator.SetTrigger("noprint");
    }

    public void HideMoveButtons()
    {
        moveButtons.SetActive(false);
    }

    private void RemoveOldReport()
    {
        // TODO change the sprite of the fax machine
        throw new NotImplementedException();
    }
    IEnumerator ShowTextDelay()
    {
        yield return new WaitForSeconds(1.5f);
        caseFileHeaderText.SetActive(true);
        caseFileBodyText.SetActive(true);
        caseFileImage.SetActive(true);
        yield return null;
    }
}
