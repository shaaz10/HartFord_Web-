using EventsAndDelegateDemo;

class Program
{
    static void Main(string[] args)
    {
        ConsumeMango Slice = new ConsumeMango(); ProduceMango SalemFarms =
        new ProduceMango("Alphanso");
        // Slice registers event with SalemFarms SalemFarms.MangoInfo += Slice.SqueeezeMango; SalemFarms.FreshLot();
    }
}