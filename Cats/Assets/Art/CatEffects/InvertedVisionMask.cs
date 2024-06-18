using UnityEngine;

public class InvertedVisionMask : MonoBehaviour
{
    public Material visionMaterial;
    public float visionDistance = 10f;
    public float visionAngle = 120f;
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;

    void Start()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = visionMaterial;
        UpdateVisionMesh();
    }

    void Update()
    {
        UpdateVisionMesh();
    }

    void UpdateVisionMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[8];
        int[] triangles = new int[24];

        Vector3 direction = transform.right * (transform.localScale.x > 0 ? 1 : -1);
        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2, 0) * direction;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2, 0) * direction;

        // Define the vertices of the inverted mask
        vertices[0] = Vector3.zero;
        vertices[1] = leftBoundary * visionDistance;
        vertices[2] = rightBoundary * visionDistance;
        vertices[3] = new Vector3(-visionDistance, 0, visionDistance);
        vertices[4] = new Vector3(-visionDistance, 0, -visionDistance);
        vertices[5] = new Vector3(visionDistance, 0, -visionDistance);
        vertices[6] = new Vector3(visionDistance, 0, visionDistance);
        vertices[7] = new Vector3(0, 0, visionDistance); // Apex of the cone

        // Define triangles of the inverted mask
        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        triangles[3] = 1;
        triangles[4] = 3;
        triangles[5] = 2;

        triangles[6] = 2;
        triangles[7] = 3;
        triangles[8] = 4;

        triangles[9] = 2;
        triangles[10] = 4;
        triangles[11] = 5;

        triangles[12] = 2;
        triangles[13] = 5;
        triangles[14] = 6;

        triangles[15] = 0;
        triangles[16] = 2;
        triangles[17] = 6;

        triangles[18] = 0;
        triangles[19] = 6;
        triangles[20] = 7;

        triangles[21] = 0;
        triangles[22] = 7;
        triangles[23] = 1;

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        meshFilter.mesh = mesh;
    }
}


