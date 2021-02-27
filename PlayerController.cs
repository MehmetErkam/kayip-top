
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool duzMu = true; // Cihazın düzlemini kontrol etme
    private Rigidbody rigid; // rigidbody değişkeni
    public bool gyroscope = false; // Gyroscope Sensorü anahtarı
    public bool keyboard = true; // Klavye kontrolü anahtarı
    public bool joystick=true; // Joystick kontrolü anahtarı
    public int hiz = 10; // hız değişkeni

    void Start()
    {
        rigid = GetComponent<Rigidbody>(); 
        // Scriptin bulunduğu değişkenin rigidbody'si
    }

    void FixedUpdate()
    {
        // gyroscope sensöründen elde edilen veriyi input olarak alıp
        // rigidbody ye velocity değeri olarak atar.

        if (gyroscope)
        {
            Vector3 egim = -Input.acceleration;

            if (duzMu)
                egim = Quaternion.Euler(90, 0, 180) * egim;

            rigid.velocity = egim * hiz;
        }

        // klavye kontrollerinin ve gamepad kontrollerinin gerçekleşmesini
        // sağlar. Yatay ve dikey yönde alınan girdiler, x ve z düzleminde
        // hareket için addforce fonksiyonuna parametre olarak verilir. 

        if (keyboard)
        {
            float xMov = Input.GetAxisRaw("Horizontal")*hiz;
            float zMov = Input.GetAxisRaw("Vertical")*hiz;

            rigid.AddForce(xMov,0,zMov);
        }

        // Mobil ekranlarda hareket için sanal bir analog hareket sağlanabilir.
        // Ekranda gözüken analog'un girilen yön doğrultusunda hareketi sağlaması
        // için Vector3 sınıfında direction değişkeni oluşturulur. bu değişkende 
        // vector3'ün ileri fonksiyonu ve sağ fonksiyonu toplanır. toplanmadan önce
        // ileri => Vertical ile, Sağ => Horizontal girdi ile çarpılır. AddForce ile 
        // rigidbody ye yön, hız, sabit zaman ve hız değişkenliğini  kontrol etme
        // özellikleri kazandırılır.

        if (joystick)
        {
            Vector3 direction = Vector3.forward * 
            FindObjectOfType<FixedJoystick>().Vertical + Vector3.right * 
            FindObjectOfType<FixedJoystick>().Horizontal;
            
            rigid.AddForce(direction * 
            hiz * Time.fixedDeltaTime, 
            ForceMode.VelocityChange);
        }

        // Eğer oyuncu dünyadan düşerse endgame fonksiyonu başlayacak.
        if (rigid.position.y < -2f)
        {
            FindObjectOfType<GameManager>().RestartScene();
        }
    }
}