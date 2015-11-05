package Script
{
    class NotepadLoader
    {
        
        //Функция имени модуля
        function Name()
        {
            return "Запуск блокнота";
        }
        
        //Функция запуска модуля
        function Do(x, y)
        {
            //По хорошему тут должны быть ссылка на запуск dll
            //или exe файла с необходимым расчетом.
            
            var oShell = new ActiveXObject("Shell.Application");
            var commandtoRun = "C:\\Windows\\notepad.exe"; 
            oShell.ShellExecute(commandtoRun,"","","open","1");
            
            return x + y;
        }
    }
}