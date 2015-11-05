package Script
{
    class xlsLoader
    {
        
        //Функция имени модуля
        function Name()
        {
            return "Запуск расчета в Calc";
        }
        
        //Функция запуска модуля
        function Do(x, y)
        {
            //По хорошему тут должны быть ссылка на запуск dll
            //или exe файла с необходимым расчетом.
            
            var oShell = new ActiveXObject("Shell.Application");
            var commandtoRun = "C:\\Program Files (x86)\\LibreOffice 4\\program\\scalc.exe"; 
            oShell.ShellExecute(commandtoRun,"","simple.xls","","1");

            
            return x + y;
        }
    }
}