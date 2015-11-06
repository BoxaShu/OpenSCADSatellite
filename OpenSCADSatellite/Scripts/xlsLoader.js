package Script
{
    class xlsLoader
    {
        
        //Функция имени модуля
        function Name()
        {
            return "Запуск расчета в Calc ((c) http://www.effect-project.ru)";
        }
        
        //Функция запуска модуля
        function Do(pathToProgramm)
        {
            //По хорошему тут должны быть ссылка на запуск dll
            //или exe файла с необходимым расчетом.

            //var commandtoRun = "C:\\Program Files (x86)\\LibreOffice 4\\program\\scalc.exe"; 
            //oShell.ShellExecute(commandtoRun,"", pathToProgramm + "\\Scripts\\simple.xls","","1");
            

            var oShell = new ActiveXObject("Shell.Application");
            var commandtoRun = pathToProgramm + "\\Scripts\\simple.xls"; 
            oShell.ShellExecute(commandtoRun,"","","open","1");

            //return x + y;
        }
    }
}