using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    private void Awake()
    {
        entryContainer = transform.Find("HighScoreEntryContainer");
        entryTemplate = entryContainer.Find("HighScoreEntryTemplate");
       
        entryTemplate.gameObject.SetActive(false);
        //highScoreEntryList = new List<HighScoreEntry>()
        //{
        //    new HighScoreEntry{score = 100,name = "Tehreer" },
        //    new HighScoreEntry{score = 457,name = "Ali" },
        //    new HighScoreEntry{score = 1000,name = "daniel" },
        //    new HighScoreEntry{score = 200,name = "Sam" },
        //    new HighScoreEntry{score = 1100,name = "Umar" },
        //    new HighScoreEntry{score = 10,name = "Abubakar" },
        //};
       // AddHighScoreEntry("Ahmad",200);
        string jsonString = PlayerPrefs.GetString("highScoreEntryTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        highScoreEntryList = highScores.highScoreEntryList;

        //sort entrylist by score

        for (int i = 0; i < highScores.highScoreEntryList.Count; i++) 
        {
            for (int j = i + 1; j < highScores.highScoreEntryList.Count; j++)
            {
                if (highScores.highScoreEntryList[j].score > highScores.highScoreEntryList[i].score) 
                {
                    //swap
                    HighScoreEntry tmp = highScores.highScoreEntryList[i];
                    highScores.highScoreEntryList[i] = highScores.highScoreEntryList[j];
                    highScores.highScoreEntryList[j] = tmp;
                }
            }
        }

        highScoreEntryTransformList = new List<Transform>();
        foreach (HighScoreEntry entry in highScoreEntryList) 
        {
            CreateHighScoreEntryTransform(entry, entryContainer, highScoreEntryTransformList);
        }

        //HighScores highScores = new HighScores { highScoreEntryList = highScoreEntryList };
        //string json = JsonUtility.ToJson(highScores);
        //PlayerPrefs.SetString("highScoreEntryTable", json);
        //PlayerPrefs.Save();
        //Debug.Log(PlayerPrefs.GetString("highScoreEntryTable"));


    }
    private void CreateHighScoreEntryTransform(HighScoreEntry highScoreEntry,Transform container,List<Transform>transformList)
    {
        float templateHeight = 35f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        string name = highScoreEntry.name;
        entryTransform.Find("NameText").GetComponent<Text>().text = name;

        int score = highScoreEntry.score;
        entryTransform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        transformList.Add(entryTransform);
    }
    private void AddHighScoreEntry(string name,int score) 
    {
        //create highscoreentry
        HighScoreEntry highScoreEntry = new HighScoreEntry {score = score,name= name };

        //Load HighScoreEntry
        string jsonString = PlayerPrefs.GetString("highScoreEntryTable");
        HighScores highScores = JsonUtility.FromJson<HighScores>(jsonString);
        highScoreEntryList = highScores.highScoreEntryList;

        //AddHighScoerEntry
        highScores.highScoreEntryList.Add(highScoreEntry);

        //SaveHighScore Entry
        string json = JsonUtility.ToJson(highScores);
        PlayerPrefs.SetString("highScoreEntryTable", json);
        PlayerPrefs.Save();
    }

    private class HighScores 
    {
        public List<HighScoreEntry>highScoreEntryList;
    }

    [System.Serializable]
    private class HighScoreEntry 
    {
        public string name;
        public int score;
    }
}
