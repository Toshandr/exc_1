namespace exc_1;

class Program
{


    public static bool Checker(string? name, int age){
        bool status = true;
        if(name == null){
            Console.WriteLine("Вы не ввели имя");
            return !status;
        }
        if(age < 18){
            Console.WriteLine("Вы ещё малы, гуляйте");
            return !status;
        }
        return status;
    }


    public delegate bool my_delegate(string? Name, int Age);
    public static event my_delegate Notify;


    /*  1. Сделать файл txt и туда добавлять пользователей
        2. Проверка на сущестование файла, если не то создать */
    static void Main(string[] args)
    {
        Console.Clear();

        string? NAME = "";
        int AGE = 0;

        my_delegate my_delegate_ekz = Checker;
        Notify += Checker;

        bool cycle = true;

        Console.WriteLine("Здравствуйте!");
        while(cycle){
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
            Console.WriteLine("Вы в списке");
        }
        else{
            Console.WriteLine("Возвращайтесь, когда придумаете верные данные");
        }
    }
}
