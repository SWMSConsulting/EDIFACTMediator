// See https://aka.ms/new-console-template for more information
using EDIFACTMediator;
using indice.Edi;
using Newtonsoft.Json;

Console.WriteLine("Hello, EDI!");

var grammar = EdiGrammar.NewEdiFact();
var ordersd96a = default(OrdersD96A);
using (var stream = new StreamReader(@"E:\EDITEST\A_ELOS_12587-2.edi", System.Text.Encoding.Latin1))
{
    ordersd96a = new EdiSerializer().Deserialize<OrdersD96A>(stream, grammar);
}