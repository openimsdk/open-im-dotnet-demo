using ImGuiNET;
using System.Numerics;


public abstract class ImGuiWindow
{
    protected string title;
    protected Rect position;
    public ImGuiWindow(string title, Rect position)
    {
        this.title = title;
        this.position = position;
    }
    public virtual void OnDraw()
    {
        ImGui.PushStyleColor(ImGuiCol.WindowBg, 0x00FFFFFF);
        ImGui.SetNextWindowPos(new Vector2(position.x, position.y));
        ImGui.SetNextWindowSize(new Vector2(position.w, position.h), ImGuiCond.Always);
        ImGui.Begin(title);
        ImGui.End();
        ImGui.PopStyleColor();
    }
}