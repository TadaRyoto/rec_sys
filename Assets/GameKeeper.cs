using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeeper : MonoBehaviour
{
    public bool isStarted = false;
    public bool isFinished = false;
    public TMPro.TextMeshProUGUI timeTexts;
    float totalTime = 5;
    int retime;
    public TMPro.TextMeshProUGUI UItext;

    // Update is called once per frame
    void Update()
    {
        // Start the game when Space is pressed
        if (!isStarted && Input.GetKeyDown(KeyCode.Space))
        {
            isStarted = true;
            UItext.text = "";
        }

        if (isStarted)
        {
            totalTime -= Time.deltaTime;
            retime = (int)totalTime;
            timeTexts.text = retime.ToString();
        }

        if (totalTime < 0)
        {
            isFinished = true;
            isStarted = false;
        }

        if (isFinished)
        {
            timeTexts.text = "";
            UItext.text = "Press R to restart";
            if (Input.GetKeyDown(KeyCode.R))
            {
                // Restart the game
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }
        }
    }
}