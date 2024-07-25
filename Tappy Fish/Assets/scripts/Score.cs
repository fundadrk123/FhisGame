using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // oyun kütüphanesi.!

public class Score : MonoBehaviour
{
    int score; // deðiþken
    Text scoreText; // yazý deðiþkeni text
    int highScore;

    public Text panelScore;  // panel üzerinde ki deðiþkenlere eriþmek için deðiþkenler tanýmlandý.
    public Text panelHighScore;
    public GameObject New;

    //Start is called before the first frame update
    void Start()
    {
      score = 0; // oyun baþladýðýn herzaman score sýfýr olucak.
     scoreText = GetComponentInChildren<Text>(); // scoretext te getcomponent den text e eriþiyoruz.
    
      scoreText.text = score.ToString(); // score deðerini tostring ile dönüþtürüp aktardýk.
      panelScore.text = score.ToString(); // panel üzerindeki score texti. ve eþitledik score 0 ise öyle devam edecek.
       highScore = PlayerPrefs.GetInt("highscore"); //!!!
      panelHighScore.text = highScore.ToString();
       

    }

    public void Scored() // scored textimizi güncellemek için fonksiyon.
    {
      score++; // score her engelden geçiþte her seferinde bir kez arttýr.
    scoreText.text = score.ToString(); // scoru arttýrma olayýný tostring içinde gücellendi.
    panelScore.text = score.ToString(); // panel textinin çalýþmasý için çaðrýldý.
    if (score > highScore) // score büyükse high scoreden.
    {
      highScore = score; // highscore score eþit.
    panelHighScore.text = highScore.ToString(); // panelhighscore.texti highscore.tostring altýnda güncelle.
    PlayerPrefs.SetInt("highscore",highScore);//!!!!
    New.SetActive(true);
    }
    }

    public int GetScore()
    {
      return score;  
    }
    
}
