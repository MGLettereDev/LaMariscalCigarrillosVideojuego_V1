using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " Puntos";

    }

    public void RestartBtn()
    {
        SceneManager.LoadScene("LaMariscalCigarrillos");
    }

    public void ExitBtn()
    {
        //Comentar l�nea 26 una vez en producci�n
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
