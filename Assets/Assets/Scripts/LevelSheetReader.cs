using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSheetReader : MonoBehaviour
{
    public List<TextAsset> textAssets;
    public NoteSpawner noteSpawner;

    private List<List<string>> songList = new List<List<string>>();

    void Start()
    {
        //loadLevelData(asset.text, new LoadCallback('N', HelloN));

        #region loadAllLevels
        for (int ta = 0; ta < textAssets.Count; ta++)
        {

            List<string> newSong = new List<string>();

            songList.Add(newSong);

            print(textAssets[ta].text);

            var lines = textAssets[ta].text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                var str = lines[i];

                string result = "";

                for (int c = 0; c < str.Length; c++)
                {
                    var input = str[c];
                    if (input == 'N')
                    {
                        result += c.ToString();
                    }
                    else if (input == 'O')
                    {

                    }
                }

                songList[ta].Add(result);

            }

        }

        #endregion

        //select a random level from all loaded ones.
        int n = UnityEngine.Random.Range(0, songList.Count);
        noteSpawner.setCurrentSong(songList[n]);

    }

    #region Emil Stuff

    private void HelloN(int lN, int cN)
    {
        Debug.LogFormat("C is on line : {0} character :{1}", lN, cN);
    }

    private static void loadLevelData(string text, params LoadCallback[] callback)
    {
        string[] lines = text.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

        for (int lN = 0; lN < lines.Length; lN++)
        {
            for (int cN = 0; cN < lines[lN].Length; cN++)
            {
                for (int i = 0; i < callback.Length; i++)
                {
                    if (lines[lN][cN] == callback[i].triggerCharater)
                    {
                        callback[i].callbackFun.Invoke(lN, cN);
                        break;
                    }
                }
            }
        }
    }

    struct LoadCallback
    {
        public readonly char triggerCharater;
        public readonly Action<int, int> callbackFun;

        public LoadCallback(char triggerCharater, Action<int, int> callbackFun)
        {
            this.triggerCharater = triggerCharater;
            this.callbackFun = callbackFun;
        }
    }

    #endregion
}