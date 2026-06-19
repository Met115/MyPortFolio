using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform throwPoint;
    [SerializeField] private float throwInterval = 2f;
    [SerializeField] private float throwPower = 8f;

    private void Start()
    {
        StartCoroutine(ThrowLoop());
    }

    private IEnumerator ThrowLoop()
    {
        while (true)
        {
            ThrowBall();
            yield return new WaitForSeconds(throwInterval);
        }
    }

    private void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, throwPoint.position, Quaternion.identity);

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        Vector2 direction = Vector2.left;
        rb.linearVelocity = direction * throwPower;
    }
}