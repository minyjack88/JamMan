using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoteSpawner : MonoBehaviour {


    public List<GameObject> strings = new List<GameObject>();
    public GameObject notePrefab;
    public float SongTempo = 120;
    public LevelSheetReader levelReader;

    private List<List<string>> _songList;
    private float currentCooldown;
    private float tickSpeed;
    private List<string> currentSong = new List<string>();
    private int currentTickIndex = 0;
    private List<int> notesToPlay = new List<int>();
    private string currentLine;
    public bool songIsPlaying;

    // Use this for initialization
    void Start() {

        tickSpeed = 60 / SongTempo / 4;
        Debug.LogFormat("At BBM {0}, tick speed is {1}", SongTempo, tickSpeed);

        StartCoroutine(spawnNotes());

    }

    // Update is called once per frame
    void Update () {


	}

    void SpawnNote(List<int> notes)
    {
        foreach (int item in notes)
        {
            Instantiate(notePrefab, strings[item].transform.position, new Quaternion());
        }

    }

    IEnumerator spawnNotes()
    {
        while (true)
        {
            if (songIsPlaying)
            { 
                currentLine = currentSong[currentTickIndex];
                notesToPlay.Clear();

                foreach (char item in currentLine)
                {
                    int currentNote;

                    if (int.TryParse(item.ToString(), out currentNote))
                    {
                        notesToPlay.Add(currentNote);
                    }
                }

                SpawnNote(notesToPlay);

                currentTickIndex++;

                if (currentTickIndex > currentSong.Count - 1)
                {
                    currentTickIndex = 0;
                }

            }
            yield return new WaitForSeconds(tickSpeed);
        }
    }

    public void setCurrentSong(List<string> song)
    {
        currentSong = song;

        if (!songIsPlaying)
            songIsPlaying = true;
    }
}
