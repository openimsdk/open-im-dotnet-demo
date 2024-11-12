using Dawn.UI;
using System.Reflection;

namespace Dawn
{
    public partial class Application
    {
        static Dictionary<string, ImGuiWindow> registedWin = new Dictionary<string, ImGuiWindow>();

        public static T GetWindow<T>() where T : ImGuiWindow
        {
            string typeName = typeof(T).FullName;
            if (registedWin.ContainsKey(typeName))
            {
                return (T)registedWin[typeName];
            }
            else
            {
                var constructorInfo = typeof(T).GetConstructor(Type.EmptyTypes);
                if (constructorInfo != null)
                {
                    T window = (T)constructorInfo.Invoke(null);
                    window.visiable = false;
                    registedWin.Add(typeName, window);
                    return window;
                }
                else
                {
                    throw new InvalidOperationException($"Type {typeof(T).FullName} does not have a parameterless constructor.");
                }
            }
        }

        static void DrawWindow()
        {
            foreach (var window in registedWin.Values)
            {
                window.internal_onGUi();
            }
        }
    }
}