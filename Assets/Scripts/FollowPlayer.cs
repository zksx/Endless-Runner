using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject playerObject;
    private float smoothFactor = 1.0f;
    private Vector3 cameraOffset = new Vector3(0, 5, 13);

    void LateUpdate()
    {
        if (playerObject == null) return;

        Transform playerTransform = playerObject.transform;

        Vector3 newPosition = new Vector3(playerTransform.position.x, playerTransform.position.y + cameraOffset.y, playerTransform.position.z - cameraOffset.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, smoothFactor * Time.deltaTime);
        transform.LookAt(playerTransform.position);
    }
}
  