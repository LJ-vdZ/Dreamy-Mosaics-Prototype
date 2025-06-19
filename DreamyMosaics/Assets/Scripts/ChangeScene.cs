using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private static string previousScene = null;

    //helps go to previous scene, for the back buttons
    private void LoadAndStorePreviousScene(string newSceneName)
    {
        previousScene = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene(newSceneName);
    }

    public void StartButton() //goes to Level 1 scene
    {
        SceneManager.LoadScene("Level 1");
    }

    public void AboutButton() //goes to Information Interface scene
    {
        LoadAndStorePreviousScene("Information Interface");
    }

    public void BackButton()    //goes back to previous scene
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene stored");
        }
    }

    public void ResumeButton()    //goes back to previous scene/game scene
    {
        if (!string.IsNullOrEmpty(previousScene))
        {
            SceneManager.LoadScene(previousScene);
        }
        else
        {
            Debug.Log("No previous scene stored");
        }
    }

    public void HomeButton() //goes to Game Start scene
    {
        SceneManager.LoadScene("Game Start");
    }


    public void RestartButton() //goes to Level 1 scene again, reload
    {
        SceneManager.LoadScene("Level 1");
    }

    public void NewGameButton() //also goes to Level 1 scene again, since we only have one level
    {
        SceneManager.LoadScene("Level 1");
    }

    public void PauseButton() //goes to pause scene
    {
        LoadAndStorePreviousScene("Pause Interface");
    }

    public void QuitButton() //quits application
    {
        Application.Quit();
    }

    public void MuteSoundButton() //mutes game sound
    {

    }

    public void ShowScoreButton() //displays score
    {
        LoadAndStorePreviousScene("ScoreScene");
    }


}
