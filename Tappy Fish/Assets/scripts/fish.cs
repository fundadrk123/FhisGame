using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]  // speed deðiþkeni içindir dizi þeklinde hareketleri içinde tutmaya yarýyor.
    private float _speed; // balýðýn zýplamasý için oluþturulan bir deðiþken. hareketlerini saðlýyor.
    int angle; // balýðýn hareketleri için ilk olarak bir açý tanýmlandý.
    int maxAngle = 20; // maximum açý.
    int minAngle = -60; // minimum açý.
    public Score score;// balýðýn engellerden geçtikten sonraki sayý scor tablosu deðiþkeni.
   // public GoldCoin goldcoin; //!
    bool touchedRound;
    public GameManger gameManger; // eriþe bilmek için tanýmlýyoruz.
    public Sprite fishDied;
    SpriteRenderer sp;
    Animator anim;  // deðiþkeni balýk öldükten sonra hareketi kesmek için.
    public ObstacleSpawner obstaclespawmner;// referans oluþturduk.
    [SerializeField] private AudioSource swim,hit,point;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
         _rb.gravityScale = 0; //balýðýa týklanmadýðý sürece havada durmasýný saðlýyor.!!
        sp = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();  // anim deðiþkeninde getcomponente eriþiyoruz.
    }

    // Update is called once per frame
    void Update()
    {
        FishSwim();
    }
    private void FixedUpdate()
    {
        FishRotation(); // aþaðýya düþerken daha yumuþak bir düþüþ saðlýyor.
    }
    void FishSwim()
    {
        if (Input.GetMouseButtonDown(0)&& GameManger.gameOver==false) // maousenin sol tuþuna basýnca çalýþcak ve gamemanger ve gemaover false ise çalýþsýn.
        {
            swim.Play();

            if (GameManger.gameStarted == false)
            {
                _rb.gravityScale = 4f;  //4f hýzýnda 
                _rb.velocity = Vector2.zero; // her týklanýþta velocity i sýfýrla.
                _rb.velocity = new Vector2(_rb.velocity.x,_speed);
                obstaclespawmner.InstantiateObstcle(); // her basýþta engel üretiyor. hata verdi..!! (hatanýn sebebi editör üzerinde referans vermemiþ olmam). para engelini düzeltince burayý aç.!
                gameManger.GameHasStarted(); // engelleri üretmesi için.!!!!
            }
            else
            {
                _rb.velocity = Vector2.zero; // balýðýn ayný hizzada kalmasýný saðlýyor ve düzenli hareket ediyor.
                _rb.velocity = new Vector2(_rb.velocity.x, _speed); // balýðýn sol tuþ ile tetiklenio hareket etmesini saðlýyor.
            }
            
           
        }
    }
    void FishRotation()
    {

        if (_rb.velocity.y > 0)  // hýz kontorlü y ekseni sýfýrdan büyük ise / açý küçük eþit mi ? maximum açýya çyle ise açýyý 4 artýr.
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4; // açýyý +4 artýrarak devam etsin. hýzýmýz + deðerde olduðu sürece bunu gerçekleþtireceketir.
            }
        }
        else if (_rb.velocity.y < -1.2) // -1.2 aþaðýya düþmede biraz daha yavaþlamasý için.
        {
            if (angle > minAngle)
            {
                angle = angle - 2; // açýyý -2 olarak azaltsýn. hýzýmýz yavaþlamasý için -2 deðerinde biraz daha yavaþ bir þekilde aþaðýya doðru düþecektir.
            }
        }
        if (touchedRound == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle); // açýsal dönüþ verebilmek için kullanýyoruz.
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)  //ikitane deðer alýyor.(collision çarpýþma üzerinden ne ile çarpýþtýðýný kontrol edecel)
    {
        if (collision.CompareTag("Obstacle")) // collision (çarpýþma) obstacle ise.
        {
            //Debug.Log("Scored!");
            score.Scored(); // her score yapýldýktan sonra score çalýþcak.
            point.Play();
          
        }
        else if (collision.CompareTag("Column") && GameManger.gameOver==false) // column balýk deðerse ölücektir.
        {
            // game over
            FishDieEffect();
            gameManger.GameOver(); // burda ölen balýk sesini tek de çýkarýtr.
        }
    }
    void FishDieEffect()
    {
        hit.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Round")) // yer ile temasýný kontrol ediyoruz. yer ile temasda balýðýn öldüðünü kontrol etti.
        {
            if (GameManger.gameOver == false) // gamemanger gameover 'a eþit olduðunda false ol.
            {
                // game over
                FishDieEffect();
                gameManger.GameOver(); // gamemenger altýnda gameover ý çaðýrdýk.
                GameOver(); // balýðýn 90 derecede düþmesini saðlýyor.engellere deðmeden.
            }
            else
            {
                // game over (fish)
                GameOver(); // gameover methodunu çaðýrdý.
            }
        }
    }
    void GameOver()
    {
        touchedRound = true; 
        transform.rotation = Quaternion.Euler(0, 0, - 90); //balýðýn yönüne indirdik. kafa üstü engellere çarptýðýnda düþmesini saðlýyor.
        sp.sprite = fishDied;
        anim.enabled = false; // burda balýk öldükten sonra hareketi durdurmasýný saðlýyor.
    }
}
