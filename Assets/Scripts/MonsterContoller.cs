using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    public float initialMoveSpeed; // Baþlangýç hýzý
    private float currentMoveSpeed; // Þu anki hýz
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
        float chaseDuration = 10f; // Takip süresi (10 saniye)
        float startTime = Time.time;

        while (isChasing)
        {
            float elapsedTime = Time.time - startTime;
            float t = elapsedTime / chaseDuration; // Normalized time (0 to 1)

            // Hýzý yavaþça artýr
            currentMoveSpeed = Mathf.Lerp(initialMoveSpeed, 2 * initialMoveSpeed, t);

            // Oyuncuyu takip et (sadece x ve y düzleminde)
            Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentMoveSpeed * Time.deltaTime);

            yield return null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Oyuncu baþlangýç konumuna döner
            player.position = player.GetComponent<PlayerController>().startPosition;
            // Monster baþlangýç konumuna döner ve tekrar takip etmeye baþlar
            transform.position = startPosition;
            currentMoveSpeed = initialMoveSpeed;
            isChasing = true;
            StartCoroutine(FollowPlayer());
        }
    }
}
