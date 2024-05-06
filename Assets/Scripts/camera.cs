using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bileþeni
    public float yOffset = 4f; // Kamera ile oyuncu arasýndaki y eksenindeki mesafe
    private Vector3 initialPosition; // Kameranýn baþlangýç pozisyonunu saklamak için
    void Start()
    {
        initialPosition = transform.position; // Kameranýn baþlangýç pozisyonunu kaydet
    }
    void Update()
    {
        // Oyuncunun y pozisyonu 4'ü geçerse kamerayý yukarý kaydýr
        if (player.position.y > yOffset)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        // Oyuncunun y pozisyonu 4'ün altýna düþtüðünde kamerayý eski konumuna getir
        else if (player.position.y < yOffset)
        {
            transform.position = initialPosition;
        }
    }
}

