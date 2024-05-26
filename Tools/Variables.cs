using Minecraft.Renderer;

using OpenTK.Mathematics;

namespace Minecraft.Tools;

internal class Variables
{
    public static Camera Camera;
    
    public static int ScreenWidth;
    public static int ScreenHeight;

    public static string WindowName;

    public static int Vao;
    public static int Ebo;
    public static int ShaderProgram;
    public static int TextureId;
    public static int TextureVbo;

    public static float YRotation = 0f;
    
    public static Vector3 Position;
    public static float Pitch;
    public static bool FirstMove = true;
    public static Vector2 LastPos;
}