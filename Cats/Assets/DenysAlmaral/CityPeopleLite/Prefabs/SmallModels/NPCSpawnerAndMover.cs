using UnityEngine;
using System.Collections;

public class NPCSpawnerAndMover : MonoBehaviour
{
    public GameObject[] Personajes; 
    public GameObject[] Tracks; 

    public float speed = 2.0f; 
    public float spawnInterval = 10.0f; 

    void Start()
    {
        StartCoroutine(SpawnNPCs());
    }

    IEnumerator SpawnNPCs()
    {
        while (true)
        {
            GameObject track = Tracks[Random.Range(0, Tracks.Length)];

            Vector3 spawnPosition = track.transform.GetChild(0).position;

            GameObject npc = Instantiate(Personajes[Random.Range(0, Personajes.Length)], spawnPosition, Quaternion.identity);

            StartCoroutine(MoveAlongTrack(npc, track));

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator MoveAlongTrack(GameObject npc, GameObject track)
    {
        
        Transform[] points = new Transform[track.transform.childCount];

        for (int i = 0; i < track.transform.childCount; i++)
        {
            points[i] = track.transform.GetChild(i);
        }

        int currentPointIndex = 0;

        while (true)
        {
            Vector3 targetPosition = points[currentPointIndex].position;

            Vector3 direction = (targetPosition - npc.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));

            if (npc == null )
            {
                yield break;
            }
            while (Vector3.Distance(npc.transform.position, targetPosition) > 0.1f)
            {
                if (npc == null)
                {
                    yield break;
                }
                npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, lookRotation, Time.deltaTime * speed);

                npc.transform.position = Vector3.MoveTowards(npc.transform.position, targetPosition, speed * Time.deltaTime);

                yield return null;
            }                     

            currentPointIndex = (currentPointIndex + 1) % points.Length;
            if(currentPointIndex == points.Length + 1)
            {
                
                yield break;
            }
        }
    }
}


