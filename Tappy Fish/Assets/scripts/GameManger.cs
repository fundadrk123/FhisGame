using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManger : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver; // gameover boolen bir deðer alýcak true , false olarak döner.
    public GameObject gameOverPanel;
    public GameObject GetReady;
    public static bool gameStarted; // oyun baþlama süresini beklemek için oluþturulan deðiþken.
    public static int gameScore;
    public GameObject score;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));// kameranýn sýfýr sýfýr noktasýný sol alt köþesini alýyoruz.
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // sahneyi yüklemek için.
    }
    
    void Start()
    {
        gameOver = false; // baþlangýç deðer olarak false atandý.
        gameStarted = false; // baþlangýç deðeri false.
    }
    public void GameHasStarted()
    {
        gameStarted = true;  // burdaki fonksiyon çalýþmaya baþladýðýnda engeller üretilmeye baþlayacak.
        GetReady.SetActive(false);
    }
    public void GameOver()
    {
        gameOver = true;// balýk öldü hareket durdu.
        gameOverPanel.SetActive(true); //score tablosunu Görünür hale getirmek için.
        score.SetActive(false); // oyun bittiði zaman yukardaki skoru göstermeyecek.
        gameScore = score.GetComponent<Score>().GetScore();
    }
}
