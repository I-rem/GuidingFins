using UnityEngine;

public class FishFollowMouse : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);

        Vector3 direction = mousePos - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        FollowerFish follower = collision.GetComponent<FollowerFish>();
        if (follower != null && follower.target == null)
        {
            follower.StartFollowing(this.transform);
        }
    }

}
