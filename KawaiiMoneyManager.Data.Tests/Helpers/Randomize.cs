using System;
using System.Linq;

namespace KawaiiMoneyManager.Data.Tests.Helpers
{
    public static class Randomize
    {
        const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzÄÖÜäöü0123456789+-?!()$%&";
        
        private static Random randomizer = new Random();
        
        public static string String(int length = 20) =>
            new string (Enumerable.Repeat(CHARS, length).Select(s => s[randomizer.Next(s.Length)]).ToArray());
    }
}
