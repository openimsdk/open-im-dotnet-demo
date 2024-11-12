namespace Dawn
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MenuItemAttribute : Attribute
    {
        public string itemName;
        public int priority;

        public MenuItemAttribute(string itemName, int priority = 0)
        {
            this.itemName = itemName;
            this.priority = priority;
        }
    }
}