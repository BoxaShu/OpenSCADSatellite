import System;

package Script
{
    class JSCode
    {
        function Name()
        {
            return "Запуск простого JS кода";
        }
        
        function Do(pathToProgramm)
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            return  pathToProgramm + " " + rnd.Next();
        }
    }
}