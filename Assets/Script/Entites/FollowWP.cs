using UnityEngine;

public class FollowWP : MonoBehaviour
{
    [SerializeField] private Transform[] waypoint;

    private int currentWP = 0;

    [SerializeField] private float speed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWP].transform.position, speed * Time.deltaTime);

        if (transform.position == waypoint[currentWP].transform.position)
        {
            currentWP += 1;
        }
        if (currentWP == waypoint.Length)
        {
            
            
        }
    }
    public void SetWaypoints(Transform[] waypointList)
    {
        waypoint = waypointList;
    }
}
