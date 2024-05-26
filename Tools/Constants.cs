using OpenTK.Mathematics;

namespace Minecraft.Tools;

public class Constants
{
    public static List<Vector3> Vertices = new List<Vector3>()
    {
        // front face
        new Vector3(-0.5f, 0.5f, 0.5f), // topleft vert
        new Vector3(0.5f, 0.5f, 0.5f), // topright vert
        new Vector3(0.5f, -0.5f, 0.5f), // bottomright vert
        new Vector3(-0.5f, -0.5f, 0.5f), // bottomleft vert
        // right face
        new Vector3(0.5f, 0.5f, 0.5f), // topleft vert
        new Vector3(0.5f, 0.5f, -0.5f), // topright vert
        new Vector3(0.5f, -0.5f, -0.5f), // bottomright vert
        new Vector3(0.5f, -0.5f, 0.5f), // bottomleft vert
        // back face
        new Vector3(0.5f, 0.5f, -0.5f), // topleft vert
        new Vector3(-0.5f, 0.5f, -0.5f), // topright vert
        new Vector3(-0.5f, -0.5f, -0.5f), // bottomright vert
        new Vector3(0.5f, -0.5f, -0.5f), // bottomleft vert
        // left face
        new Vector3(-0.5f, 0.5f, -0.5f), // topleft vert
        new Vector3(-0.5f, 0.5f, 0.5f), // topright vert
        new Vector3(-0.5f, -0.5f, 0.5f), // bottomright vert
        new Vector3(-0.5f, -0.5f, -0.5f), // bottomleft vert
        // top face
        new Vector3(-0.5f, 0.5f, -0.5f), // topleft vert
        new Vector3(0.5f, 0.5f, -0.5f), // topright vert
        new Vector3(0.5f, 0.5f, 0.5f), // bottomright vert
        new Vector3(-0.5f, 0.5f, 0.5f), // bottomleft vert
        // bottom face
        new Vector3(-0.5f, -0.5f, 0.5f), // topleft vert
        new Vector3(0.5f, -0.5f, 0.5f), // topright vert
        new Vector3(0.5f, -0.5f, -0.5f), // bottomright vert
        new Vector3(-0.5f, -0.5f, -0.5f) // bottomleft vert
    };
    
    public static List<Vector2> TexCoords = new List<Vector2>()
    {
        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(0f, 0f),

        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(0f, 0f),

        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(0f, 0f),

        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(0f, 0f),

        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(0f, 0f),

        new Vector2(0f, 1f),
        new Vector2(1f, 1f),
        new Vector2(1f, 0f),
        new Vector2(0f, 0f)
    };

    public static uint[] Indeces =
    {
        0, 1, 2,

        2, 3, 0,

        4, 5, 6,
        6, 7, 4,

        8, 9, 10,
        10, 11, 8,

        12, 13, 14,
        14, 15, 12,

        16, 17, 18,
        18, 19, 16,

        20, 21, 22,
        22, 23, 20
    };
    
    public static float Speed = 8f;
    public static float ScreenWidth;
    public static float ScreenHeight;
    public static float Sensitivity = 80f;
    
    public static Vector3 Up = Vector3.UnitY;
    public static Vector3 Front = -Vector3.UnitZ;
    public static Vector3 Right = Vector3.UnitX;
    
    public static float Yaw = -90.0f;
}