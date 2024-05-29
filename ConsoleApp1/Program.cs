using Database.Minden;
using Database.Data;


namespace Database
{
    public class Program
    {
        static void Kiir(IEnumerable<object> szemelyek)
        {
            foreach (var item in szemelyek)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            VContent db = new VContent();

            if (!db.Emberek.Any())
            {
                var sorok = File.ReadAllLines(@"C:\Users\thinkpad\OneDrive\Asztali gép\schoolpaper-master\ConsoleApp1\3.csv").Skip(1);
                foreach (var line in sorok)
                {
                    db.Emberek.Add(new Emberek(line));
                }
                db.SaveChanges();
            }
            Kiir(db.Emberek);
        }
    }
}