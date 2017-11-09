using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
	
	// Spawnee = Resources.Load("Mook");
	// Use this for initialization
	public GameObject hazardAv;
    public GameObject hazardSpeedy;
    public GameObject hazardHeavy;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
    public List<GameObject> allHazards;

	void Start ()
	{
		StartCoroutine (SpawnWaves ());
		hazardAv = Resources.Load("Mook") as GameObject;
        hazardHeavy = Resources.Load("Heavy") as GameObject;
        hazardSpeedy = Resources.Load("Speedy") as GameObject;
        hazardCount = 5;
		spawnValues = gameObject.transform.position;
		spawnWait = 1.0f;
		startWait = 2.0f;
		waveWait = 2.0f;
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
                if (i % 2 == 0)
                {
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazardSpeedy, spawnValues, spawnRotation);
                }
                else
                {
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazardAv, spawnValues, spawnRotation);
                    
                }
                yield return new WaitForSeconds(spawnWait);

            }

			yield return new WaitForSeconds(waveWait);
		}
	}

	// Update is called once per frame
	void Update ()
	{

	}
}
