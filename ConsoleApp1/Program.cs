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
            Console.WriteLine("Take full advantage of C# 8 with ReSharper’s enhanced support");

        private static T Lol<T>(Func<T> d)
            where T : new()
        {
            // invalid R# error: "Left operand of the '??' operator should be of reference or nullable type"
            return d() ?? new T();
        }

        internal class Container<T>
            // invalid R# error and invalid refactoring: "The class type constraint 'Item' must come before any other constraints"
            where T : notnull, Item
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

        // no refactoring suggested, as it was with Item class
        internal class MyClass2
        {
        }
    }


}
