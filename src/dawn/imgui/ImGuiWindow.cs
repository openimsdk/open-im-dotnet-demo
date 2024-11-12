
using System.Numerics;
using ImGuiNET;
using Microsoft.VisualBasic;

namespace Dawn.UI
{
    public class ImGuiWindow
    {
        public bool visiable;
        public string title;
        protected Rect rect;
        public ImGuiWindow()
        {
            title = "default";
            rect = new Rect(50, 50, 300, 300);
        }

        public void internal_onGUi()
        {
            if (visiable)
            {
                ImGui.SetNextWindowSize(new Vector2(rect.w, rect.h));
                ImGui.SetNextWindowPos(new Vector2(rect.x, rect.y), ImGuiCond.FirstUseEver);
                if (ImGui.Begin(title, ref visiable))
                {
                    var pos = ImGui.GetWindowPos();
                    var size = ImGui.GetWindowSize();
                    rect.x = pos.X;
                    rect.y = pos.Y;
                    rect.w = size.X;
                    rect.h = size.Y;
                    OnGUI();
                    ImGui.End();
                }
                else
                {
                    OnClose();
                }
            }
        }
        public virtual void OnEnable()
        {

        }
        public virtual void OnGUI()
        {

        }
        public virtual void OnClose()
        {

        }

        public void Close()
        {
            visiable = false;
            OnClose();
        }

        public static T GetWindow<T>() where T : ImGuiWindow
        {
            return Application.GetWindow<T>();
        }

        public void Show(string title)
        {
            this.title = title;
            visiable = true;
            OnEnable();
        }
    }
}

