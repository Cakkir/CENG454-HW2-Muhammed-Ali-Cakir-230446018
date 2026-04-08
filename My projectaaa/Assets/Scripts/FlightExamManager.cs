using UnityEngine;
using TMPro;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private TMP_Text statusText;
    [SerializeField] private TMP_Text missionText;

    private bool hasEnteredDangerZone = false;
    private bool threatCleared = false;

    private void Start()
    {
        UpdateHUD("Ready for takeoff.", "Enter the danger corridor.");
    }

    public void EnterDangerZone()
    {
        hasEnteredDangerZone = true;
        threatCleared = false;
        UpdateHUD("Entered a Dangerous Zone!", "Warning: hostile airspace.");
    }

    public void ExitDangerZone()
    {
        if (hasEnteredDangerZone)
        {
            threatCleared = true;
        }

        UpdateHUD("Threat cleared.", "You left the danger zone.");
    }

    public void MissileHit()
{
    UpdateHUD("Aircraft hit!", "Mission failed. Reset and try again.");
}

    private void UpdateHUD(string statusMessage, string missionMessage)
    {
        if (statusText != null)
        {
            statusText.text = statusMessage;
        }

        if (missionText != null)
        {
            missionText.text = missionMessage;
        }
    }

    public bool HasEnteredDangerZone()
    {
        return hasEnteredDangerZone;
    }

    public bool IsThreatCleared()
    {
        return threatCleared;
    }
}