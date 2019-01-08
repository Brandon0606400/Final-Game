using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class TitleButton : MonoBehaviour
{

    // Called when title button is clicked
    public void GoToTitle()
    {
        // Return to title scene
        SceneManager.LoadScene("Menu");
    }

}