using Dawn.UI;
using ImGuiNET;
using System.Reflection;

namespace Dawn
{
    public partial class Application
    {
        static MenuItem rootMenuItem = new MenuItem
        {
            Name = "Root"
        };
        static MenuItem GetMenuItem(MenuItem parent, string name)
        {
            if (parent == null) return null; ;
            MenuItem menuItem = null;
            if (parent.Childs == null)
            {
                parent.Childs = new List<MenuItem>();
            }
            foreach (MenuItem item in parent.Childs)
            {
                if (item.Name == name)
                {
                    menuItem = item;
                }
            }
            if (menuItem == null)
            {
                menuItem = new MenuItem
                {
                    Name = name
                };
                parent.Childs.Add(menuItem);
            }
            return menuItem;
        }
        static void AddMenuItem(string name, Action callBack)
        {
            string[] parts = name.Split('/');
            var menuItem = rootMenuItem;
            for (int i = 0; i < parts.Length; i++)
            {
                menuItem = GetMenuItem(menuItem, parts[i]);
            }
            menuItem.OnClick = callBack;
        }
        static void ParseMainMenuBar()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                MethodInfo[] staticMethods = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
                foreach (var method in staticMethods)
                {
                    var attribute = method.GetCustomAttributes(typeof(MenuItemAttribute), false).FirstOrDefault();
                    if (attribute != null)
                    {
                        var menuItem = attribute as MenuItemAttribute;
                        Action callBack = (Action)Delegate.CreateDelegate(typeof(Action), method);
                        AddMenuItem(menuItem.itemName, callBack);
                    }
                }
            }
            if (rootMenuItem.Childs.Count > 0)
            {
                List<string> sortOrder = new List<string> { "Start", "User", "Friend", "Group", "Conversation", "Help" };
                rootMenuItem.Childs.Sort((x, y) =>
                {
                    return sortOrder.IndexOf(x.Name).CompareTo(sortOrder.IndexOf(y.Name));
                });
            }
        }
        static void DrawMenuItem(MenuItem item)
        {
            if (item.Childs != null && item.Childs.Count > 0)
            {
                if (ImGui.BeginMenu(item.Name))
                {
                    foreach (var child in item.Childs)
                    {
                        DrawMenuItem(child);
                    }
                    ImGui.EndMenu();
                }

            }
            else
            {
                if (ImGui.MenuItem(item.Name))
                {
                    if (item.OnClick != null)
                    {
                        item.OnClick();
                    }
                }
            }
        }
        static void DrawMainMenu()
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (rootMenuItem.Childs != null)
                {
                    foreach (var item in rootMenuItem.Childs)
                    {
                        DrawMenuItem(item);
                    }
                }
                ImGui.EndMainMenuBar();
            }
        }
    }
}