namespace GroList
{
    class Program
    {
        static void Main(string[] args)
        {

            int option = 0;
            while ((option = Menu.Prompt()) != Menu.Options.Length)
            {
                switch (option)
                {
                    case 1:
                        ListMenu.NewListMenu();
                        break;
                    case 2:
                        Search.SavedSearch();
                        break;
                    case 3:
                        Other.AboutGroList();
                        break;
                }
            }

            //Main menu needs to be selectable to print out other options.
            //Categories option should print out a list of categories. 
            //New list should start the user on creating a new list.
            //Saved lists should print out saved lists sorted newest to oldest. Maybe they should be able to choose a date range or specific date?

        }

    }
}
