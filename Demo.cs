using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using imgui.backend;
using ImGuiNET;
public class Demo : GameWindow
{
    ImGuiBackEnd imguiBackEnd;
    LoginWindow login;
    MainWindow main;
    public Demo() : base(GameWindowSettings.Default, new NativeWindowSettings() { StartVisible = true, APIVersion = new Version(4, 6) })
    {
        Title = "OpenIM_SDK_DEMO";
        imguiBackEnd = new ImGuiBackendOpenGL();
        WindowState = WindowState.Normal;
        int w = 900;
        int h = 700;
        MinimumSize = new Vector2i(w, h);
        MaximumSize = MinimumSize;

        login = new LoginWindow("Login", new Rect(w / 4, h / 4, w / 2, h / 2));
        main = new MainWindow("MainWindow", new Rect(0, 0, w, h));
    }
    protected override void OnLoad()
    {
        base.OnLoad();

        if (User.Instance.Init())
        {
            IsVisible = true;
        }
        else
        {
            Debug.Log("Init Sdk Error");
            Close();
        }
    }
    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
        imguiBackEnd.WindowResized(ClientSize.X, ClientSize.Y);
        // OnRenderFrame(new FrameEventArgs(0));
    }
    protected override void OnMove(WindowPositionEventArgs e)
    {
        base.OnMove(e);
        // OnRenderFrame(new FrameEventArgs(0));
    }
    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        User.Instance.Update();
    }
    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.ClearColor(new Color4(1.0f, 1.0f, 1.0f, 1.0f));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        imguiBackEnd.StartFrame();
        if (User.Instance.ConnectStatus == ConnectStatus.ConnectSuc)
        {
            main.OnDraw();
        }
        else
        {
            login.OnDraw();
        }
        imguiBackEnd.OnEndFrame((float)e.Time);
        imguiBackEnd.UpdateImGuiInput(this);
        SwapBuffers();
    }

    protected override void OnTextInput(TextInputEventArgs e)
    {
        base.OnTextInput(e);
        imguiBackEnd.PressChar((char)e.Unicode);
    }

    protected override void OnMouseWheel(MouseWheelEventArgs e)
    {
        base.OnMouseWheel(e);
        imguiBackEnd.MouseScroll(e.Offset);
    }
    protected override void OnUnload()
    {
        base.OnUnload();
        imguiBackEnd.Dispose();
    }
}