using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Using statement for the unity UI code
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{

    // Text components used to display the high score
    public List<Text> highScoreDisplays = new List<Text>();

    // Internal data for score values
    private List<int> highScoreData = new List<int>();

    // Use this for initialization
    void Start()
    {

        // Load the high score data from the PlayerPrefs
        LoadHighScoreData();

        // Get our current score from PlayerPrefs
        int currentScore = PlayerPrefs.GetInt("score", 0);

        // Check if we got a new high score
        bool haveNewHighScore = IsNewHighScore(currentScore);
        if (haveNewHighScore == true)
        {

            // Add new score to the data
            addScoreToList(currentScore);

            // Save updated data
            SaveHighScoreData();
        }

        // Update the visual display
        UpdateVisualDisplay();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LoadHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Using the loop index, get the name for our PlayerPrefs key
            string prefsKey = "HighScore" + i.ToString();

            // Use this key to get the highscore value from the PlayerPrefs
            int highScoreValue = PlayerPrefs.GetInt(prefsKey, 0);

            // Store this score value in out internal data list
            highScoreData.Add(highScoreValue);
        }
    }

    private void UpdateVisualDisplay()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // find the specific text and numbers in our list
            // set the text to the numerical score
            highScoreDisplays[i].text = highScoreData[i].ToString();
        }
    }

    private bool IsNewHighScore(int scoreToCheck)
    {
        // Loop through the high scores and see if ours is higher than any of them
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Is our score higher than the high score we're checking this loop?
            if (scoreToCheck > highScoreData[i])
            {
                // Our score is higher!
                // Return to the calling code that we DO have a new high score
                return true;
            }
        }

        // default: false
        return false;
    }

    private void addScoreToList(int newScore)
    {
        // Loop through the high scores and find where the new score fits
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Is our new score higher than the score we're checking in the list?
            if (newScore > highScoreData[i])
            {
                // Our score IS higher
                // Since we're going from highest to lowest, the first
                // time our score is higher, this is where it must go

                // Insert the new score into the list here
                highScoreData.Insert(i, newScore);

                // Trim the last item off the list
                highScoreData.RemoveAt(highScoreData.Count - 1);

                // We're done, we must exit early
                return;
            }

        }
    }

    private void SaveHighScoreData()
    {
        for (int i = 0; i < highScoreDisplays.Count; ++i)
        {
            // Using the loop index, get the name for our PlayerPrefs key
            string prefsKey = "HighScore" + i.ToString();

            // Get the current high score entry from the data
            int highScoreEntry = highScoreData[i];

            // Save this data to the PlayerPrefs
            PlayerPrefs.SetInt(prefsKey, highScoreEntry);
        }

        // Save the player prefs to disk
        PlayerPrefs.Save();
    }

}
