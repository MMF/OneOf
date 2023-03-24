using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OneOf.Models;

public class GenericResponse
{
    public GenericResponse(object obj, bool status)
    {
        var statusMsg = status ? "Success" : "Failure";
        Console.WriteLine($"{statusMsg}: {obj}");
    }
}
