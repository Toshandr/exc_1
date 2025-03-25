namespace exc_1;

class Program
{


    public static bool Checker(string? name, int age){
        bool status = true;
        if(string.IsNullOrWhiteSpace(name) || name == null){
            Console.WriteLine("Вы не ввели имя");
            return !status;
        }
        else if(age < 18){
            Console.WriteLine("Вы ещё малы, гуляйте");
            return !status;
        }
        else if (age > 120){
            Console.WriteLine("Вы слишком стары, уходите");
            return !status;
        }
        return status;
    }

    public static void Request(){
        
    }


    public delegate bool my_delegate(string? Name, int Age);
    public static event my_delegate Notify;


    static void Main(string[] args)
    {
        Console.Clear();
        string PATH = @"C:\Users\MSI ThinGF63\Desktop\exc_1\users";

        if(!File.Exists(PATH)){
            File.Create(PATH);
        }

        string? NAME = "";
        int AGE = 0;

        my_delegate my_delegate_ekz = Checker;
        Notify += Checker;
 

        Console.WriteLine("Здравствуйте!");
        while(true){
            while(true){
                try{
                    Console.Write("Введите ваше имя: ");
                    string? name = Console.ReadLine();
                    NAME = name;
                    Console.Write("Введите ваш возраст: ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    AGE = age;
                }
                catch(Exception ex){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка:{ex.Message}");
                    Console.ResetColor();
                    Console.WriteLine("Введите корректные данные");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                break;
            }
            if (Notify?.Invoke(NAME, AGE) == true){
                using (StreamWriter writer = new StreamWriter(PATH, true))
                {
                    writer.WriteLineAsync($"{NAME} {AGE}");
                }
                Console.WriteLine("Вы в списке");
                Console.WriteLine("Хотите добавить ещё кого то в список? Да/Нет");
                string? ans = Console.ReadLine()?.ToUpper();
                Console.Clear();
                if(ans == "НЕТ"){
                    break;
                }
            }
            else{
                break;
            }

        }
        Console.WriteLine("Завершение программы");
        Console.WriteLine("____________________");
    }
}
