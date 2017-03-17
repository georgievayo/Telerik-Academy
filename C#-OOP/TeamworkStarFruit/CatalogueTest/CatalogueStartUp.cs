namespace CatalogueTest
{
    using MenuLib;

    public class CatalogueStartUp
    {
        private const string initialPageInMenu = "1";

        static void Main()
        {
            Menu m = new Menu();
            Menu.CreateMenu();
            Menu.ShowMenu(initialPageInMenu);
            m.Navigate();
        }
    }
}
