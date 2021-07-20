using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsUpdate : MonoBehaviour
{
    public GameController gameController;
    public TextMeshPro[] pointsTMP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(TextMeshPro pointTMP in pointsTMP)
        pointTMP.text = gameController.playerPoints.ToString();
    }
}
