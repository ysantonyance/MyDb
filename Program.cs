using Microsoft.Identity.Client;
using MyDatabase;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter login: ");
        string login = Console.ReadLine();

        Console.WriteLine("Enter password: ");
        string password = Console.ReadLine();

        var context = new MyDb();
        context.Database.EnsureCreated();

        var user = context.Users.FirstOrDefault(u => u.Username == login);

        if (user != null)
        {
            if (user.Password == password)
            {
                Console.WriteLine("Welcome back!");
            }
            else
            {
                Console.WriteLine("Incorrect password!");
            }
        }
        else
        {
            if (password.Length < 6)
            {
                Console.WriteLine("Password needs to include at least 6 symbols");
                return;
            }

            if (!password.Any(char.IsDigit))
            {
                Console.WriteLine("Password needs to include at least 1 digit");
                return;
            }

            context.Users.Add(new User
            {
                Username = login,
                Password = password,
                CreatedAt = DateTime.Now
            });
            context.SaveChanges();
            Console.WriteLine("User is registrated");
        }
    }
}

