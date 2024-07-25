using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]  // speed de�i�keni i�indir dizi �eklinde hareketleri i�inde tutmaya yar�yor.
    private float _speed; // bal���n z�plamas� i�in olu�turulan bir de�i�ken. hareketlerini sa�l�yor.
    int angle; // bal���n hareketleri i�in ilk olarak bir a�� tan�mland�.
    int maxAngle = 20; // maximum a��.
    int minAngle = -60; // minimum a��.
    public Score score;// bal���n engellerden ge�tikten sonraki say� scor tablosu de�i�keni.
   // public GoldCoin goldcoin; //!
    bool touchedRound;
    public GameManger gameManger; // eri�e bilmek i�in tan�ml�yoruz.
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;  // de�i�keni bal�k �ld�kten sonra hareketi kesmek i�in.
    public ObstacleSpawner obstaclespawmner;// referans olu�turduk.
    [SerializeField] private AudioSource swim,hit,point;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
         _rb.gravityScale = 0; //bal���a t�klanmad��� s�rece havada durmas�n� sa�l�yor.!!
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();  // anim de�i�keninde getcomponente eri�iyoruz.
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
    }
    private void FixedUpdate()
    {
        FishRotation(); // a�a��ya d��erken daha yumu�ak bir d���� sa�l�yor.
    }
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0)&& GameManger.gameOver==false) // maousenin sol tu�una bas�nca �al��cak ve gamemanger ve gemaover false ise �al��s�n.
        {
            swim.Play();

            if (GameManger.gameStarted == false)
            {
                _rb.gravityScale = 4f;  //4f h�z�nda 
                _rb.velocity = Vector2.zero; // her t�klan��ta velocity i s�f�rla.
                _rb.velocity = new Vector2(_rb.velocity.x,_speed);
                obstaclespawmner.InstantiateObstcle(); // her bas��ta engel �retiyor. hata verdi..!! (hatan�n sebebi edit�r �zerinde referans vermemi� olmam). para engelini d�zeltince buray� a�.!
                gameManger.GameHasStarted(); // engelleri �retmesi i�in.!!!!
            }
            else
            {
                _rb.velocity = Vector2.zero; // bal���n ayn� hizzada kalmas�n� sa�l�yor ve d�zenli hareket ediyor.
                _rb.velocity = new Vector2(_rb.velocity.x, _speed); // bal���n sol tu� ile tetiklenio hareket etmesini sa�l�yor.
            }
            
           
        }
    }
    void FishRotation()
    {

        if (_rb.velocity.y > 0)  // h�z kontorl� y ekseni s�f�rdan b�y�k ise / a�� k���k e�it mi ? maximum a��ya �yle ise a��y� 4 art�r.
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4; // a��y� +4 art�rarak devam etsin. h�z�m�z + de�erde oldu�u s�rece bunu ger�ekle�tireceketir.
            }
        }
        else if (_rb.velocity.y < -1.2) // -1.2 a�a��ya d��mede biraz daha yava�lamas� i�in.
        {
            if (angle > minAngle)
            {
                angle = angle - 2; // a��y� -2 olarak azalts�n. h�z�m�z yava�lamas� i�in -2 de�erinde biraz daha yava� bir �ekilde a�a��ya do�ru d��ecektir.
            }
        }
        if (touchedRound == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); // a��sal d�n�� verebilmek i�in kullan�yoruz.
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)  //ikitane de�er al�yor.(collision �arp��ma �zerinden ne ile �arp��t���n� kontrol edecel)
    {
        if (collision.CompareTag("Obstacle")) // collision (�arp��ma) obstacle ise.
        {
            //Debug.Log("Scored!");
            score.Scored(); // her score yap�ld�ktan sonra score �al��cak.
            point.Play();
          
        }
        else if (collision.CompareTag("Column") && GameManger.gameOver==false) // column bal�k de�erse �l�cektir.
        {
            // game over
            FishDieEffect();
            gameManger.GameOver(); // burda �len bal�k sesini tek de ��kar�tr.
        }
    }
    void FishDieEffect()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Round")) // yer ile temas�n� kontrol ediyoruz. yer ile temasda bal���n �ld���n� kontrol etti.
        {
            if (GameManger.gameOver == false) // gamemanger gameover 'a e�it oldu�unda false ol.
            {
                // game over
                FishDieEffect();
                gameManger.GameOver(); // gamemenger alt�nda gameover � �a��rd�k.
                GameOver(); // bal���n 90 derecede d��mesini sa�l�yor.engellere de�meden.
            }
            else
            {
                // game over (fish)
                GameOver(); // gameover methodunu �a��rd�.
            }
        }
    }
    void GameOver()
    {
        touchedRound = true; 
        transform.rotation = Quaternion.Euler(0, 0, - 90); //bal���n y�n�ne indirdik. kafa �st� engellere �arpt���nda d��mesini sa�l�yor.
        sp.sprite = fishDied;
        anim.enabled = false; // burda bal�k �ld�kten sonra hareketi durdurmas�n� sa�l�yor.
    }
}
