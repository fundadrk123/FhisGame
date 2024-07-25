using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // oyun k�t�phanesi.!

public class Score : MonoBehaviour
{
    int score; // de�i�ken
    Text scoreText; // yaz� de�i�keni text
    int highScore;

    public Text panelScore;  // panel �zerinde ki de�i�kenlere eri�mek i�in de�i�kenler tan�mland�.
    public Text panelHighScore;
    public GameObject New;

    //Start is called before the first frame update
    void Start()
    {
      score = 0; // oyun ba�lad���n herzaman score s�f�r olucak.
     scoreText = GetComponentInChildren<Text>(); // scoretext te getcomponent den text e eri�iyoruz.
    
      scoreText.text = score.ToString(); // score de�erini tostring ile d�n��t�r�p aktard�k.
      panelScore.text = score.ToString(); // panel �zerindeki score texti. ve e�itledik score 0 ise �yle devam edecek.
       highScore = PlayerPrefs.GetInt("highscore"); //!!!
      panelHighScore.text = highScore.ToString();
       

    }

    public void Scored() // scored textimizi g�ncellemek i�in fonksiyon.
    {
      score++; // score her engelden ge�i�te her seferinde bir kez artt�r.
    scoreText.text = score.ToString(); // scoru artt�rma olay�n� tostring i�inde g�cellendi.
    panelScore.text = score.ToString(); // panel textinin �al��mas� i�in �a�r�ld�.
    if (score > highScore) // score b�y�kse high scoreden.
    {
      highScore = score; // highscore score e�it.
    panelHighScore.text = highScore.ToString(); // panelhighscore.texti highscore.tostring alt�nda g�ncelle.
    PlayerPrefs.SetInt("highscore",highScore);//!!!!
    New.SetActive(true);
    }
    }

    public int GetScore()
    {
      return score;  
    }
    
}
