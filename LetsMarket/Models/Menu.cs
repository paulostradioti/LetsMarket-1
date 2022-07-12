namespace LetsMarket.Models
{

    public class Menu
    {
        public readonly string UNSELECTED = "|     ";
        public readonly string SELECTED = "|   » ";
        public readonly int LINE_WIDTH = Console.WindowWidth / 3;//50;

        public MenuType Type { get; }
        public static Menu _root;
        public Menu parent = null;
        public string title;
        public List<Menu> items;
        public Action action;

        public int selectedIndex = 0;
        public Menu(string title)
        {
            this.title = title;
            items = new List<Menu>();
            if (_root == null) _root = this;
            Type = MenuType.Submenu;
        }

        public Menu(string title, Action action) : this(title)
        {
            this.action = action;
            Type = MenuType.Command;
        }

        public void Add(Menu menuItem)
        {
            menuItem.parent = this;
            items.Add(menuItem);
        }

        public override string ToString()
        {
            return title;
        }
    }

    public enum MenuType
    {
        Submenu,
        Command
    }
}
