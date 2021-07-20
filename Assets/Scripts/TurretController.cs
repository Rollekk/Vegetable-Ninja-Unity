using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform canonPoint;
    public GameObject[] vegiesToSpawn;

    private float VegeDelayMin = 4.0f;
    private float VegeDelayMax = 6.0f;
    private float TotalGameTime = 30.0f;
    private int vegieIndex = 0;
    public float forceValue = 10.0f;

    public bool EndGame = true;
    public bool isGameOn = false;

    public enum Difficulty {Easy, Medium, Hard};
    public Difficulty difficulty;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        StartCoroutine(StartLoop());
    }

    IEnumerator StartLoop()
    {
        if(!isGameOn)
        {
            isGameOn = true;
            EndGame = false;
            Invoke("StopGame", TotalGameTime);
            while (!EndGame)
            {
                yield return new WaitForSeconds(Random.Range(VegeDelayMin, VegeDelayMax));
                SpawnVegies();
            }
        }

    }

    void SpawnVegies()
    {
        vegieIndex = Random.Range(0, vegiesToSpawn.Length);
        GameObject go = Instantiate(vegiesToSpawn[vegieIndex], canonPoint.position, canonPoint.rotation);
        VegieController goVegie = go.GetComponent<VegieController>();
        goVegie.canonPoint = canonPoint;
        goVegie.forceValue = forceValue;
    }

    void StopGame()
    {
        EndGame = true;
        isGameOn = false;
    }

    public void ChangeDifficulty(Difficulty difficulty)
    {
        if(difficulty == Difficulty.Easy)
        {
            difficulty = Difficulty.Easy;
            VegeDelayMin = 4.0f;
            VegeDelayMax = 6.0f;
        }
        else if(difficulty == Difficulty.Medium)
        {
            difficulty = Difficulty.Medium;
            VegeDelayMin = 3.0f;
            VegeDelayMax = 5.0f;
        }
        else
        {
            difficulty = Difficulty.Hard;
            VegeDelayMin = 1.0f;
            VegeDelayMax = 3.0f;
        }
    }
}
