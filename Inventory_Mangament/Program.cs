using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Inventory_Mangament
{
    // Defining the class Shirts.
    [Serializable]
    public class Shirt
    {
       public string shirtColor;
       public string shirtSize;
       public string sleeveType;
       public double colthLengthUnitMeters;
       public double buttonRequired; 
       public int shirtUnderproductionCount;
       public int finishedShirtCount;
       public int damagedShirtCount;
        public Shirt(string _shirtColor,string _shirtSize,string _sleeveType,double _clothLenghth,double _buttonRequired)
        {
            shirtColor = _shirtColor;
            shirtSize  = _shirtSize;
            sleeveType  = _sleeveType;
            colthLengthUnitMeters = _clothLenghth;
            buttonRequired = _buttonRequired;
        }
    }
    // Defining the class Fabric.
    [Serializable]
    class Fabric
    {
       public string fabricColor;
       public double quantityInMeters;
       public Fabric(string _fabricColor)
        {
            fabricColor = _fabricColor;
        }

    }
    // Defining the class ThreadRoll.
    [Serializable]
    class ThreadRoll
    {
       public string threadColor;
       public double threadRollCount;
       public ThreadRoll(string _threadColor)
        {
            threadColor = _threadColor;
        }
    }
    // Defining the class Buttons.
    [Serializable]
    class Buttons
    {
       // Assuming a pack of button have 200 buttons.
        public string buttonColor;
        public double buttonPackCount;                                                        
        public Buttons(string _buttonColor)
        {
            buttonColor = _buttonColor;
        }
    }
    class Program
    {
       // Fullsleve Shirt needs 12 button, halfsleve shirt need 8 button.

        static double buttonCountF = 0.06;
        static double buttonCountH = 0.04;

       // Assuming 10 shirts can be stiched with 1 threadroll.

        static double threadPerShirt = 0.1;

       // Lists for data handeling.

        static List<Shirt> shirts = new List<Shirt>();
        static List<Fabric> fabrics = new List<Fabric>();
        static List<ThreadRoll> threadrolls = new List<ThreadRoll>();
        static List<Buttons> buttons = new List<Buttons>();
     
       //creating a formater object.

        static BinaryFormatter bf = new BinaryFormatter();

        static string choice;
        static void Main(string[] args)
        {
            try
            {
                Deserialiser();
            }
            catch
            {
                Console.WriteLine("NOTE:Unable to load the stored data .Please contact the software developer!");
            }

            // Cloth required for each type of shirt.

            List<double> Clothlength = new List<double>();

            Clothlength.Add(1.4);                               // Small, Half sleeve
            Clothlength.Add(1.6);                               // Small, Full sleeve
            Clothlength.Add(1.42);                              // Medium, Half sleeve
            Clothlength.Add(1.62);                              // Medium, Full sleeve
            Clothlength.Add(1.44);                              // Large, Half sleeve
            Clothlength.Add(1.64);                              // Large, Full sleeve
            Clothlength.Add(1.46);                              // Extra large, Half sleeve
            Clothlength.Add(1.66);                              // Extra large, Full sleeve
            Clothlength.Add(1.48);                              // Extra Extra Large, Half sleeve
            Clothlength.Add(1.680);                             // Extra Extra Large, Full sleev

            // List of  finished products.

            shirts.Add(new Shirt("RED", "S", "H",Clothlength[0], buttonCountH));
            shirts.Add(new Shirt("RED", "S", "F",Clothlength[1],buttonCountF));
            shirts.Add(new Shirt("RED", "M", "H",Clothlength[2],buttonCountH));
            shirts.Add(new Shirt("RED", "M", "F",Clothlength[3],buttonCountF));
            shirts.Add(new Shirt("RED", "L", "H",Clothlength[4],buttonCountH));
            shirts.Add(new Shirt("RED", "L", "F",Clothlength[5],buttonCountF));
            shirts.Add(new Shirt("RED", "XL", "H",Clothlength[6],buttonCountH));
            shirts.Add(new Shirt("RED", "XL", "F",Clothlength[7],buttonCountF));
            shirts.Add(new Shirt("RED", "XXL", "H",Clothlength[8],buttonCountH));
            shirts.Add(new Shirt("RED", "XXL", "F",Clothlength[9],buttonCountF));
            shirts.Add(new Shirt("BLUE", "S", "H", Clothlength[0], buttonCountH));
            shirts.Add(new Shirt("BLUE", "S", "F", Clothlength[1], buttonCountF));
            shirts.Add(new Shirt("BLUE", "M", "H", Clothlength[2], buttonCountH));
            shirts.Add(new Shirt("BLUE", "M", "F", Clothlength[3], buttonCountF));
            shirts.Add(new Shirt("BLUE", "L", "H", Clothlength[4], buttonCountH));
            shirts.Add(new Shirt("BLUE", "L", "F", Clothlength[5], buttonCountF));
            shirts.Add(new Shirt("BLUE", "XL", "H", Clothlength[6], buttonCountH));
            shirts.Add(new Shirt("BLUE", "XL", "F", Clothlength[7], buttonCountF));
            shirts.Add(new Shirt("BLUE", "XXL", "H", Clothlength[8], buttonCountH));
            shirts.Add(new Shirt("BLUE", "XXL", "F", Clothlength[9], buttonCountF));
            shirts.Add(new Shirt("WHITE", "S", "H", Clothlength[0], buttonCountH));
            shirts.Add(new Shirt("WHITE", "S", "F", Clothlength[1], buttonCountF));
            shirts.Add(new Shirt("WHITE", "M", "H", Clothlength[2], buttonCountH));
            shirts.Add(new Shirt("WHITE", "M", "F", Clothlength[3], buttonCountF));
            shirts.Add(new Shirt("WHITE", "L", "H", Clothlength[4], buttonCountH));
            shirts.Add(new Shirt("WHITE", "L", "F", Clothlength[5], buttonCountF));
            shirts.Add(new Shirt("WHITE", "XL", "H", Clothlength[6], buttonCountH));
            shirts.Add(new Shirt("WHITE", "XL", "F", Clothlength[7], buttonCountF));
            shirts.Add(new Shirt("WHITE", "XXL", "H", Clothlength[8], buttonCountH));
            shirts.Add(new Shirt("WHITE", "XXL", "F", Clothlength[9], buttonCountF));
            shirts.Add(new Shirt("BLACK", "S", "H", Clothlength[0], buttonCountH));
            shirts.Add(new Shirt("BLACK", "S", "F", Clothlength[1], buttonCountF));
            shirts.Add(new Shirt("BLACK", "M", "H", Clothlength[2], buttonCountH));
            shirts.Add(new Shirt("BLACK", "M", "F", Clothlength[3], buttonCountF));
            shirts.Add(new Shirt("BLACK", "L", "H", Clothlength[4], buttonCountH));
            shirts.Add(new Shirt("BLACK", "L", "F", Clothlength[5], buttonCountF));
            shirts.Add(new Shirt("BLACK", "XL", "H", Clothlength[6], buttonCountH));
            shirts.Add(new Shirt("BLACK", "XL", "F", Clothlength[7], buttonCountF));
            shirts.Add(new Shirt("BLACK", "XXL", "H", Clothlength[8], buttonCountH));
            shirts.Add(new Shirt("BLACK", "XXL", "F", Clothlength[9], buttonCountF));

            // List of fabrics (Raw material).

            fabrics.Add(new Fabric("RED"));
            fabrics.Add(new Fabric("BLUE"));
            fabrics.Add(new Fabric("WHITE"));
            fabrics.Add(new Fabric("BLACK"));

           // List of threadrolls (Raw material).

            threadrolls.Add(new ThreadRoll("RED"));
            threadrolls.Add(new ThreadRoll("BLUE"));
            threadrolls.Add(new ThreadRoll("WHITE"));
            threadrolls.Add(new ThreadRoll("BLACK"));                                  

          // List of buttons (Raw Material).

            buttons.Add(new Buttons("RED"));
            buttons.Add(new Buttons("BLUE"));
            buttons.Add(new Buttons("WHITE"));
            buttons.Add(new Buttons("BLACK"));

            
            do
            {
                int option = displayMainMenu();
                if (option == 1)
                {
                    InputStock();
                }
                else if (option == 2)
                {
                    IsssueStockForProduction();
                }
                else if (option == 3)
                {
                    UpdateFinishedProducts();
                }
                else if (option == 4)
                {
                    UpdateDamagedProducts();
                }
                else if (option == 5)
                {
                    UpdateSoldProduct();
                }
                else if (option == 6)
                {
                    ViewStock();
                }
                else
                {
                    ViewProduct();
                }
                choice = InputterChar("Do you wish go back to main menu ? Enter Y or N", "Y", "N");
            }
            while (choice == "Y");
        
            Serialiser();

            Console.WriteLine("Press any key to terminate the program.");
            Console.ReadKey();

        }
        // Function for selecting options without error.
        static int InputterSerialNo(int a, int b)                                   
        {
            bool check;
            int Input = 0;
            do
            {
                Console.WriteLine("Please enter the serial number to select the option.");
                try
                {
                    Input = int.Parse(Console.ReadLine());
                    check = true;
                    if (Input > a || Input < b)
                    {
                        check = false;
                    }
                }
                catch
                {
                    check = false;
                }

            }
            while (!check);
            return Input;
        }
        //Function for taking in double values only , without error
        static double Inputterdouble(string text)                                                    
        {
            bool check;
            double Input=0 ;
            do
            {
                Console.WriteLine(text);
                try
                {
                    Input = double.Parse(Console.ReadLine());
                    check = true;
                    if (Input<0 )
                    {
                        check = false;
                    }
                }
                catch
                {
                    check = false;
                }
            }
            while (!check);
            return Input;
        }
        //Function for taking in integer values only, without error.
        static int InputterInteger(string text)                                                              
        {
            bool check;
            int Input = 0;
            do
            {
                Console.WriteLine(text);
                try
                {
                    Input = int.Parse(Console.ReadLine());
                    check = true;
                    if (Input < 0)
                    {
                        check = false;
                    }
                }
                catch
                {
                    check = false;
                }
            }
            while (!check);
            return Input;
        }
        // Function for prompting a question and taking in value without error.
        static string InputterChar(string text,string a ,string b)
        {
            string answer = "";
            bool check=false;
            do
            {
                Console.WriteLine(text);
                answer = Console.ReadLine().ToUpper();
                if (answer == a || answer == b)
                {
                    check = true;
                }
            }
            while (!check);
            return answer;
        }
        // Finction for inputting shirt size in a given format without error
        static string InputterShirtSize()
        {
            string answer = "";
            bool check = false;
            do
            {
                Console.WriteLine("Please enter the shirt size in the given format\n S - Small\n M - Medium\n L - Large\n XL - Extra large\n XXL - Extra extra large\n");
                answer = Console.ReadLine().ToUpper();
                if (answer == "S" || answer == "M"||answer=="L"||answer=="XL"||answer=="XXL")
                {
                    check = true;
                }
            }
            while (!check);

            return answer;
        }
        // Function for finding a particular shirt from the list of shirts.
        static Shirt ShirtFinder(string shirtColor,string sleeveType ,string shirtSize)
        {
            int i;
            Shirt shirt = new Shirt("", "", "",0,0);

            for (i = 0; i < shirts.Count; i++)
            {
                if (shirts[i].shirtColor == shirtColor && shirts[i].sleeveType ==sleeveType && shirts[i].shirtSize == shirtSize)
                {
                     shirt = shirts[i];
                }
            }
            return shirt;
        }
        // Procedure for helping in issuing stock for a particular type of shirt.
        static void stockIssuer(string color,int option)
        {
            string Sleevetype;
            string ShirtSize;
            Shirt SelctedShirt;
            int shirtCount;
            Sleevetype = InputterChar("Please mention the sleeve type in the mentioned format.'H' for halfsleeve ,'F' for fullsleeve.", "H", "F");
            ShirtSize = InputterShirtSize();
            SelctedShirt = ShirtFinder(color, Sleevetype, ShirtSize);
            shirtCount = InputterInteger("Please enter the number of shirt(s) to be stiched.");
            if (SelctedShirt.colthLengthUnitMeters * shirtCount <= fabrics[option-1].quantityInMeters && SelctedShirt.buttonRequired * shirtCount <= buttons[option-1].buttonPackCount && threadrolls[option - 1].threadRollCount >= threadPerShirt * shirtCount)
            {
                SelctedShirt.shirtUnderproductionCount = SelctedShirt.shirtUnderproductionCount + shirtCount;
                fabrics[option-1].quantityInMeters = fabrics[option - 1].quantityInMeters - (SelctedShirt.colthLengthUnitMeters * shirtCount);
                buttons[option-1].buttonPackCount = buttons[option-1].buttonPackCount - (SelctedShirt.buttonRequired * shirtCount);
                threadrolls[option-1].threadRollCount = threadrolls[option-1].threadRollCount - (threadPerShirt * shirtCount);
                Console.WriteLine(shirtCount + color.ToLower()+ "shirt issued for production. ");
            }
            else
            {
                Console.WriteLine("Insufficient stock(raw material) for stiching " + shirtCount +" "+ color.ToLower()+" shirt(s) kindly check the status of inventy and comeback.");
            }

        }
        // Procedure for helping in updating finshed product count.
        static void FinishedProductUpdater(string color)
        {
            string Sleevetype;
            string ShirtSize;
            Shirt SelctedShirt;
            Sleevetype = InputterChar("Please mention the sleeve type in the mentioned format.'H' for halfsleeve ,'F' for fullsleeve", "H", "F");
            ShirtSize = InputterShirtSize();
            int number = InputterInteger("Please enter the number of shirt to be updated.");
            SelctedShirt = ShirtFinder(color, Sleevetype, ShirtSize);
            SelctedShirt.finishedShirtCount = SelctedShirt.finishedShirtCount + number;
        }
        // Procedure for helping in updating damaged product count.
        static void DamagedProductUpdater(string color)
        {
            string Sleevetype;
            string ShirtSize;
            Shirt SelctedShirt;
            bool check;
            Sleevetype = InputterChar("Please mention the sleeve type in the mentioned format.'H' for halfsleeve ,'F' for fullsleeve", "H", "F");
            ShirtSize = InputterShirtSize();
            SelctedShirt = ShirtFinder(color, Sleevetype, ShirtSize);
            do
            {
                int number = InputterInteger("Please enter the number of shirt to be updated.");
                if (SelctedShirt.shirtUnderproductionCount >= number)
                {
                    SelctedShirt.damagedShirtCount = SelctedShirt.damagedShirtCount + number;
                    check = true;
                }
                else
                {
                    Console.WriteLine("Invalid request : Number of shirt damaged is less the number of shirt under production . Please check and enter again.");
                    check = false;
                }
            }
            while (!check);
            
           
        }
        // Procedure for helping in updating finshed product count.
        static void ReduceSoldProduct(string color)
        {
            string Slevetype;
            string ShirtSize;
            Shirt SelctedShirt;
            Slevetype = InputterChar("Please mention the sleeve type in the mentioned format.'H' for halfsleeve ,'F' for fullsleeve.", "H", "F");
            ShirtSize = InputterShirtSize();
            int number = InputterInteger("Please enter the number of shirt to be updated.");
            SelctedShirt = ShirtFinder(color, Slevetype, ShirtSize);
            SelctedShirt.finishedShirtCount = SelctedShirt.finishedShirtCount - number;
        }
        // Prodcedure for serialisation
        static void Serialiser()
        {
            FileStream shirtsData = File.Create("Shirts.bin");
            FileStream fabricData = File.Create("Cloth.bin");
            FileStream buttonData = File.Create("Buttons.bin");
            FileStream threadData = File.Create("Thread.bin");
            bf.Serialize(shirtsData, shirts);
            bf.Serialize(fabricData, fabrics);
            bf.Serialize(buttonData, buttons);
            bf.Serialize(threadData, threadrolls);
            shirtsData.Close();
            fabricData.Close();
            buttonData.Close();
            threadData.Close();
        }
        // Prodcedure for deserialisation
        static void Deserialiser()
        {
            FileStream shirtsData = File.OpenRead("Shirts.bin");
            FileStream fabricData = File.OpenRead("Cloth.bin");
            FileStream buttonData = File.OpenRead("Buttons.bin");
            FileStream threadData = File.OpenRead("Thread.bin");
            List<Shirt> shirts = (List<Shirt>)bf.Deserialize(shirtsData);
            List<Fabric> fabrics = (List<Fabric>)bf.Deserialize(fabricData);
            List<Buttons> buttons = (List<Buttons>)bf.Deserialize(buttonData);
            List<ThreadRoll> threadRolls = (List<ThreadRoll>)bf.Deserialize(threadData);
            shirtsData.Close();
            fabricData.Close();
            buttonData.Close();
            threadData.Close();
        }
        // Function for displaying main menu and returing a selcted option from the menu.
        static int displayMainMenu()                                                                
        {
            
            Console.WriteLine("\t Textile Inventory Managment\n");
            Console.WriteLine("Please select an option from the below .\n");
            Console.WriteLine("1. Input Stock(Raw Material) \n2. Issue stock for stitching \n3. Update finished products \n4. Update damaged products \n5. Update sale of a product \n6. View Stock(Raw material) Status \n7. View product status\n ");

            return InputterSerialNo(7, 1);
            
        }
        //Procedure for taking in stock (Raw Material).
        static void InputStock()                                                                    
        {
            do
            {
                Console.WriteLine("Please select the stock to make an entry. \n\t1.Cloth\n\t2.Buttons\n\t3.Thread\n");
                int option = InputterSerialNo(3, 1);
                if (option == 1)
                {
                   
                    do
                    {
                        double ClothLength_Input;
                        Console.WriteLine("Please select the type of cloth.\n\t1.Red\n\t2.Blue\n\t3.White\n\t4.Black");
                        int clothType = InputterSerialNo(4, 1);
                        if (clothType == 1)
                        {
                            Console.WriteLine("You have selected 'RED' cloth. ");
                            ClothLength_Input = Inputterdouble("Please enter the quantity in meters.");
                            fabrics[0].quantityInMeters = fabrics[0].quantityInMeters + ClothLength_Input;
                        }
                        else if (clothType == 2)
                        {
                            Console.WriteLine("You have selected 'BLUE' cloth. ");
                            ClothLength_Input = Inputterdouble("Please enter the quantity in meters.");
                            fabrics[1].quantityInMeters = fabrics[1].quantityInMeters + ClothLength_Input;
                        }
                        else if (clothType == 3)
                        {
                            Console.WriteLine("You have selected 'WHITE' cloth. ");
                            ClothLength_Input = Inputterdouble("Please enter the quantity in meters.");
                            fabrics[2].quantityInMeters = fabrics[2].quantityInMeters + ClothLength_Input;
                        }
                        else
                        {
                            Console.WriteLine("You have selected 'BLACK' cloth. ");
                            ClothLength_Input = Inputterdouble("Please enter the quantity in meters.");
                            fabrics[3].quantityInMeters = fabrics[3].quantityInMeters + ClothLength_Input;
                        }
                        choice = InputterChar("Do you wish to update stock for a different type of cloth ? Enter Y or N" ,"Y","N");
                    }
                    while (choice == "Y");
                }
                else if (option == 2)
                {
                    do
                    {
                        double buttonPackcount_Input;
                        Console.WriteLine("Please select the color of button.\n\t1.Red\n\t2.Blue\n\t3.White\n\t4.Black");
                        int buttonColor = InputterSerialNo(4, 1);
                        if (buttonColor == 1)
                        {
                            Console.WriteLine("You have selected 'RED' button. ");
                            buttonPackcount_Input = InputterInteger("Please enter no of packet(s).");
                            buttons[0].buttonPackCount = buttons[0].buttonPackCount + buttonPackcount_Input;
                        }
                        else if (buttonColor == 2)
                        {
                            Console.WriteLine("You have selected 'BLUE' button. ");
                            buttonPackcount_Input = InputterInteger("Please enter no of packet(s).");
                            buttons[1].buttonPackCount = buttons[1].buttonPackCount + buttonPackcount_Input;
                        }
                        else if (buttonColor == 3)
                        {
                            Console.WriteLine("You have selected 'WHITE' button. ");
                            buttonPackcount_Input = InputterInteger("Please enter no of packet(s).");
                            buttons[2].buttonPackCount = buttons[3].buttonPackCount + buttonPackcount_Input;
                        }
                        else
                        {
                            Console.WriteLine("You have selected 'BLACK' button. ");
                            buttonPackcount_Input = InputterInteger("Please enter no of packet(s).");
                            buttons[3].buttonPackCount = buttons[3].buttonPackCount + buttonPackcount_Input;
                        }
                        choice = InputterChar("Do you wish to update stock for a different type of button ? Enter Y or N","Y","N");
                    }
                    while (choice == "Y");
                }
                else
                {
                    do
                    {
                        double threadrollcount_Input;
                        Console.WriteLine("Please the select color of thread.\n\t1.Red\n\t2.Blue\n\t3.White\n\t4.Black");
                        int threadColor = InputterSerialNo(4, 1);
                        if (threadColor == 1)
                        {
                            Console.WriteLine("You have selected 'RED' thread. ");
                            threadrollcount_Input = InputterInteger("Please enter no of roll(s).");
                            threadrolls[0].threadRollCount = threadrolls[0].threadRollCount + threadrollcount_Input;
                        }
                        else if (threadColor == 2)
                        {
                            Console.WriteLine("You have selected 'BLUE' thread. ");
                            threadrollcount_Input = InputterInteger("Please enter no of roll(s).");
                            threadrolls[1].threadRollCount = threadrolls[1].threadRollCount + threadrollcount_Input;
                        }
                        else if (threadColor == 3)
                        {
                            Console.WriteLine("You have selected 'WHITE' thread. ");
                            threadrollcount_Input = InputterInteger("Please enter no of roll(s).");
                            threadrolls[2].threadRollCount = threadrolls[2].threadRollCount + threadrollcount_Input;
                        }
                        else
                        {
                            Console.WriteLine("You have selected 'WHITE' thread. ");
                            threadrollcount_Input = InputterInteger("Please enter no of roll(s).");
                            threadrolls[3].threadRollCount = threadrolls[3].threadRollCount + threadrollcount_Input;
                        }
                        choice = InputterChar("Do you wish to update stock for a different type of thread ? Enter Y or N","Y","N");
                    }
                    while (choice == "Y");
                }
                Program.choice = InputterChar("Do you wish to update another type of stock ? Enter Y or N","Y","N");

            } while (choice=="Y");
        }
        //Procedure for issuing stock for production.
        static void IsssueStockForProduction()
        {
            string choice;
            do
            {
                Console.WriteLine("Please select the color of shirt to be stiched .\n\t1.Red\n\t2.Blue\n\t3.White\n\t4.Black");
                int option = InputterSerialNo(4, 1);
                if (option ==1)
                {
                    stockIssuer("RED", option);
                }
                else if (option==2)
                {
                    stockIssuer("BLUE", option);
                }
                else if (option==3)
                {
                    stockIssuer("WHITE", option);
                }
                else
                {
                    stockIssuer("BLACK", option);
                }
                choice = InputterChar("Do you wish to update another type of shirt ? Enter Y or N", "Y", "N");
            }
            while (choice == "Y");
            
        }
        // Prodcedure for updating finsihed products.
        static void UpdateFinishedProducts()
        {
            string choice;
            do
            {
                Console.WriteLine("Please the select finished product to update.\n\t1.Red Shirt\n\t2.Blue Shirt\n\t3.White Shirt\n\t4.Black Shirt");
                int option = InputterSerialNo(4, 1);
                if(option==1)
                {
                    FinishedProductUpdater("RED");
                }
                else if(option==2)
                {
                    FinishedProductUpdater("BLUE");
                }
                else if(option==3)
                {
                    FinishedProductUpdater("WHITE");
                }
                else
                {
                    FinishedProductUpdater("BLACK");
                }
                choice = InputterChar("Do you wish to update another type of shirt ? Enter Y or N", "Y", "N");
            }
            while (choice == "Y");
        }
        // Prodcedure for updating damaged products.
        static void UpdateDamagedProducts()
        {
            string choice;
            do
            {
                Console.WriteLine("Please the select damaged product to update.\n\t1.Red Shirt\n\t2.Blue Shirt\n\t3.White Shirt\n\t4.Black Shirt");
                int option = InputterSerialNo(4, 1);
                if (option == 1)
                {
                    DamagedProductUpdater("RED");
                }
                else if (option == 2)
                {
                    DamagedProductUpdater("BLUE");
                }
                else if (option == 3)
                {
                    DamagedProductUpdater("WHITE");
                }
                else
                {
                    DamagedProductUpdater("BLACK");
                }
                choice = InputterChar("Do you wish to update another type of shirt ? Enter Y or N", "Y", "N");
            }
            while (choice == "Y");
        }
        // Prodcedure for updating finsihed products i.e reducing sold item from the inventory count.
        static void UpdateSoldProduct()
        {
            string choice;
            do
            {
                Console.WriteLine("Please select the sold product to update.\n\t1.Red Shirt\n\t2.Blue Shirt\n\t3.White Shirt\n\t4.Black Shirt");
                int option = InputterSerialNo(4, 1);
                if (option == 1)
                {
                    ReduceSoldProduct("RED");
                }
                else if (option == 2)
                {
                    ReduceSoldProduct("BLUE");
                }
                else if (option == 3)
                {
                    ReduceSoldProduct("WHITE");
                }
                else
                {
                    ReduceSoldProduct("BLACK");
                }
                choice = InputterChar("Do you wish to update another type of shirt ? Enter Y or N", "Y", "N");
            }
            while (choice == "Y");
        }
        // Procedure for viewing stock count.
        static void ViewStock()
        {
            string choice;
            int i;
            do
            {
                Console.WriteLine("Please select the stock to View. \n\t1.Cloth\n\t2.Buttons\n\t3.Thread\n");
                int option = InputterSerialNo(3, 1);
                if(option==1)
                {
                    for(i=0;i<fabrics.Count;i++)
                    {
                        Console.WriteLine(fabrics[i].quantityInMeters+"meters of "+"'"+(fabrics[i].fabricColor)+"'"+" cloth available for production. ");
                    }
                }
                else if(option==2)
                {
                    for(i=0;i<buttons.Count;i++)
                    {
                        int temp = Convert.ToInt32(buttons[i].buttonPackCount);
                        double remaining = (buttons[i].buttonPackCount - temp) * 100;
                        Console.WriteLine(temp + " number of "+"'"+buttons[i].buttonColor+"'"+" unissued packs are available," + remaining + "% of a packet is in the production line.");
                    }
                }
                else
                {
                    for(i=0;i<threadrolls.Count;i++)
                    {
                        int temp = Convert.ToInt32(threadrolls[i].threadRollCount);
                        double remaining = (threadrolls[i].threadRollCount - temp) * 100;
                        Console.WriteLine(temp + " number of " + "'" + threadrolls[i].threadColor + "'" + "unissued rolls are available," + remaining + "% of a thread roll is in the production line.");
                    }
                }
                choice = InputterChar("Do you wish view another stock ? Enter Y or N", "Y", "N");
            } 
            while (choice == "Y");
        }
        // Procedure for viewing product count.
        static void ViewProduct()
        {
            string choice;
            int i;
            do
            {
                Console.WriteLine("Please select the product to view .\n\t1.Red Shirt\n\t2.Blue Shirt\n\t3.White Shirt\n\t4.Black Shirt");
                int option = InputterSerialNo(4, 1);
                Console.WriteLine("Please note the following abbrivations\n\tSize\n1. S - Small\n2. M - Medium\n3. L - Large\n4. XL - Extra large\n5. XXL - Extra extra large\n\tSleeve type Type\n1. H - Half sleeve\n2. F - Full sleeve");
                if (option == 1)
                {
                    for (i = 0; i < 10; i++)
                    {
                        Console.WriteLine(shirts[i].shirtColor + " SHIRT," + "Size-" + shirts[i].shirtSize + ",Sleve type-" + shirts[i].sleeveType );
                        Console.WriteLine( "Finished products : "+shirts[i].finishedShirtCount+"\nShirt under production : "+shirts[i].shirtUnderproductionCount+"\nDamaged products : "+shirts[i].damagedShirtCount);
                    }
                }
                else if (option == 2)
                {
                    for (i = 10; i < 20; i++)
                    {
                        Console.WriteLine(shirts[i].shirtColor + " SHIRT," + "Size-" + shirts[i].shirtSize + ",Sleve type-" + shirts[i].sleeveType);
                        Console.WriteLine("Finished products : " + shirts[i].finishedShirtCount + "\nShirt under production : " + shirts[i].shirtUnderproductionCount + "\nDamaged products : " + shirts[i].damagedShirtCount);
                    }
                }
                else if (option == 3)
                {
                    for (i = 20; i < 30; i++)
                    {
                        Console.WriteLine(shirts[i].shirtColor + " SHIRT," + "Size-" + shirts[i].shirtSize + ",Sleve type-" + shirts[i].sleeveType);
                        Console.WriteLine("Finished products : " + shirts[i].finishedShirtCount + "\nShirt under production : " + shirts[i].shirtUnderproductionCount + "\nDamaged products : " + shirts[i].damagedShirtCount);
                    }
                }
                else 
                {
                    for (i = 30; i <40; i++)
                    {
                        Console.WriteLine(shirts[i].shirtColor + " SHIRT," + "Size-" + shirts[i].shirtSize + ",Sleve type-" + shirts[i].sleeveType);
                        Console.WriteLine("Finished products : " + shirts[i].finishedShirtCount + "\nShirt under production : " + shirts[i].shirtUnderproductionCount + "\n Damaged products : " + shirts[i].damagedShirtCount);
                    }
                }
                choice = InputterChar("Do you wish view another product ? Enter Y or N", "Y", "N");
            } 
            while (choice == "Y");
        }

    }

}
