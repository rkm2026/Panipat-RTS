//using UnityEngine;

//public class LeaderController : MonoBehaviour
//{
//    public float moveSpeed = 10f;

//    void Update()
//    {
//        float h = Input.GetAxis("Horizontal");
//        float v = Input.GetAxis("Vertical");

//        Vector3 move = new Vector3(h, 0, v);

//        transform.position += move * moveSpeed * Time.deltaTime;

//        // optional facing direction
//        if (move != Vector3.zero)
//        {
//            transform.forward = move;
//        }
//    }
//}
using UnityEngine;

public class LeaderController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float obstacleCheckDistance = 2f;

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(h, 0, v);

        if (move == Vector3.zero) return;

        // check obstacle ahead
        RaycastHit hit;

        if (Physics.Raycast(
            transform.position,
            move.normalized,
            out hit,
            obstacleCheckDistance))
        {
            if (hit.collider.CompareTag("Obstacle"))
            {
                Debug.Log("Obstacle detected - movement stopped");
                return;
            }
        }

        transform.position +=
            move.normalized *
            moveSpeed *
            Time.deltaTime;

        transform.forward = move;
    }
}