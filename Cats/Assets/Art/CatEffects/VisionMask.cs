using UnityEngine;

public class VisionMask : MonoBehaviour
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
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        UpdateVisionMesh();
        if(Input.GetKeyDown(KeyCode.Q))
        {
            this.enabled = true;
        }
    }

    void UpdateVisionMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[3];
        int[] triangles = new int[3];

        vertices[0] = Vector3.zero;
        vertices[1] = Quaternion.Euler(0, -visionAngle / 2, 0) * Vector3.forward * visionDistance;
        vertices[2] = Quaternion.Euler(0, visionAngle / 2, 0) * Vector3.forward * visionDistance;

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        meshFilter.mesh = mesh;
        transform.localScale = new Vector3(transform.localScale.x, 1, transform.localScale.z); // Mantener escala correcta
    }
}

