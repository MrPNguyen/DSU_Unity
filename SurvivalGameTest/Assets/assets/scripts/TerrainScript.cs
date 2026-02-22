using UnityEngine;
using UnityEngine.UI;

//Max gräns 255 på resolution och size
[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TerrainScript : MonoBehaviour
{
    private Terrain terrain;
    
    private Vector2 textureSize;
    
    [Header("Values")]
    [Range(0f, 255f)]
    [SerializeField] private int resolution = 1;
    
    [Range(0f, 255f)]
    [SerializeField] private float size = 1f;

    [Range(0f, 10f)]
    [SerializeField] private int textureSizeX = 1;
    
    [Range(0f, 10f)]
    [SerializeField] private int textureSizeY = 1;
    
    [Range(0f, 20f)]
    [SerializeField] private int highThreshold = 1;
    
    [Range(0f, 20f)]
    [SerializeField] private int bottomThreshold = 1;
    
    [Range(0f, 100f)]
    [SerializeField] private float heightMapScale = 1f;
    
    [SerializeField] private bool SwitchTriangles;

    [Header("Color & Materials")]
    [SerializeField] private Color TopColor;
    
    [SerializeField] private Color MidColor;
    
    [SerializeField] private Color BottomColor;
    
    [SerializeField] private Material TopMaterial;
    
    [SerializeField] private Material MidMaterial;
    
    [SerializeField] private Material BottomMaterial;
    
    [Header("References")]
    [SerializeField] private Texture2D heightMapImage;

    private int index;
    void Start()
    {
        Regenerate();
    }
    
    public void Regenerate()
    {
        if (terrain == null) terrain = new Terrain();
        Mesh mesh = terrain.Regenerate(resolution, size, SwitchTriangles, heightMapImage, heightMapScale, TopColor, MidColor, BottomColor, highThreshold, bottomThreshold);
        mesh.name = "TerrainMesh";
        
        GetComponent<MeshFilter>().mesh = mesh;

        Renderer renderer = GetComponent<MeshRenderer>();
        
        Material[] mats = renderer.sharedMaterials;
        
        mats[0] = BottomMaterial;
        mats[1] = MidMaterial;
        mats[2] = TopMaterial;
        
        renderer.sharedMaterials = mats;
        
        textureSize = new Vector2(textureSizeX, textureSizeY);
        renderer.sharedMaterial.mainTextureScale = textureSize;
    }
}
