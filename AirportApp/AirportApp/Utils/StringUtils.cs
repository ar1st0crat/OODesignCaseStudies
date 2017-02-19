using System;

namespace AirportApp.Utils
{
    static class StringUtils
    {
        // Пример extension-метода

        public static string Cleanse(this string s)     //    ->  можно вызвать на любой строке:  "abc".Cleanse()
        {
            if (s == "")
                throw new ArgumentException("Wow!!");

            return s.Replace("-", "");
        }

        // Extension-методы можно считать (для уже готовых типов) средством .NET реализации принципа
        //                          OCP (Open/Close Principle)
        // === Модули (классы) должны быть открыты для расширения, закрыты для модификации ===
        // 
        // Забавно, но сам по себе статический класс StringUtils скорее нарушает OCP, чем подчиняется ему.
    }
}
