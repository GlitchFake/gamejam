using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GeriyeSayac : MonoBehaviour
{
    public TMP_Text sayacText;
    private float geriyeSay = 10f;
    private float milisaniye = 1000f;

    private void Start()
    {
        UpdateSayac();
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
    }
}
