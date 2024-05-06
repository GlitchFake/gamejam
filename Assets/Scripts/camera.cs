using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Oyuncunun Transform bile�eni
    public float yOffset = 4f; // Kamera ile oyuncu aras�ndaki y eksenindeki mesafe
    private Vector3 initialPosition; // Kameran�n ba�lang�� pozisyonunu saklamak i�in
    void Start()
    {
        initialPosition = transform.position; // Kameran�n ba�lang�� pozisyonunu kaydet
    }
    void Update()
    {
        // Oyuncunun y pozisyonu 4'� ge�erse kameray� yukar� kayd�r
        if (player.position.y > yOffset)
        {
            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
        // Oyuncunun y pozisyonu 4'�n alt�na d��t���nde kameray� eski konumuna getir
        else if (player.position.y < yOffset)
        {
            transform.position = initialPosition;
        }
    }
}

