using Minecraft.Renderer;

namespace Minecraft;

internal class Program
{
    static void Main(string[] args)
    {
        using (RenderWindow window = new RenderWindow(1080, 1080, "Minecraft on C#"))
        {
            window.Run();
        }
    }
} 