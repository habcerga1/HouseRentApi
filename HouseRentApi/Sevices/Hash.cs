using System.Security.Cryptography;
using System.Text;

namespace HouseRentApi.Sevices;

public class Hash
{
    public event AsyncCallback asd;
    public static string sha256(string randomString)
    {
        var crypt = new SHA256Managed();
        string hash = String.Empty;
        byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(randomString));
        foreach (byte theByte in crypto)
        {
            hash += theByte.ToString("x2");
        }
        return hash;
    }
}

class asd
{
    private static object objA;
    private static object objB;

    private static void performTaskA()
    {
        lock (objB)
        {
            Thread.Sleep(1000);
            lock (objA) { }
        }
    }

    private static void PerformTaskB()
    {
        lock (objA)
        {
            lock (objB) { }
        }
    } 
}