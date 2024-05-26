using Minecraft.Tools;

using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Minecraft.Renderer;

internal class RenderWindow : GameWindow
{
    public RenderWindow(int width, int height, string name) : base(GameWindowSettings.Default, new NativeWindowSettings {Title = name})
    {
        Variables.ScreenWidth = width;
        Variables.ScreenHeight = height;
        Variables.WindowName = name;
        
        CenterWindow(new Vector2i(width, height));
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        Renderer.OnResizeWindow(e);
    }

    protected override void OnLoad()
    {
        base.OnLoad();
        Renderer.OnLoadWindow();
    }
    
    protected override void OnUnload()
    {
        base.OnUnload();
        Renderer.OnUnloadWindow();
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        Renderer.OnRenderFrameWindow(Context);
        base.OnRenderFrame(args);
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
    }
}