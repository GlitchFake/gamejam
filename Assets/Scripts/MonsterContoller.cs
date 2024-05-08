using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    public float initialMoveSpeed; // Ba�lang�� h�z�
    private float currentMoveSpeed; // �u anki h�z
    private Vector3 startPosition;
    private bool isChasing;

    void Start()
    {
        startPosition = transform.position;
        currentMoveSpeed = initialMoveSpeed;
        isChasing = true;
        StartCoroutine(FollowPlayer());
    }

    IEnumerator FollowPlayer()
    {
        float chaseDuration = 10f; // Takip s�resi (10 saniye)
        float startTime = Time.time;
        float maxSpeed = initialMoveSpeed * 2; // Maksimum h�z� belirleyin

        while (isChasing)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / chaseDuration; // Normalized time (0 to 1)

            // H�z� yava��a art�r, ancak maksimum h�za ula�t���nda artmay� durdur
            currentMoveSpeed = Mathf.Lerp(initialMoveSpeed, maxSpeed, t);
            currentMoveSpeed = Mathf.Min(currentMoveSpeed, maxSpeed); // H�z� maksimum h�zla s�n�rla

            // Oyuncuyu takip et (sadece x ve y d�zleminde)
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);

            yield return null;
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int mevcutSahneIndeksi = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(mevcutSahneIndeksi);
        }
    }
}
