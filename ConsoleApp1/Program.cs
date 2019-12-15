using System;
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedTypeParameter
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable UnusedVariable

namespace ConsoleApp1
{
    internal static class Program
    {
        private static void Main() =>
            Console.WriteLine("ReSharper");

        internal class Container<T>
            // this line is needed to reproduce the following issue
            where T : Item
        {
        }

        // invalid refactoring: "Make class 'Item' abstract" (also makes Program abstract)
        internal class Item
        {
        }

        // CS8602: not supported by R#
        private static void Foo(string? s)
        {
            Console.WriteLine(s.Length);
        }

        // CS8603: not supported by R#
        private static string Bar(DateTime? d)
        {
            return d?.ToString();
        }

        // CS8600: not supported by R#
        private static void Baz()
        {
            static string? F() => null;
            string f = F();
        }
    }
}
