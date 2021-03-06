public class PoorMan
{
    int i_want_money;
    int i_have_money = 0;

    public bool Sutisfied
    {
        get
        {
            return i_have_money >= i_want_money;
        }
    }

    public PoorMan(int car_cost)
    {
        i_want_money = car_cost;
    }

    public void AskMoney(){
        System.Console.ForegroundColor = System.ConsoleColor.DarkGray;
        System.Console.Write("Дай денег бедному :");
        var money = int.Parse(System.Console.ReadLine());

        i_have_money += money;

        var save_color = System.Console.ForegroundColor;

        if(i_have_money < i_want_money)
        {
            System.Console.ForegroundColor = System.ConsoleColor.Red;
            System.Console.WriteLine("Еще хочу, не купить мне машину");
            System.Console.WriteLine($"Машина стоит {i_want_money} а у меня всего {i_have_money}");
        }
        else
        {
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("ОООЧЕНЬ БОЛЬШОЕ СПАСИБО !!!");
            System.Console.WriteLine("БЕГУ ЗА ЛАМБОР... ЛАМБОРДЖ.... ТЬФУ ЛАМБОЙ !!!");
        }

        System.Console.ForegroundColor = save_color;
    }
}