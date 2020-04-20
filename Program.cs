using System;
using System.Collections.Generic;

using System.Data.SqlClient;
using System.Data.Common;
using System.Configuration;


namespace Pick_My_Look
{
    class Program
    {
        private static bool MainMenu()
        {
            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Pick my look");
            Console.WriteLine("2) Pick a random look");
            Console.WriteLine("3) Add new make up");
            Console.WriteLine("4) Remove makeup");
            Console.WriteLine("5) Exit");

            String uInput;
            switch (Console.ReadLine())
            {
                case "1":
                    PickLook();
                    Console.WriteLine("Would you like to return to the main menu? (y/n)");
                    uInput = Console.ReadLine().ToLower().Trim();
                    while (uInput != "y" && uInput != "n")
                    {
                        Console.WriteLine("Please enter either y or n");  //Ensures no unexpected input
                        uInput = Console.ReadLine().ToLower().Trim();
                    }
                    if (uInput == "y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                case "2":
                    PickRandom();
                    Console.WriteLine("Would you like to return to the main menu? (y/n)");
                    uInput = Console.ReadLine().ToLower().Trim();
                    while (uInput != "y" && uInput != "n")
                    {
                        Console.WriteLine("Please enter either y or n");  //Ensures no unexpected input
                        uInput = Console.ReadLine().ToLower().Trim();
                    }
                    if (uInput == "y")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case "3":
                    AddMakeup();
                    return true;
                case "4":
                    RemoveMakeup();
                    return true;
                case "5":
                    return false;
                default:
                    return true;
            }
        }
        private static List<string> EyeShadowDB(string color, int Layer)
        {
            List<string> RandomPick = new List<string>();

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                command.Connection = connection;
                    command.CommandText = ("SELECT TOP 1 * FROM EyeShadow WHERE Color = '" + color + "' AND Layer = " + Layer + " ORDER BY NEWID() ");
                
                using (DbDataReader dataReader = command.ExecuteReader())
                    {
                        
                        // Advance to the next results
                        while (dataReader.Read())
                        {
                        RandomPick.Add($"{dataReader["PaletteName"]}");
                        RandomPick.Add($"{dataReader["ShadeName"]}");
                        RandomPick.Add($"{dataReader["Color"]}");
                        RandomPick.Add($"{dataReader["Layer"]}");


                        
                        // Output results
                        //Console.WriteLine($"{dataReader["PaletteName"]} " + $"{dataReader["ShadeName"]} " + $"{dataReader["Color"]} " + $"{dataReader["Layer"]} ");
                        }
                    }
            }
            return RandomPick;
        }

