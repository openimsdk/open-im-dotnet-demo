using Dawn.UI;
using System.Reflection;

namespace Dawn
{
    public partial class Application
    {
        static List<ImGuiWindow> openingWindow = new List<ImGuiWindow>();
        static List<ImGuiWindow> openedWindow = new List<ImGuiWindow>();
        static List<ImGuiWindow> delWindow = new List<ImGuiWindow>();

        public static T GetWindow<T>() where T : ImGuiWindow
        {
            var constructorInfo = typeof(T).GetConstructor(Type.EmptyTypes);
            if (constructorInfo != null)
            {
                T window = (T)constructorInfo.Invoke(null);
                window.visiable = false;
                openingWindow.Add(window);
                return window;
            }
            else
            {
                throw new InvalidOperationException($"Type {typeof(T).FullName} does not have a parameterless constructor.");
            }
        }
        public static void DelWindow(ImGuiWindow window)
        {
            delWindow.Add(window);
        }

        static void DrawWindow()
        {
            foreach (var window in openedWindow)
            {
                window.internal_onGUi();
            }
            if (openingWindow.Count > 0)
            {
                foreach (var window in openingWindow)
                {
                    openedWindow.Add(window);
                }
                openingWindow.Clear();
            }
            if (delWindow.Count > 0)
            {
                foreach (var window in delWindow)
                {
                    if (openedWindow.Contains(window))
                    {
                        openedWindow.Remove(window);
                    }
                    if (openingWindow.Contains(window))
                    {
                        openingWindow.Remove(window);
                    }
                }
                delWindow.Clear();
            }
        }
    }
}