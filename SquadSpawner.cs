using UnityEngine;

public class SquadSpawner : MonoBehaviour
{
    public GameObject soldierPrefab;
    public Transform leader;

    public int soldiersPerSquad = 20;
    public float spacing = 4f;

    void Start()
    {
        // Left wedge (far left, closer forward)
        SpawnWedgeSquad(new Vector3(-20, 0, -10));

        // Center grid (slightly back, middle)
        SpawnGridSquad(new Vector3(0, 0, -18));

        // Right wedge (far right, closer forward)
        SpawnWedgeSquad(new Vector3(20, 0, -10));

        // Back line (deep back row)
        SpawnLineSquad(new Vector3(0, 0, -35));
    }

    //-----------------------------------
    void SpawnGridSquad(Vector3 squadOffset)
    {
        for (int i = 0; i < soldiersPerSquad; i++)
        {
            int row = i / 5;
            int col = i % 5;

            Vector3 formationOffset = new Vector3(
                (col - 2) * spacing,
                0,
                -(row * spacing)
            );

            SpawnSoldier(squadOffset, formationOffset);
        }
    }

    //-----------------------------------
    void SpawnLineSquad(Vector3 squadOffset)
    {
        for (int i = 0; i < soldiersPerSquad; i++)
        {
            Vector3 formationOffset = new Vector3(
                (i - soldiersPerSquad / 2) * spacing,
                0,
                0
            );

            SpawnSoldier(squadOffset, formationOffset);
        }
    }

    //-----------------------------------
    void SpawnWedgeSquad(Vector3 squadOffset)
    {
        int index = 0;
        int row = 0;

        while (index < soldiersPerSquad)
        {
            int soldiersInRow = row + 1;

            for (int i = 0; i < soldiersInRow && index < soldiersPerSquad; i++)
            {
                float xOffset = (i - row / 2f) * spacing;

                Vector3 formationOffset = new Vector3(
                    xOffset,
                    0,
                    -(row * spacing)
                );

                SpawnSoldier(squadOffset, formationOffset);

                index++;
            }

            row++;
        }
    }

    //-----------------------------------
    void SpawnSoldier(Vector3 squadOffset, Vector3 formationOffset)
    {
        Vector3 spawnPosition =
            leader.position +
            squadOffset +
            formationOffset;

        spawnPosition.y = 1f;

        GameObject soldier = Instantiate(
            soldierPrefab,
            spawnPosition,
            Quaternion.identity
        );

        UnitFollower follower = soldier.GetComponent<UnitFollower>();

        if (follower == null)
        {
            Debug.LogError("UnitFollower missing on prefab");
            return;
        }

        follower.leader = leader;
        follower.squadOffset = squadOffset;
        follower.formationOffset = formationOffset;
    }

}
