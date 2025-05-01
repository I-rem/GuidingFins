using System.Collections.Generic;
using UnityEngine;

public class FishFollowMouse : MonoBehaviour
{
    public float moveSpeed = 5f;
    private List<FollowerFish> followers = new List<FollowerFish>();
    public float horizontalSpacing = 1.5f;
    public float verticalSpacing = 1.0f;

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
        if (follower != null && follower.targetToFollow == null)
        {
            int index = followers.Count;

            // Alternate left and right
            int side = (index % 2 == 0) ? -1 : 1;
            int row = (index + 1) / 2;

            Vector3 offset = new Vector3(
                side * horizontalSpacing * row,
                -verticalSpacing * row,
                0f
            );

            follower.StartFollowing(this.transform, offset);
            followers.Add(follower);
        }
    }
}
