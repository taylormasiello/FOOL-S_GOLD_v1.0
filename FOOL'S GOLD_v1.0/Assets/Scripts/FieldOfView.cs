using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private GameCursor gameCursor;
    [SerializeField] private LayerMask layerMask;
    
    private Mesh mesh;
    private float fov;
    private Vector3 origin;
    private float startingAngle;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 50f;
        origin = Vector3.zero;
    }

    void LateUpdate()
    {
        PickaxeFieldOfView();
    }

    public void PickaxeFieldOfView()
    {
        int rayCount = 25;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 9f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertextIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);

            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // Hit object
                vertex = raycastHit2D.point;
            }
            vertices[vertextIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertextIndex - 1;
                triangles[triangleIndex + 2] = vertextIndex;

                triangleIndex += 3;
            }

            vertextIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetCursorDirection(Vector3 cursorDirection)
    {
        startingAngle = UtilsClass.GetAngleFromVectorFloat(cursorDirection) + fov / 2f;
    }

}
