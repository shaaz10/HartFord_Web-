Console.WriteLine("John's Weight Classification\n");
            Console.Write("Enter John's Weight: ");
            string s=Console.ReadLine();
            int.TryParse(s, out int weight);

            if (weight < 0 || weight > 120)
            {
                Console.WriteLine("Invalid Input");
            }
            else if (weight <= 48)
            {
                Console.WriteLine("Light Fly");
            }
            else if (weight <= 51)
            {
                Console.WriteLine("Fly");
            }
            else if (weight <= 54)
            {
                Console.WriteLine("Bantam");
            }
            else if (weight <= 57)
            {
                Console.WriteLine("Feather");
            }
            else if (weight <= 60)
            {
                Console.WriteLine("Light");
            }
            else if (weight <= 64)
            {
                Console.WriteLine("Light Welter");
            }
            else if (weight <= 69)
            {
                Console.WriteLine("Welter");
            }
            else if (weight <= 75)
            {
                Console.WriteLine("Light Middle");
            }
            else if (weight <= 81)
            {
                Console.WriteLine("Middle");
            }
            else if (weight <= 91)
            {
                Console.WriteLine("Light Heavy");
            }
            else
            {
                Console.WriteLine("Heavy");
            }