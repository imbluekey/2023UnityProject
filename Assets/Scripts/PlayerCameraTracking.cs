using UnityEngine;

public class PlayerCameraTracking : MonoBehaviour
{
    public Transform player; // Please Connect the Player Object
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Z �� ���� �״�� �����ͼ� ����
            smoothedPosition.z = transform.position.z;

            transform.position = smoothedPosition;
        }
    }
}
