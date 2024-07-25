using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacle; // obstacle engel de�i�keni.rastgele engel atama ba�ar�l�.
    public GameObject[] newobstacle; //bunu sen ekledin.
    public GameObject[] newcoin;   // paralara eri�mek i�in.
    public GameObject[] deneme; 


    public float spwanInterval;// public GameObject[] newShark;
    public float maxTime; // float de�erinde maximum zaman.
    float timer; // zaman aral��� i�in tan�mlanan de�i�ken.
    public float maxY; // edit�r �zerinde de�i�tire bilirsin.
    public float minY;// edit�r �zerinden de�i�tire bilirsin.
    float randomY;// rastgele de�er.
    float randomX; // tam de�er belirlemek i�in.

    // Start is called before the first frame update
    void Start()
    {
       
       // InstantiateObstcle(); // engelimizi alabilmek i�in fonksiyonu bir kez �a�r�yoruz.bu bizim i�in belirledi�imiz konumlar i�inde engel �retiyor.oyunu ba�latmadan engel �retiyor yorum sat�r�ndan alma!!!
    }


    // Update is called once per frame
    void Update()
    {
        if (GameManger.gameOver == false && GameManger.gameStarted==true) // false oldu�u durumda �al��. / gamemanger.gamestarted==true oldu�unda zamanlamay� ba�lats�n ve engelleri �retsin.
        {
            
            timer += Time.deltaTime; // zaman aral���n� art�rd�k
            if (timer >= maxTime) // timer max zamandan b�y�k yada e�itse?
            {

                randomY = Random.Range(minY, maxY); // belirledi�imiz aral�k de�erleri i�in randomy de�erini �a�r�yoruz.

                InstantiateFish(); // bal�k fonksiyonlar�
               InstantiateObstcle(); // fonksiyon �al��t�ktan sonra timer s�f�rlancak.ve �retecek.
                Instantiatecoin(); // para fonksiyonu
               // Instantiatecdeneme();
                timer = 0; // timer s�f�rland�. ve 3,5 saniye sonra engel �retilmeye ba�lan�cak.
                


            }
        }
    }
  
   public void InstantiateObstcle()// engellerimizi olu�turmak i�in.
    {
        GameObject newObstacle = Instantiate(obstacle[Random.Range(0, 3)]);
        newObstacle.transform.position = new Vector2(transform.position.x,randomY);// vector2 yi referans al�yoruz ve iki de�er istiyor ilk olarak x de�eri birde random y de�erini at�yor her engel �al��t�k�a random y atanacak.
    }

     public void InstantiateFish() // engellerimizi olu�turmak i�in.bal�k engelleri.
     {
       GameObject newObstacle = Instantiate(newobstacle[Random.Range(0,4)]);  // bal���n yerini random de�i�tirme.!
       newObstacle.transform.position = new Vector2(randomX,randomY); //random olarak atama yapar.

     }

    public void Instantiatecoin() // engellerimizi olu�turmak i�in. alt�n para !!
    {
        //Debug.Log("collision" + GameManger.gameOver);

        GameObject newObstacle = Instantiate(newcoin[0]);  // bal���n yerini random de�i�tirme.!
        newObstacle.transform.position = new Vector2(randomX, randomY); //random olarak atama yapar.

        
    }

  // public void Instantiatecdeneme() 
    //{
      //  GameObject newObstacle = Instantiate(deneme[0]);  
       // newObstacle.transform.position = new Vector2(randomX, randomY); 

   //}


}






