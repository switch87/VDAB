using System;
namespace CSharpPFCursus
{
public enum Seizoen
{
Lente, Zomer, Herfst, Winter
} 
class Program
{
static void Main(string[] args)
{
Seizoen plukseizoen = Seizoen.Herfst; 
Console.WriteLine((int)plukseizoen); 
}
}
}
