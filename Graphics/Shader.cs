using Minecraft.Tools;

using OpenTK.Graphics.OpenGL4;

namespace Minecraft.Graphics;

internal class Shader
{
    private static string LoadShaderSource(string fileName)
    {
        string shaderSource = "";

        try
        {
            using (StreamReader reader = new StreamReader("../../../Assets/Shaders/" + fileName))
            {
                shaderSource = reader.ReadToEnd();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Failed to load shader: " + e.Message);
        }

        return shaderSource;
    }

    public static void LoadShader()
    {
        Variables.ShaderProgram = GL.CreateProgram();

        int vertexShader = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShader, LoadShaderSource("Default.vert"));
        GL.CompileShader(vertexShader);
        
        int fragShader = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragShader, LoadShaderSource("Default.frag"));
        GL.CompileShader(fragShader);
        
        GL.AttachShader(Variables.ShaderProgram, vertexShader);
        GL.AttachShader(Variables.ShaderProgram, fragShader);
        
        GL.LinkProgram(Variables.ShaderProgram);
        
        GL.DeleteShader(vertexShader);
        GL.DeleteShader(fragShader);
    }
}