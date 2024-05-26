using Minecraft.Tools;

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Minecraft.Renderer;

internal class Camera
{
    public Camera() { }

    public Camera(float width, float height, Vector3 position)
    {
        Constants.ScreenWidth = width;
        Constants.ScreenHeight = height;
        Variables.Position = position;
    }

    public Matrix4 GetViewMatrix()
    {
        return Matrix4.LookAt(Variables.Position, Variables.Position + Constants.Front, Constants.Up);
    }

    public Matrix4 GetProjectionMatrix()
    {
        return Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45.0f), Constants.ScreenWidth / Constants.ScreenHeight, 0.1f, 100.0f);
    }

    private void UpdateVectors()
    {
        if (Variables.Pitch > 89.0f)
        {
            Variables.Pitch = 89.0f;
        }

        if (Variables.Pitch < -89.0f)
        {
            Variables.Pitch = -89.0f;
        }


        Constants.Front.X = MathF.Cos(MathHelper.DegreesToRadians(Variables.Pitch)) * MathF.Cos(MathHelper.DegreesToRadians(Constants.Yaw));
        Constants.Front.Y = MathF.Sin(MathHelper.DegreesToRadians(Variables.Pitch));
        Constants.Front.Z = MathF.Cos(MathHelper.DegreesToRadians(Variables.Pitch)) * MathF.Sin(MathHelper.DegreesToRadians(Constants.Yaw));

        Constants.Front = Vector3.Normalize(Constants.Front);

        Constants.Right = Vector3.Normalize(Vector3.Cross(Constants.Front, Vector3.UnitY));
        Constants.Up = Vector3.Normalize(Vector3.Cross(Constants.Right, Constants.Front));
    }

    public void InputController(KeyboardState input, MouseState mouse, FrameEventArgs e)
    {
        if (input.IsKeyDown(Keys.W))
        {
            Variables.Position += Constants.Front * Constants.Speed * (float)e.Time;
        }

        if (input.IsKeyDown(Keys.A))
        {
            Variables.Position -= Constants.Right * Constants.Speed * (float)e.Time;
        }

        if (input.IsKeyDown(Keys.S))
        {
            Variables.Position -= Constants.Front * Constants.Speed * (float)e.Time;
        }

        if (input.IsKeyDown(Keys.D))
        {
            Variables.Position += Constants.Right * Constants.Speed * (float)e.Time;
        }

        if (input.IsKeyDown(Keys.Space))
        {
            Variables.Position.Y += Constants.Speed * (float)e.Time;
        }

        if (input.IsKeyDown(Keys.LeftShift))
        {
            Variables.Position.Y -= Constants.Speed * (float)e.Time;
        }

        if (Variables.FirstMove)
        {
            Variables.LastPos = new Vector2(mouse.X, mouse.Y);
            Variables.FirstMove = false;
        }
        else
        {
            var deltaX = mouse.X - Variables.LastPos.X;
            var deltaY = mouse.Y - Variables.LastPos.Y;
            Variables.LastPos = new Vector2(mouse.X, mouse.Y);

            Constants.Yaw += deltaX * Constants.Sensitivity * (float)e.Time;
            Variables.Pitch -= deltaY * Constants.Sensitivity * (float)e.Time;
        }

        UpdateVectors();
    }

    public void Update(KeyboardState input, MouseState mouse, FrameEventArgs e)
    {
        InputController(input, mouse, e);
    }
}