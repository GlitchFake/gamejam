using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GeriyeSayac : MonoBehaviour
{
    public TMP_Text sayacText;
    public float geriyeSay = 10f;
    private float milisaniye = 1000f;
    private Vector3 startPosition; // Store the initial player position

    private void Start()
    {
        UpdateSayac();
        startPosition = transform.position; // Save the initial position
    }

    private void UpdateSayac()
    {
        int saniye = Mathf.FloorToInt(geriyeSay);
        int ms = Mathf.FloorToInt((geriyeSay - saniye) * milisaniye);
        sayacText.text = $"{saniye}:{ms:D3}";
    }

    private void Update()
    {
        if (geriyeSay > 0)
        {
            geriyeSay -= Time.deltaTime;
            UpdateSayac();
        }
        else
        {
            int mevcutSahneIndeksi = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(mevcutSahneIndeksi);
        }
    }
    public void ResetTimer()
    {
        geriyeSay = 10f; // Zamaný 10 saniyeye sýfýrla
        UpdateSayac(); // Sayacý güncelle
    }
}