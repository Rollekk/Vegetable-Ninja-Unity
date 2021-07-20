using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public TurretController[] turrets;
    public Camera playerCamera;
    public LayerMask uiMask;
    public int playerPoints;

    private enum DominantHand {Left, Right};
    private DominantHand dominantHand = DominantHand.Left;

    public TextMeshPro difficultyTMP;
    public TextMeshPro handTMP;
    public TextMeshPro[] dominantHandTMP;

    // Start is called before the first frame update
    void Start()
    {
       HideHand(dominantHandTMP[0]);
       HideHand(dominantHandTMP[1]);
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, 500.0f, uiMask))
        {
            if (dominantHand == DominantHand.Left) ShowHand(dominantHandTMP[0]);
            else ShowHand(dominantHandTMP[1]);
        }
        else
        {
            HideHand(dominantHandTMP[0]);
            HideHand(dominantHandTMP[1]);
        }
    }

    public void StartButtonPressed()
    {
        foreach(TurretController turret in turrets)
        {
            turret.StartGame();
        }
    }

    public void UpdateDifficultyText(TurretController.Difficulty difficulty)
    {
        difficultyTMP.text = difficulty.ToString();
    }

    public void ChangeHand()
    {
        if (dominantHand == DominantHand.Left)
        {
            dominantHand = DominantHand.Right;
        }
        else
        {
            dominantHand = DominantHand.Left;
        }
        UpdateHandText(dominantHand);
    }

    private void UpdateHandText(DominantHand dominantHand)
    {
        handTMP.text = dominantHand.ToString();
    }

    private void HideHand(TextMeshPro textMeshPro)
    {
        textMeshPro.enabled = false;
    }

    private void ShowHand(TextMeshPro textMeshPro)
    {
        textMeshPro.enabled = true;
    }
}
