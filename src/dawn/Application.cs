using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System.Diagnostics;
using ImGuiNET;
using Dawn.UI.BackEnd;
using Dawn.UI;

namespace Dawn
{
    public partial class Application : GameWindow
    {
        ImGuiBackEnd imguiBackEnd;
        public static string persistentDataPath
        {
            get
            {
                return Path.Combine(AppContext.BaseDirectory, "temp");
            }
        }

        public Application(string title, int width, int height) : base(GameWindowSettings.Default, new NativeWindowSettings() { StartVisible = true, APIVersion = new Version(4, 1) })
        {
            Title = title;
            MinimumSize = new Vector2i(width, height);
            // MaximumSize = MinimumSize;
            imguiBackEnd = new ImGuiBackendOpenGL();
            WindowState = WindowState.Normal;
        }
        protected override void OnLoad()
        {
            base.OnLoad();

            IsVisible = true;
            UpdateFrequency = 60;
            ParseMainMenuBar();
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, ClientSize.X, ClientSize.Y);
            if (imguiBackEnd != null)
            {
                imguiBackEnd.WindowResized(ClientSize.X, ClientSize.Y);
            }
        }
        protected override void OnMove(WindowPositionEventArgs e)
        {
            base.OnMove(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
        }
        protected virtual void OnGUI() { }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.ClearColor(new Color4(1.0f, 1.0f, 1.0f, 1.0f));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            imguiBackEnd.StartFrame();
            OnGUI();
            DrawMainMenu();
            DrawWindow();
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
        public static void OpenUrl(string url)
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
    }
}

