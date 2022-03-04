using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnHazards : MonoBehaviour {

    [SerializeField]
    private float minX = 0.0f;
    [SerializeField]
    private float maxX = 0.0f;
    [SerializeField]
    private GameObject[] hazards;    //Потенциальный массив с кубиками
    [SerializeField]
    private float timeBetweenSpawn = 0.0f;
    private bool canSpawn = false;
    private int amountOfHazardsToSpawn = 0;
    private int hazardToSpawn = 0;
    private UIFunctions uiFunctions;

    // Use this for initialization
    void Start () {
        uiFunctions = GameObject.FindGameObjectWithTag("GameManager").GetComponent<UIFunctions>();
        canSpawn = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (canSpawn == true && uiFunctions.gameStarted == true)
        {
            StartCoroutine("GenerateHazard");
        }
	}

    private IEnumerator GenerateHazard()
    {
        canSpawn = false;
        timeBetweenSpawn = Random.Range(0.5f, 2.0f);
        amountOfHazardsToSpawn = Random.Range(1, 6);

        for(int i = 0; i < amountOfHazardsToSpawn; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), 4.0f, 0.0f);
            Instantiate(hazards[hazardToSpawn], spawnPos, Quaternion.identity);
        }

        yield return new WaitForSeconds(timeBetweenSpawn);
        canSpawn = true;
    }
}
