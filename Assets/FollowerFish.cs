using UnityEngine;

public class FollowerFish : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 3f;

    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, followSpeed * Time.deltaTime);
        }
    }

    public void StartFollowing(Transform newTarget)
    {
        target = newTarget;
    }
}
