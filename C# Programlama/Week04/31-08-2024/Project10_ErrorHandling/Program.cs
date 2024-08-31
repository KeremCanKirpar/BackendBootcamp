namespace Project10_ErrorHandling;

class Program
{
    static void Main(string[] args)
    {
        #region Try Catch Syntax
        try
        {

        }
        catch
        {

        }

        #endregion

        #region Try Catch

        int number = default;
        int number2 = default;
        string result = "default";
        try
        {

            Console.Write("1.Sayıyı Giriniz: ");
            number = Convert.ToInt32(Console.ReadLine());
            Console.Write("2.Sayıyı Giriniz: ");
            number2 = Convert.ToInt32(Console.ReadLine());
            result = (number / number2).ToString();



        }
        catch (FormatException)
        {
            Console.WriteLine("Lütfen Geçerli Bir Değer giriniz! ");

        }
        catch (OverflowException)
        {
            result = $"Lütfen {int.MinValue} -- {int.MaxValue} Arasında Bir Değer Giriniz";


        }
        catch (DivideByZeroException)
        {
            result = $"0 girdiğiniz için default olarak 1'e bölme işlemi yapıldı.\n{number.ToString()}";

        }
        catch (Exception ex)
        {
            result = ex.Message;
        }
        finally
        {
            Console.WriteLine(result);
        }

        #endregion


    }
}
