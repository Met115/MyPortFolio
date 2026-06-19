using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerContoroller : MonoBehaviour
{
    [SerializeField] private Transform catchPoint;
    [SerializeField] private float catchRange = 1.5f;
    [SerializeField] private LayerMask ballLayer;

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            TryCatch();
        }
    }

    private void TryCatch()
    {
        Collider2D hit = Physics2D.OverlapCircle(
            catchPoint.position,
            catchRange,
            ballLayer
        );

        if (hit != null)
        {
            Destroy(hit.gameObject);
            Debug.Log("キャッチ成功");
        }
        else
        {
            Debug.Log("キャッチ失敗");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (catchPoint == null) return;

        Gizmos.DrawWireSphere(catchPoint.position, catchRange);
    }
}