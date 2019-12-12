using System;
using UnityEngine;

public class UIStatsRadarChart : MonoBehaviour {
    public KennelManager kennelManager;
    private CanvasRenderer _radarMeshCanvasRenderer;

    [SerializeField]
    private Material radarMaterial;

    private void Start() {
        _radarMeshCanvasRenderer = transform.Find("RadarMesh").GetComponent<CanvasRenderer>();
        //kennelManager.OnDogChanged += (sender, args) => UpdateStatsVisual();
    }

    private void Update() {
        UpdateStatsVisual();
    }

    private Vector3 GetAngle(int index) {
        float angleIncrement = 360f / 5;
        return Quaternion.Euler(0, 0, -angleIncrement * index) * Vector3.up;
    }
    
    private void UpdateStatsVisual() {
        float averageSpeed = kennelManager.selectedDog.MaxSpeedRun / 100f;
        float acceleration = kennelManager.selectedDog.GetAcceleration() / 1000f;
        float endurance = kennelManager.selectedDog.GetEndurance() / 1000f;
        float maxSpeed = kennelManager.selectedDog.GetVitesseMax() / 1000f;
        float moral = kennelManager.selectedDog.Mental / 1000f;
        
        Mesh mesh = new Mesh();
        
        Vector3[] vertices = new Vector3[6];
        Vector2[] uvs = new Vector2[6];
        int[] triangles = new int[15];

        
        float radarChartSize = 150.0f;

        Vector3 averageSpeedVertex = radarChartSize * averageSpeed * GetAngle(0);
        Vector3 accelerationVertex = acceleration * radarChartSize * GetAngle(1);
        Vector3 enduranceVertex = endurance * radarChartSize * GetAngle(2);
        Vector3 maxSpeedVertex = maxSpeed * radarChartSize * GetAngle(3);
        Vector3 moralVertex = moral * radarChartSize * GetAngle(4);

        int averageSpeedVertexIndex = 1;
        int accelerationVertexIndex = 2;
        int enduranceVertexIndex = 3;
        int maxSpeedVertexIndex = 4;
        int moralVertexIndex = 5;

        vertices[0] = Vector3.zero;
        vertices[averageSpeedVertexIndex] = averageSpeedVertex;
        vertices[accelerationVertexIndex] = accelerationVertex;
        vertices[enduranceVertexIndex] = enduranceVertex;
        vertices[maxSpeedVertexIndex] = maxSpeedVertex;
        vertices[moralVertexIndex] = moralVertex;

        triangles[0] = 0;
        triangles[1] = averageSpeedVertexIndex;
        triangles[2] = accelerationVertexIndex;
        
        triangles[3] = 0;
        triangles[4] = accelerationVertexIndex;
        triangles[5] = enduranceVertexIndex;
        
        triangles[6] = 0;
        triangles[7] = enduranceVertexIndex;
        triangles[8] = maxSpeedVertexIndex;
        
        triangles[9] = 0;
        triangles[10] = maxSpeedVertexIndex;
        triangles[11] = moralVertexIndex;
        
        triangles[12] = 0;
        triangles[13] = moralVertexIndex;
        triangles[14] = averageSpeedVertexIndex;

        mesh.vertices = vertices;
        mesh.uv = uvs;
        mesh.triangles = triangles;
        
        _radarMeshCanvasRenderer.SetMesh(mesh);
        _radarMeshCanvasRenderer.SetMaterial(radarMaterial, null);
    }
}