        private static List<string> BlushDB(string Color)
        {
            List<string> RandomPick = new List<string>();

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                command.Connection = connection;
                command.CommandText = ("SELECT TOP 1 * FROM Blush WHERE Color = '" + Color + "' ORDER BY NEWID() ");

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    while (dataReader.Read())
                    {
                        RandomPick.Add($"{dataReader["Brand"]}");
                        RandomPick.Add($"{dataReader["Name"]}");
                        RandomPick.Add($"{dataReader["Color"]}");

                        // Output results
                        //Console.WriteLine($"{dataReader["Brand"]} " + $"{dataReader["Name"]} " + $"{dataReader["Color"]} ");
                    }
                }
            }
            return RandomPick;
        }

        private static List<string> LipstickDB(string Color)
        {
            List<string> RandomPick = new List<string>();

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                command.Connection = connection;
                command.CommandText = ("SELECT TOP 1 * FROM Lipstick WHERE Color = '" + Color + "' ORDER BY NEWID() ");

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    while (dataReader.Read())
                    {
                        RandomPick.Add($"{dataReader["Brand"]}");
                        RandomPick.Add($"{dataReader["Name"]}");
                        RandomPick.Add($"{dataReader["Color"]}");

                        // Output results
                        //Console.WriteLine($"{dataReader["Brand"]} " + $"{dataReader["Name"]} " + $"{dataReader["Color"]} ");
                    }
                }
            }
            return RandomPick;
        }

        private static List<string> HighlighterDB(string Color)
        {
            List<string> RandomPick = new List<string>();

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                    return RandomPick;
                }

                command.Connection = connection;
                command.CommandText = ("SELECT TOP 1 * FROM Highlighter WHERE Color = '" + Color + "' ORDER BY NEWID() ");

                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    // Advance to the next results
                    while (dataReader.Read())
                    {
                        RandomPick.Add($"{dataReader["Brand"]}");
                        RandomPick.Add($"{dataReader["Name"]}");
                        RandomPick.Add($"{dataReader["Color"]}");

                        // Output results
                        //Console.WriteLine($"{dataReader["Brand"]} " + $"{dataReader["Name"]} " + $"{dataReader["Color"]} ");
                    }
                }
            }
            return RandomPick;
        }
        private static void PickLook()
        {
            string colorChoice;
            List<string> AllColors = new List<string>() { "yellow", "green", "blue", "purple", "red", "pink", "orange", "black", "copper", "gold", "silver", "brown", "gray", "white" };
            List<string> ComplimentaryColors = new List<string>();
            

            Console.WriteLine("Enter a color (red, green, blue, etc)");

            colorChoice = Console.ReadLine();
            colorChoice = colorChoice.ToLower().Trim();

            if (colorChoice == "yellow")
            {
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("green");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("copper");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("black");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "green")
            {
                ComplimentaryColors.Add("green");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("copper");
                ComplimentaryColors.Add("white");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "blue")
            {
                ComplimentaryColors.Add("green");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("copper");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("gray");
                ComplimentaryColors.Add("white");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "purple")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("copper");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("gray");
                ComplimentaryColors.Add("white");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "red")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("copper");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("white");
                LookSearch(ComplimentaryColors, colorChoice);

            }
            else if (colorChoice == "pink")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("white");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "orange")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("copper");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("white");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "black")
            {
                LookSearch(AllColors, colorChoice);
            }
            else if (colorChoice == "copper")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("green");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("white");
                ComplimentaryColors.Add("brown");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "gold")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("gold");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("green");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("white");
                ComplimentaryColors.Add("gray");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "silver")
            {
                ComplimentaryColors.Add("red");
                ComplimentaryColors.Add("orange");
                ComplimentaryColors.Add("brown");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("green");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("pink");
                ComplimentaryColors.Add("yellow");
                ComplimentaryColors.Add("white");
                ComplimentaryColors.Add("gray");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "brown")
            {
                LookSearch(AllColors, colorChoice);
            }
            else if (colorChoice == "gray")
            {
                ComplimentaryColors.Add("white");
                ComplimentaryColors.Add("black");
                ComplimentaryColors.Add("silver");
                ComplimentaryColors.Add("blue");
                ComplimentaryColors.Add("purple");
                ComplimentaryColors.Add("gray");
                LookSearch(ComplimentaryColors, colorChoice);
            }
            else if (colorChoice == "white")
            {
                LookSearch(AllColors, colorChoice);
            }
            else
            {
                Console.WriteLine("Error. No color matches found");
            }
        }

        private static void LookSearch(List<string> colors, string Color)
        {
            List<string> RandomPick = new List<string>();
            Random rnd = new Random();
            int max = colors.Count;
            int color = rnd.Next(0, max);
            int j = 1;
            int n = 1;

            string UInput = "y";
            string UserColor = Color;
            string colorChoice = "nope";
            string Highlighter = "nope";
            string Blush = "nope";
            string Lipstick = "nope";
            List<string> Layer5 = new List<string>();
            List<string> Shade5 = new List<string>();

            Console.WriteLine();
            Console.WriteLine("Would you like a 3 layer look or a 5 layer look?(3/5)");

            string Layers = Console.ReadLine();
            int Layer = Convert.ToInt32(Layers);

            while(Layer != 3 && Layer != 5)
            {
                Console.WriteLine("Please enter either 3 or 5");
                Layers = Console.ReadLine();
                Layer = Convert.ToInt32(Layers);
            }
            for (int i = 1; i < Layer + 1; i++)
            {
                //Layer 3 for 5 layer or 2 for 3 layer use user color to ensure color choice
                if (Layer == 3)
                {
                    if (i == 2)
                    {
                        colorChoice = UserColor;
                        RandomPick = EyeShadowDB(UserColor, (j));
                        while (RandomPick.Count == 0 && (j + n) <= Layer)
                        {
                            RandomPick = EyeShadowDB(UserColor, (j + n));
                            n++;
                        }
                    }
                    else
                    {
                        color = rnd.Next(0, max);
                        colorChoice = colors[color];
                        RandomPick = EyeShadowDB(colorChoice, (j));
                    }
                }
                if (Layer == 5)
                {
                    if (i == 3)
                    {
                        colorChoice = UserColor;
                        RandomPick = EyeShadowDB(UserColor, (j)); 
                        while(RandomPick.Count == 0 && (j + n) <= Layer)
                        {
                            RandomPick = EyeShadowDB(UserColor, (j + n));
                            n++;
                        }
                    }
                    else
                    {
                        color = rnd.Next(0, max);
                        colorChoice = colors[color];
                        RandomPick = EyeShadowDB(colorChoice, (j));
                    }
                }

                //If no option found try another color
                while (RandomPick.Count == 0)
                {
                    foreach (string Choice in colors)
                    {

                        colorChoice = Choice;
                        RandomPick = EyeShadowDB(Choice, (j));
                        if (RandomPick.Count != 0)
                        {
                            break;
                        }
                    }
                    
                }

                Console.Write("Layer: {0} ", j);
                Console.Write(" Palette Name: {0}", RandomPick[0]);
                Console.Write(" Shade Name: {0}", RandomPick[1]);
                Console.WriteLine("");

                //Color check to ensure all matches will go togetehr with the two colors, User color gives starting list and the first random color slims choices down
                if(i == 1)
                {
                    if(colorChoice == "yellow")
                    {
                        colors.Remove("purple");
                        colors.Remove("gray");

                    }
                    if (colorChoice == "green")
                    {
                        colors.Remove("red");
                        colors.Remove("orange");
                        colors.Remove("purple");
                        colors.Remove("gray");

                    }
                    if (colorChoice == "blue")
                    {
                        colors.Remove("red");
                        colors.Remove("orange");
                    }
                    if (colorChoice == "purple")
                    {
                        colors.Remove("orange");
                        colors.Remove("yellow");
                        colors.Remove("green");
                    }
                    if (colorChoice == "red")
                    {
                        colors.Remove("green");
                        colors.Remove("blue");
                        colors.Remove("gray");
                    }
                    if (colorChoice == "pink")
                    {
                        colors.Remove("green");
                        colors.Remove("gray");
                        colors.Remove("copper");
                    }
                    if (colorChoice == "orange")
                    {
                        colors.Remove("green");
                        colors.Remove("blue");
                        colors.Remove("purple");
                        colors.Remove("gray");
                    }
                    if (colorChoice == "copper")
                    {
                        colors.Remove("pink");
                        colors.Remove("gray");
                        colors.Remove("gold");
                        colors.Remove("silver");
                    }
                    if (colorChoice == "gold")
                    {
                        colors.Remove("silver");
                        colors.Remove("copper");
                        colors.Remove("gray");
                    }
                    if (colorChoice == "silver")
                    {
                        colors.Remove("copper");
                        colors.Remove("gold");
                    }
                    if (colorChoice == "gray")
                    {
                        colors.Remove("red");
                        colors.Remove("orange");
                        colors.Remove("yellow");
                        colors.Remove("green");
                        colors.Remove("pink");
                        colors.Remove("gold");
                        colors.Remove("copper");
                    }
                    max = colors.Count;
                }
                Layer5.Add(colorChoice);
                Shade5.Add(RandomPick[1]);
                j++;

                if(Layer == 3)
                {
                    if(i == 2)
                    {
                        Blush = colorChoice;
                        Lipstick = colorChoice;
                    }
                    if(i == 3)
                    {
                        Highlighter = colorChoice;
                    }
                }
                if(Layer == 5)
                {
                    if (i == 3)
                    {
                        Blush = colorChoice;
                        Lipstick = colorChoice;
                    }
                    if (i == 5)
                    {
                        Highlighter = colorChoice;
                    }
                }
                RandomPick.Clear();
            }
            
            Console.WriteLine();
            string BlushName = BlushSearch(Blush, "None");
            string LipstickName = LipstickSearch(Lipstick, "None");
            string HighlighterName = HighlighterSearch(Highlighter, "None");

            while (UInput != "n")
            {
                Console.WriteLine("Would you like to change any?(y/n)");
                UInput = Console.ReadLine().ToLower().Trim();
                while (UInput != "y" && UInput != "n")
                {
                    Console.WriteLine("Please enter either y or n");
                    UInput = Console.ReadLine().ToLower().Trim();
                }
                if (UInput == "y")
                {
                    ChangeLook(Layer5, Shade5, colors, Blush, BlushName, Highlighter, HighlighterName, Lipstick, LipstickName);
                    
                }
            }
            

        }
        private static void ChangeLook(List<string> Layers, List<string> Shade, List<string> colors, string Blush, string BlushName, string Highlighter, string HighlighterName, string Lipstick, string LipstickName)
        {
            List<string> RandomPick = new List<string>();
            Random rnd = new Random();
            int max = colors.Count; 
            int color = rnd.Next(0, max);
            int j = 0;
            int MenuChoice = 0;

            string colorChoice = "nope";
            string HighlighterChoice = "nope";
            string BlushChoice = "nope";
            string LipstickChoice = "nope";

            Console.WriteLine();
            Console.WriteLine(" Which would you like to change? 1 = Eyeshadow  2 = Blush  3 = Highlighter  4 = Lipstick  5 = none");
            MenuChoice = int.Parse(Console.ReadLine());
            while (MenuChoice != 5)
            {
                switch (MenuChoice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.WriteLine("Which Layer?");
                        j = int.Parse(Console.ReadLine());
                        while(j < 1 ^ j > Layers.Count)
                        {
                            Console.WriteLine("Must select a number between 1 and {0}", Layers.Count);
                            j = int.Parse(Console.ReadLine());

                        }

                        Console.WriteLine("Would you like a new shade or a new color of Eyeshadow?");
                        string UInput = Console.ReadLine().ToLower().Trim();
                        while (UInput != "shade" && UInput != "color")
                        {
                            Console.WriteLine("Options are color or shade");
                            UInput = Console.ReadLine().ToLower().Trim();
                        }
                        if (UInput == "shade")
                        {
                            colorChoice = (Layers[j - 1]);
                            Console.WriteLine();
                            RandomPick = EyeShadowDB(colorChoice, (j - 1));
                            while (RandomPick.Count == 0)
                            {
                                foreach (string Choice in colors)
                                {


                                    RandomPick = EyeShadowDB(Choice, (j));
                                    if (RandomPick.Count != 0)
                                    {
                                        break;
                                    }
                                }

                            }
                            while (RandomPick[1] == Shade[j - 1])
                            {
                                RandomPick = EyeShadowDB(colorChoice, (j - 1));
                            }
                            Console.Write("Layer: {0} ", j);
                            Console.Write(" Palette Name: {0}", RandomPick[0]);
                            Console.Write(" Shade Name: {0}", RandomPick[1]);
                            Console.WriteLine("");
                            Console.WriteLine();
                            Layers[j - 1] = colorChoice;
                        }
                        if (UInput == "color")
                        {
                            color = rnd.Next(0, max);
                            colorChoice = colors[color];

                            while (colorChoice == Layers[j - 1])
                            {
                                color = rnd.Next(0, max);
                                colorChoice = colors[color];
                                RandomPick = EyeShadowDB(colorChoice, (j - 1));
                            }
                            while (RandomPick.Count == 0)
                            {
                                foreach (string Choice in colors)
                                {


                                    RandomPick = EyeShadowDB(Choice, (j));
                                    if (RandomPick.Count != 0)
                                    {
                                        break;
                                    }
                                }

                            }


                            Console.Write("Layer: {0} ", j);
                            Console.Write(" Palette Name: {0}", RandomPick[0]);
                            Console.Write(" Shade Name: {0}", RandomPick[1]);
                            Console.WriteLine(" Color: {0}", colorChoice);
                            Console.WriteLine();
                            Layers[j - 1] = colorChoice;
                        }
                        return;
                    case 2:
                        Console.WriteLine("Would you like a new shade or a new color of Blush?");
                        UInput = Console.ReadLine().ToLower().Trim();
                        while (UInput != "shade" && UInput != "color")
                        {
                            Console.WriteLine("Options are color or shade");
                            UInput = Console.ReadLine().ToLower().Trim();
                        }
                        if (UInput == "shade") 
                        {
                            BlushSearch(Blush, BlushName);
                           
                        }
                        if (UInput == "color")
                        {
                            color = rnd.Next(0, max);
                            BlushChoice = colors[color];

                            while (BlushChoice == Blush)
                            {
                                color = rnd.Next(0, max);
                                BlushChoice = colors[color];
                            }
                            BlushSearch(BlushChoice, BlushName);
                        }
                        return;
                    case 3:
                        Console.WriteLine("Would you like a new shade or a new color of Highlighter?");
                        UInput = Console.ReadLine().ToLower().Trim();
                        while (UInput != "shade" && UInput != "color")
                        {
                            Console.WriteLine("Options are color or shade");
                            UInput = Console.ReadLine().ToLower().Trim();
                        }
                        if (UInput == "shade")
                        {
                            HighlighterSearch(Highlighter, HighlighterName);

                        }
                        if (UInput == "color")
                        {
                            color = rnd.Next(0, max);
                            HighlighterChoice = colors[color];

                            while (HighlighterChoice == Highlighter)
                            {
                                color = rnd.Next(0, max);
                                HighlighterChoice = colors[color];
                            }
                            HighlighterSearch(HighlighterChoice, HighlighterName);

                        }
                        return;
                    case 4:
                        Console.WriteLine("Would you like a new shade or a new color of Lipstick?");
                        UInput = Console.ReadLine().ToLower().Trim();
                        while (UInput != "shade" && UInput != "color")
                        {
                            Console.WriteLine("Options are color or shade");
                            UInput = Console.ReadLine().ToLower().Trim();
                        }
                        if (UInput == "shade")
                        {
                            LipstickSearch(LipstickChoice, LipstickName);
                        }
                        if (UInput == "color")
                        {
                            color = rnd.Next(0, max);
                            LipstickChoice = colors[color];

                            while (LipstickChoice == Lipstick)
                            {
                                color = rnd.Next(0, max);
                                LipstickChoice = colors[color];
                            }

                            LipstickSearch(LipstickChoice, LipstickName);
                        }
                        return;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Please enter 1-5(5 exits)");
                        return;
                }
            }
        }
        private static void PickRandom()
        {
            Random rnd = new Random();
            int color = rnd.Next(1, 15);
            List<string> AllColors = new List<string>() { "yellow", "green", "blue", "purple", "red", "pink", "orange", "black", "copper", "gold", "silver", "brown", "gray", "white" };
            List<string> ComplimentaryColors = new List<string>();

            Console.WriteLine("Random!");

            switch (color)
            {
                case 1:
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("green");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("copper");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("black");
                    LookSearch(ComplimentaryColors, "yellow");
                    return;
                case 2:
                    ComplimentaryColors.Add("green");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("copper");
                    ComplimentaryColors.Add("white");
                    LookSearch(ComplimentaryColors, "green");
                    return;
                case 3:
                    ComplimentaryColors.Add("green");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("copper");
                    ComplimentaryColors.Add("purple");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("gray");
                    ComplimentaryColors.Add("white");
                    LookSearch(ComplimentaryColors, "blue");
                    return;
                case 4:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("copper");
                    ComplimentaryColors.Add("purple");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("gray");
                    ComplimentaryColors.Add("white");
                    LookSearch(ComplimentaryColors, "purple");
                    return;
                case 5:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("copper");
                    ComplimentaryColors.Add("purple");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("white");
                    LookSearch(ComplimentaryColors, "red");
                    return;
                case 6:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("purple");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("white");
                    LookSearch(ComplimentaryColors, "pink");
                    return;
                case 7:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("copper");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("white");
                    LookSearch(ComplimentaryColors, "orange");
                    return;
                case 8:
                    LookSearch(AllColors, "black");
                    return;
                case 9:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("green");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("purple");
                    LookSearch(ComplimentaryColors, "copper");
                    return;
                case 10:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("gold");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("green");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("purple");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("white");
                    ComplimentaryColors.Add("gray");
                    LookSearch(ComplimentaryColors, "gold");
                    return;
                case 11:
                    ComplimentaryColors.Add("red");
                    ComplimentaryColors.Add("orange");
                    ComplimentaryColors.Add("brown");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("green");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("purple");
                    ComplimentaryColors.Add("pink");
                    ComplimentaryColors.Add("yellow");
                    ComplimentaryColors.Add("white");
                    ComplimentaryColors.Add("gray");
                    LookSearch(ComplimentaryColors, "silver");
                    return;
                case 12:
                    LookSearch(AllColors, "brown");
                    return;
                case 13:
                    ComplimentaryColors.Add("white");
                    ComplimentaryColors.Add("black");
                    ComplimentaryColors.Add("silver");
                    ComplimentaryColors.Add("blue");
                    ComplimentaryColors.Add("purple");
                    LookSearch(ComplimentaryColors, "gray");
                    return;
                case 14:
                    LookSearch(AllColors, "white");
                    return;
                default:
                    Console.WriteLine("Error");
                    return;

            }

        }

        private static void AddMakeup(){
            List<string> Eyeshadow = new List<string>();
            List<string> Highlighter = new List<string>();
            List<string> Blush = new List<string>();
            List<string> Lipstick = new List<string>();


            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Add a Eyeshadow");
            Console.WriteLine("2) Add a Highlighter");
            Console.WriteLine("3) Add a Lipstick");
            Console.WriteLine("4) Add a Blush");
            Console.WriteLine("5) Return to the main menu");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please enter the PaletteName");
                    Eyeshadow.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the ShadeName");
                    Eyeshadow.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Color");
                    Eyeshadow.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Layer");
                    Eyeshadow.Add(Console.ReadLine());

                    AddEyeshadow(Eyeshadow);
                    return;
                case "2":
                    Console.WriteLine("Please enter the Brand");
                    Highlighter.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Name");
                    Highlighter.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Color");
                    Highlighter.Add(Console.ReadLine());


                    AddHighlighter(Highlighter);
                    return;
                case "3":
                    Console.WriteLine("Please enter the Brand");
                    Lipstick.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Name");
                    Lipstick.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Color");
                    Lipstick.Add(Console.ReadLine());


                    AddLipstick(Lipstick);
                    return;
                case "4":
                    Console.WriteLine("Please enter the Brand");
                    Blush.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Name");
                    Blush.Add(Console.ReadLine());

                    Console.WriteLine("Please enter the Color");
                    Blush.Add(Console.ReadLine());


                    AddBlush(Blush);
                    return;
                case "5":
                    return;
                default:
                    return;
            }
        }
    
        private static void AddEyeshadow(List<string> Eyeshadow)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("INSERT INTO Eyeshadow OUTPUT(PaletteName, ShadeName, Color, Layer) VALUES(\"" + Eyeshadow[0] + "\", \"" + Eyeshadow[1] + "\", \"" + Eyeshadow[2] + "\", \"" + Eyeshadow[3] + "\")");

            }
        }

        private static void AddHighlighter(List<string> Highlighter)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("INSERT INTO Highlighter OUTPUT(Brand, Name, Color) VALUES(\"" + Highlighter[0] + "\", \"" + Highlighter[1] + "\", \"" + Highlighter[2] + "\")");

            }
        }

        private static void AddLipstick(List<string> Lipstick)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("INSERT INTO Lipstick OUTPUT(Brand, Name, Color) VALUES(\"" + Lipstick[0] + "\", \"" + Lipstick[1] + "\", \"" + Lipstick[2] + "\")");

            }
        }

        private static void AddBlush(List<string> Blush)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("INSERT INTO Blush OUTPUT(Brand, Name, Color) VALUES(\"" + Blush[0] + "\", \"" + Blush[1] + "\", \"" + Blush[2] + "\")");

            }
        }

        private static void RemoveMakeup()
        {
            string ShadeName;
            string HighlighterName;
            string BlushName;
            string LipstickName;

            Console.WriteLine("Choose an option");
            Console.WriteLine("1) Remove a Eyeshadow");
            Console.WriteLine("2) Remove a Highlighter");
            Console.WriteLine("3) Remove a Lipstick");
            Console.WriteLine("4) Remove a Blush");
            Console.WriteLine("5) Return to the main menu");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Please enter the ShadeName");
                    ShadeName = Console.ReadLine();

                    RemoveEyeshadow(ShadeName);
                    return;
                case "2":
                    Console.WriteLine("Please enter the Name");
                    HighlighterName = Console.ReadLine();

                    RemoveHighlighter(HighlighterName);
                    return;
                case "3":
                    Console.WriteLine("Please enter the Name");
                    LipstickName = Console.ReadLine();

                    RemoveLipstick(LipstickName);
                    return;
                case "4":
                    Console.WriteLine("Please enter the Name");
                    BlushName = Console.ReadLine();

                    RemoveBlush(BlushName);
                    return;
                case "5":
                    return;
                default:
                    return;
            }
        }

        private static void RemoveEyeshadow(string ShadeName)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("DELETE FROM Eyeshadow OUTPUT WHERE Name = '" + ShadeName + "'");

            }
        }
        private static void RemoveBlush(string BlushName)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("DELETE FROM Blush OUTPUT WHERE Name = '" + BlushName + "'");

            }
        }

        private static void RemoveHighlighter(string HighlighterName)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("DELETE FROM Highlighter OUTPUT WHERE Name = '" + HighlighterName + "'");

            }
        }

        private static void RemoveLipstick(string LipstickName)
        {

            string provider = ConfigurationManager.AppSettings["provider"];

            string connectionString = ConfigurationManager.AppSettings
                ["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(provider);

            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    Console.WriteLine("Connection Error");
                    Console.ReadLine();
                }

                connection.ConnectionString = connectionString;

                connection.Open();

                DbCommand command = factory.CreateCommand();

                if (command == null)
                {
                    Console.WriteLine("Command Error");
                    Console.ReadLine();
                }

                command.Connection = connection;
                command.CommandText = ("DELETE FROM Lipstick OUTPUT WHERE Name = '" + LipstickName + "'");

            }
        }
        private static string BlushSearch(string BlushColor, string OldBlushName)
        { int loops = 0;
            List<string> RandomPick = new List<string>();
            RandomPick = BlushDB(BlushColor);
            if(RandomPick.Count == 0)
            {
                BlushColor = "pink";
                RandomPick = BlushDB(BlushColor);
            }
            while(RandomPick[1] == OldBlushName)
            {
                RandomPick = BlushDB(BlushColor);

                if(loops > 3)
                {
                    BlushColor = "pink";
                    RandomPick = BlushDB(BlushColor);
                }
                if(loops > 6)
                {
                    Console.WriteLine("Could not find a new result");
                }
            }
            Console.WriteLine("Blush Brand: {0} Name: {1} ", RandomPick[0], RandomPick[1]);
            Console.WriteLine();
            return RandomPick[1];
        }
        private static string LipstickSearch(string LipstickColor, string OldLipstickName)
        {
            int loops = 0;
            List<string> RandomPick = new List<string>();
            RandomPick = LipstickDB(LipstickColor);
            if (RandomPick.Count == 0)
            {
                LipstickColor = "pink";
                RandomPick = LipstickDB(LipstickColor);
            }
            while (RandomPick[1] == OldLipstickName)
            {
                RandomPick = LipstickDB(LipstickColor);

                if (loops > 3)
                {
                    LipstickColor = "pink";
                    RandomPick = LipstickDB(LipstickColor);
                }
                if (loops > 6)
                {
                    Console.WriteLine("Could not find a new result");
                }
            }
            Console.WriteLine("Lipstick Brand: {0} Name: {1} ", RandomPick[0], RandomPick[1]);
            Console.WriteLine();
            return RandomPick[1];
        }
        private static string HighlighterSearch(string HighlighterColor, string OldHighlighterName)
        {
            int loops = 0;
            List<string> RandomPick = new List<string>();
            RandomPick = HighlighterDB(HighlighterColor);
            if (RandomPick.Count == 0)
            {
                HighlighterColor = "pink";
                RandomPick = HighlighterDB(HighlighterColor);
            }
            while (RandomPick[1] == OldHighlighterName)
            {
                RandomPick = HighlighterDB(HighlighterColor);

                if (loops > 3)
                {
                    HighlighterColor = "pink";
                    RandomPick = HighlighterDB(HighlighterColor);
                }
                if (loops > 6)
                {
                    Console.WriteLine("Could not find a new result");
                }
            }
            Console.WriteLine("Highlighter Brand: {0} Name: {1} ", RandomPick[0], RandomPick[1]);
            Console.WriteLine();
            return RandomPick[1];
        }

        public static void DBRegister()
        {
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
        }

        static void Main(string[] args)
        {

            DBRegister();
                
            

            Console.WriteLine("Welcome to Pick my look!");
            Console.WriteLine();
            bool menu = true;
            while (menu)
            {
                menu = MainMenu();
            }



        }
    }
}
