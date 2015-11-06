package Script
{
    class SiteLoader
    {
        //Функция имени модуля
        function Name()
        {
            return "Запуск страницы сайта ((c) http://webcad.pro)";
        }
        
        //Функция запуска модуля
        function Do(pathToProgramm)
        {
            //По хорошему тут должны быть ссылка на запуск dll
            //или exe файла с необходимым расчетом.
            
            var oShell = new ActiveXObject("Shell.Application");
            var commandtoRun = "http://webcad.pro/rasch.html"; 
            oShell.ShellExecute(commandtoRun,"","","open","1");
            
            //return x * y;
        }
    }
}