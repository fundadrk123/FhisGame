using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManger : MonoBehaviour
{
    public static Vector2 bottomLeft;
    public static bool gameOver; // gameover boolen bir de�er al�cak true , false olarak d�ner.
    public GameObject gameOverPanel;
    public GameObject GetReady;
    public static bool gameStarted; // oyun ba�lama s�resini beklemek i�in olu�turulan de�i�ken.
    public static int gameScore;
    public GameObject score;

    private void Awake()
    {
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));// kameran�n s�f�r s�f�r noktas�n� sol alt k��esini al�yoruz.
    }
    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // sahneyi y�klemek i�in.
    }
    
    void Start()
    {
        gameOver = false; // ba�lang�� de�er olarak false atand�.
        gameStarted = false; // ba�lang�� de�eri false.
    }
    public void GameHasStarted()
    {
        gameStarted = true;  // burdaki fonksiyon �al��maya ba�lad���nda engeller �retilmeye ba�layacak.
        GetReady.SetActive(false);
    }
    public void GameOver()
    {
        gameOver = true;// bal�k �ld� hareket durdu.
        gameOverPanel.SetActive(true); //score tablosunu G�r�n�r hale getirmek i�in.
        score.SetActive(false); // oyun bitti�i zaman yukardaki skoru g�stermeyecek.
        gameScore = score.GetComponent<Score>().GetScore();
    }
}
