using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour {

    public float cooldown = 0.3f;

    private float currentCooldown;

    public List<GameObject> strings = new List<GameObject>();

    public GameObject notePrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        currentCooldown -= Time.deltaTime;

        if (currentCooldown < 0)
        {
            SpawnNote(Random.Range(0, strings.Count));
            currentCooldown = cooldown;
        }

	}

    void SpawnNote(int stringIndex)
    {
        GameObject spawnedNote = Instantiate(notePrefab, strings[stringIndex].transform.position, new Quaternion());
    }
}
