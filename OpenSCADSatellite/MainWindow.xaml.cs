/* © Vladimir Shulzhitskiy, 2015
 * MainWindow.xaml.cs
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.IO;
using Microsoft.JScript;
using System.CodeDom.Compiler;


namespace OpenSCADSatellite
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Запуск приложения
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ListScreptUpdate();
        }

        /// <summary>
        /// Принудительно Перечитать/обновить список заново
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListScreptUpdate();
        }

        private void ListScript_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListScript.SelectedItem != null)
            {
                dynamic obj = GetScreptList().Where(x => x.Name() == ListScript.SelectedItem.ToString()).FirstOrDefault();

                if (obj != null)
                {
                        String command = String.Format("{0}: {1}", obj.Name(), obj.Do(1, 2));
                        //MessageBox.Show(command);
                }
            }

        }

        /// <summary>
        /// Обновляем listBox со списком скриптов
        /// </summary>
        private void ListScreptUpdate()
        {
            //очищаем список
            ListScript.Items.Clear();

            //Пишем коллекцию заново
            foreach (dynamic obj in GetScreptList())
            {
                String command = String.Format("{0}", obj.Name());
                ListScript.Items.Add(command);
            }
        }


        /// <summary>
        /// Читаем список файлов в папке скрипты
        /// </summary>
        /// <returns></returns>
        private List<dynamic> GetScreptList()
        {
            const string scriptsDirectory = "Scripts";
            var list = (from file in Directory.GetFiles(scriptsDirectory, "*.js")
                        let codeProvider = new Microsoft.JScript.JScriptCodeProvider()
                        let cp = new CompilerParameters
                        {
                            GenerateExecutable = false,
                            GenerateInMemory = true,
                            TreatWarningsAsErrors = true
                        }
                        select codeProvider.CompileAssemblyFromFile(cp, file) into results
                        select results.CompiledAssembly.GetTypes() into types
                        from t in types
                        where t.IsClass && t.Namespace == "Script"
                        select t into solver
                        select Activator.CreateInstance(solver)).ToList();
            return list;
        }

    }
}
