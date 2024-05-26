using Minecraft.Tools;
using Minecraft.Graphics;

using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Minecraft.Renderer;

internal class Renderer
{
    public static void OnResizeWindow(ResizeEventArgs e)
    {
        GL.Viewport(0, 0, e.Width, e.Height);

        Variables.ScreenWidth = e.Width;
        Variables.ScreenHeight = e.Height;
    }
    
    public static void OnLoadWindow()
    {
        Variables.Vao = GL.GenVertexArray();
        GL.BindVertexArray(Variables.Vao);
        int vbo = GL.GenBuffer();
        
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, Variables.Vertices.Count * Vector3.SizeInBytes, Variables.Vertices.ToArray(), BufferUsageHint.StaticDraw);
        
        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        
        Variables.TextureVbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, Variables.TextureVbo);
        GL.BufferData(BufferTarget.ArrayBuffer, Variables.TexCoords.Count * Vector2.SizeInBytes, Variables.TexCoords.ToArray(), BufferUsageHint.StaticDraw);
        
        GL.BindVertexArray(Variables.Vao);
        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 0, 0);
        GL.EnableVertexAttribArray(1);
        
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindVertexArray(0);

        Variables.Ebo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, Variables.Ebo);
        GL.BufferData(BufferTarget.ElementArrayBuffer, Variables.Indeces.Length * sizeof(uint), Variables.Indeces, BufferUsageHint.StaticDraw);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
        
        Shader.LoadShader();
        Texture.LoadTexture();
        
        GL.Enable(EnableCap.DepthTest);
    }

    public static void OnUnloadWindow()
    {
        GL.DeleteVertexArray(Variables.Vao);
        GL.DeleteBuffer(Variables.Ebo);
        GL.DeleteTexture(Variables.TextureId);
        GL.DeleteProgram(Variables.ShaderProgram);
    }

    public static void OnRenderFrameWindow(IGLFWGraphicsContext context)
    {
        GL.ClearColor(0.6f, 0.3f, 1f, 1f);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        
        GL.UseProgram(Variables.ShaderProgram);
        GL.BindVertexArray(Variables.Vao);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, Variables.Ebo);
        GL.BindTexture(TextureTarget.Texture2D, Variables.TextureId);

        Matrix4 model = Matrix4.Identity;
        Matrix4 view = Matrix4.Identity;
        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60.0f), Variables.ScreenWidth / Variables.ScreenHeight, 0.1f, 100.0f);

        model = Matrix4.CreateRotationY(Variables.YRotation);
        Variables.YRotation += 0.001f;
        Matrix4 translation = Matrix4.CreateTranslation(0f, 0f, -3f);
        model *= translation;
        
        int modelLocation = GL.GetUniformLocation(Variables.ShaderProgram, "model");
        int viewLocation = GL.GetUniformLocation(Variables.ShaderProgram, "view");
        int projectionLocation = GL.GetUniformLocation(Variables.ShaderProgram, "projection");
        
        GL.UniformMatrix4(modelLocation, true, ref model);
        GL.UniformMatrix4(viewLocation, true, ref view);
        GL.UniformMatrix4(projectionLocation, true, ref projection);
        
        GL.DrawElements(PrimitiveType.Triangles, Variables.Indeces.Length, DrawElementsType.UnsignedInt, 0);
        
        context.SwapBuffers();
    }
}