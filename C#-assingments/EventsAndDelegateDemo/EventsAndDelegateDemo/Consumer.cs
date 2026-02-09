using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsAndDelegateDemo
{
   class MangoEventArgs : EventArgs {
public MangoEventArgs(string type, int number) {
MangoInfo = type;
Number = number; }
public string MangoInfo { get; private set; }
public int Number { get; private set; } }
class ConsumeMango {
public void SqueeezeMango(object sender, MangoEventArgs e) {
Console.WriteLine("Squeezing " + e.Number
+ " of " + e.MangoInfo + " mangoes");
} }
}