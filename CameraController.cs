using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    void Start()
    {
        // kameranın pozisyonunu oyuncunun pozisyonundan çıkar 
        // ve bunu offsete ata
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Her Frame de kameranın yerini oyuncunun yerine göre offset
        // göz önünde bulundurarak güncelle
        transform.position = player.transform.position + offset;
    }
}
