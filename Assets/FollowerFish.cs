using UnityEngine;

public class FollowerFish : MonoBehaviour
{
    public Transform targetToFollow;
    public float followDistance = 1.5f;
    public float followSpeed = 5f;

    public Vector2 sideOffset;
    public float swimWobbleAmount = 0.2f;
    public float swimWobbleSpeed = 2f;

    private Vector3 baseOffset;

    void Start()
    {
        baseOffset = new Vector3(sideOffset.x, sideOffset.y, 0f);
    }

    void Update()
    {
        if (targetToFollow == null) return;

        // Wobble effect
        float wobble = Mathf.Sin(Time.time * swimWobbleSpeed + GetInstanceID()) * swimWobbleAmount;
        Vector3 wobbleOffset = new Vector3(0f, wobble, 0f);

        // Calculate spacing direction
        Vector3 toTarget = transform.position - targetToFollow.position;
        float distance = toTarget.magnitude;
        Vector3 dir = toTarget.normalized;

        // Desired position with offsets
        Vector3 desiredPos = targetToFollow.position + dir * followDistance + baseOffset + wobbleOffset;

        // Smooth movement based on distance (closer = slower)
        float t = Mathf.Clamp01((distance - 0.1f) / followDistance);
        transform.position = Vector3.Lerp(transform.position, desiredPos, t * followSpeed * Time.deltaTime);
    }

    public void StartFollowing(Transform newTarget, Vector2 newSideOffset)
    {
        targetToFollow = newTarget;
        sideOffset = newSideOffset;
        baseOffset = new Vector3(sideOffset.x, sideOffset.y, 0f);
    }
}
