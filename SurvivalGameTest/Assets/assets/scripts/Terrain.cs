using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Unity.Collections;
using UnityEditor.ShaderGraph.Internal;

public class Terrain
{
    public Mesh Regenerate(int resolution, float size, bool flipped, Texture2D heightmap, float heightMapScale, Color TopColor, Color MidColor, Color BottomColor, float TopThreshold, float BottomThreshold)
    {
        Mesh mesh = new Mesh();
        mesh.Clear();
        int VerticesCount = (resolution + 1) * (resolution + 1);
        Vector3[] newVertices = new Vector3[VerticesCount];
        Vector2[] newUV = new Vector2[VerticesCount];
        //int[] newTriangles = new int[resolution * resolution * 6];
        
        List<int> newTrianglesLow = new List<int>(resolution * resolution * 6);
        List<int> newTrianglesMid = new List<int>(resolution * resolution * 6);
        List<int> newTrianglesHigh = new List<int>(resolution * resolution * 6);
        
        //List<int> triangles = new List<int>();
        
        Color[] colors = new Color[VerticesCount];

        if (BottomThreshold >= TopThreshold)
        {
            BottomThreshold = TopThreshold - 1;
        }
        
        for (int i = 0; i <= resolution; i++)
        {
            for (int j = 0; j <= resolution; j++)
            {
                int index = j + i * (resolution + 1);
                float u = (float)j / resolution;
                float v = (float)i / resolution;
                
                newVertices[index] = new Vector3(j * size / resolution - size/2, 0, i * size / resolution - size/2);
                newUV[index] = new Vector2(u, v); 
                
                int x = Mathf.FloorToInt(u * (heightmap.width - 1));
                int z = Mathf.FloorToInt(v * (heightmap.height - 1));

                float y = newVertices[index].y = Mathf.Clamp(heightmap.GetPixel(x, z).grayscale * heightMapScale, 0, heightmap.height * heightMapScale);

                /*if (y > maxTerrainHeight)
                {
                    maxTerrainHeight = y;
                }

                if (y < minTerrainHeight)
                {
                    minTerrainHeight = y;
                }*/
            }
        }

        for (int i = 0; i < resolution; i++)
        {
            for (int j = 0; j < resolution; j++)
            {
                int bottom_left = i * (resolution + 1) + j;
                int bottom_right = bottom_left + 1;
                int top_left = (i + 1) * (resolution + 1) + j;
                int top_right = top_left + 1;

                float height = newVertices[bottom_right].y;
                
                List<int> triangles = new List<int>();

                if (height >= TopThreshold)
                {
                    triangles = newTrianglesHigh;
                }
                else if (height <= BottomThreshold)
                {
                    triangles = newTrianglesLow;
                }
                else
                {
                    triangles = newTrianglesMid;
                }
                
                if (!flipped)
                {
                    triangles.Add(bottom_left);
                    triangles.Add(top_left);
                    triangles.Add(bottom_right);

                    triangles.Add(bottom_right);
                    triangles.Add(top_left);
                    triangles.Add(top_right);
                }
                else
                {
                    triangles.Add(bottom_left);
                    triangles.Add(top_left);
                    triangles.Add(top_right);

                    triangles.Add(top_right);
                    triangles.Add(bottom_right);
                    triangles.Add(bottom_left);
                }
            }
            
        }

        for (int i = 0; i < newVertices.Length; i++)
        {
            //float height = Mathf.InverseLerp(minTerrainHeight, maxTerrainHeight, newVertices[i].y);

            if (newVertices[i].y >= TopThreshold)
            {
                colors[i] = TopColor;
            }
            else if (newVertices[i].y <= BottomThreshold)
            {
                colors[i] = BottomColor;
            }
            else
            {
                colors[i] = MidColor;
            }
            //colors[i] = gradient.Evaluate(height);
        }
        
        


        mesh.vertices = newVertices;
        mesh.uv = newUV;
        //mesh.triangles = triangles.ToArray();
        mesh.colors = colors;
        
        mesh.subMeshCount = 3;
        mesh.SetTriangles(newTrianglesLow, 0);
        mesh.SetTriangles(newTrianglesMid, 1);
        mesh.SetTriangles(newTrianglesHigh, 2);
        
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.RecalculateTangents();

        return mesh;
    }
}
