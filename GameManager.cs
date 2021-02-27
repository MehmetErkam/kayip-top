using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    bool touchFinish = false;
    public GameObject LevelCompleteUI;
    public float restartDelay = 2f;

    // EndGame fonksiyonu gameHasEnded değişkeninden gelen dönütle çalışır.
    // çalışması doğrultusunda restartDelay kadar bekler ve RestartScene 
    // fonksiyonuna atlar.
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<PlayerController>().enabled = false;
            Invoke("RestartScene", restartDelay);
        }
    }

    public void LevelFinish()
    {
        if (touchFinish == false && gameHasEnded == false)
        {
            touchFinish = true;
            Time.timeScale = 0;
            LevelCompleteUI.SetActive(true);
        }
    }

    // içinde bulunulan sahneyi yeniden yükler.
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // anamenüyü yükler
    public void MainMenuLoader()
    {
        SceneManager.LoadScene(0);
    }

    // oyunun zamanını dondurur.
    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    // oyunun zamanını normal akışına alır.
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    // Bir sonraki sahneye geçer.
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // oyundan çıkar.
    public void QuitGame()
    {
        Application.Quit();
    }
}
