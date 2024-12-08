// string içinde r ne işe yara araştır.
//----------------------------------------------
// System.Console.WriteLine("1.İşlem(5 Saniye)");
// for (int i = 1; i <= 5; i++)
// {
//     System.Console.WriteLine($"\r[1.İşlem] Geçen Süre: {i} saniye");
//     Thread.Sleep(1000);
// }
// System.Console.WriteLine("1.İşlem (5 Saniye) Sona erdi\n----------------------------");

// System.Console.WriteLine("2.İşlem (10 Saniye)");
// for (int i = 1; i <= 10; i++)
// {
//     System.Console.WriteLine($"\r [2.İşlem] Geçen Süre: {i} saniye");
//     Thread.Sleep(1000);
// }


//----------------------------------------------


//ASENKRON
string task1Status = "5 Saniyelik işlem bekleniyor...";
string task2Status = "10 Saniyelik işlem bekleniyor...";

object consoleLock = new object();

Thread thread1 = new Thread(() =>
{
    for (int i = 1; i <= 5; i++)
    {
        lock (consoleLock)
        {
            task1Status = $"5 Saniyelik işlem için geçen süre: {i} saniye";
            Console.Clear();
            System.Console.WriteLine($"{task1Status}\n{task2Status}");
        }
        Thread.Sleep(1000);
    }
    lock (consoleLock)
    {
        task1Status = "5 Saniyelik işlem tamamlandı!";
        Console.Clear();
        System.Console.WriteLine($"{task1Status}\n{task2Status}");
        
    }
});
//------------------------------------------------------------

Thread thread2 = new Thread(() =>
{
    for (int i = 1; i <= 10; i++)
    {
        lock (consoleLock)
        {
            task2Status = $"10 Saniyelik işlem için geçen süre: {i} saniye";
            Console.Clear();
            System.Console.WriteLine($"{task1Status}\n{task2Status}");
        }
        Thread.Sleep(1000);
    }
    lock (consoleLock)
    {
        task2Status = "10 Saniyelik işlem tamamlandı!";
        Console.Clear();
        System.Console.WriteLine($"{task1Status}\n{task2Status}");
    }
});
thread1.Start();
thread2.Start();