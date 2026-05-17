using UnityEngine;

public class UnitFollower : MonoBehaviour
{
    public Transform leader;
    public Vector3 squadOffset;
    public Vector3 formationOffset;

    public float moveSpeed = 10f;

    void Update()
    {
        if (leader == null) return;

        Vector3 targetPosition =
            leader.position +
            squadOffset +
            formationOffset;

        Vector3 direction =
            targetPosition - transform.position;

        float distance = direction.magnitude;

        if (distance > 0.5f)
        {
            transform.position +=
                direction.normalized *
                moveSpeed *
                Time.deltaTime;
        }
    }
}