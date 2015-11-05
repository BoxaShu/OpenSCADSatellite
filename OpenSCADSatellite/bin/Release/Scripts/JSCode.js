import System;

package Script
{
    class JSCode
    {
        function Name()
        {
            return "Запуск простого JS кода";
        }
        
        function Do(x, y)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next();
        }
    }
}