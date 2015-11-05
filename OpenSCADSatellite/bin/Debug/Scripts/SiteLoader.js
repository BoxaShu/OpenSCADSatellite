package Script
{
    class SiteLoader
    {
        //Функция имени модуля
        function Name()
        {
            return "Запуск страницы сайта";
        }
        
        //Функция запуска модуля
        function Do(x, y)
        {
            //По хорошему тут должны быть ссылка на запуск dll
            //или exe файла с необходимым расчетом.
            
            var oShell = new ActiveXObject("Shell.Application");
            var commandtoRun = "https://ya.ru/"; 
            oShell.ShellExecute(commandtoRun,"","","open","1");
            
            return x * y;
        }
    }
}