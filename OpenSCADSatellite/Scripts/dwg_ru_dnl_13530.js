package Script
{
    class dwg_ru_dnl_13530
    {
        
        //Функция имени модуля
        function Name()
        {
            return "Расчет балки ((c) fletch/http://dwg.ru/dnl/13530)";
        }
        
        //Функция запуска модуля
        function Do(pathToProgramm)
        {
            //По хорошему тут должны быть ссылка на запуск dll
            //или exe файла с необходимым расчетом.
            
            var oShell = new ActiveXObject("Shell.Application");
            var commandtoRun = pathToProgramm + "\\Scripts\\dwg_ru_dnl_13530\\Эпюры.exe"; 
            oShell.ShellExecute(commandtoRun,"","","open","1");

            
            //return x + y;
        }
    }
}