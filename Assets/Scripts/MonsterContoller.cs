using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        while (isChasing)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / chaseDuration; // Normalized time (0 to 1)

            // H�z� yava��a art�r
            currentMoveSpeed = Mathf.Lerp(initialMoveSpeed, 2 * initialMoveSpeed, t);

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
            // Oyuncu ba�lang�� konumuna d�ner
            player.position = player.GetComponent<PlayerController>().startPosition;
            // Monster ba�lang�� konumuna d�ner ve tekrar takip etmeye ba�lar
            transform.position = startPosition;
            currentMoveSpeed = initialMoveSpeed;
            isChasing = true;
            StartCoroutine(FollowPlayer());
        }
    }
}
