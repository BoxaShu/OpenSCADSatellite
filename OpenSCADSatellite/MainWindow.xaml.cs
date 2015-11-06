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
using System.Net;
using System.Reflection;


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
            GetScreptListURL();
        }



        private void ListScript_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListScript.SelectedItem != null)
            {
                dynamic obj = GetScreptListLocal().Where(x => x.Name() == ListScript.SelectedItem.ToString()).FirstOrDefault();

                if (obj != null)
                {

                    String path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    obj.Do(path);
                    //string curAssemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;   

                    //String command = String.Format("{0}: {1}", obj.Name(), obj.Do(1, 2));
                        //MessageBox.Show(command);
                }
            }

        }


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // ... Get TabControl reference.
            var item = sender as TabControl;
            // ... Set Title to selected tab header.
            var selected = item.SelectedItem as TabItem;
            //this.Title = selected.Header.ToString();
            if (item.Name == "TabLocal")
            {
                ListScreptUpdate();
            }

            if (item.Name == "TabUrl")
            {
                GetScreptListURL();
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
            foreach (dynamic obj in GetScreptListLocal())
            {
                String command = String.Format("{0}", obj.Name());
                ListScript.Items.Add(command);
            }
        }


        /// <summary>
        /// Читаем список файлов в папке скрипты
        /// </summary>
        /// <returns></returns>
        private List<dynamic> GetScreptListLocal()
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


        private void GetScreptListURL()
        {
            //http://stackoverflow.com/questions/227575/encoding-trouble-with-httpwebresponse

            string url = "http://experement.spb.ru/OpenSCADSatelliteRepositories/repositories.xml";
            // Объект запроса
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            // Отправить запрос и получить ответ
            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            {
                // Получить поток
                using (StreamReader stream = new StreamReader(
                     response.GetResponseStream(), Encoding.UTF8))
                {

                    String[] buffer = stream.ReadToEnd().Split('\n');
                
                    foreach (string i in buffer)
                        ListScriptUrl.Items.Add(i.Trim());
                }
            }
        }

    }
}
