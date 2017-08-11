using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CppToCsharpConverter.Converters;
using Newtonsoft.Json;

namespace CppToCsharpConverter
{
    public partial class MainWindow
    {
        private const string FileName = "CustomProperties.txt";

        public IConverter Converter = new StructConverter();
        public CustomProperties CustomProperties { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Load();
            DataContext = CustomProperties;
        }

        protected void ContentChanged()
        {
            try
            {
                Output.Text = Converter.Execute(Input.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Input_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                ContentChanged();
        }

        private void Input_OnLostFocus(object sender, RoutedEventArgs e)
        {
            ContentChanged();
        }

        private void Load()
        {
            if (!File.Exists(FileName) && File.Exists($@"..\..\{FileName}"))
            {
                File.Copy($@"..\..\{FileName}", FileName);
            }
            if (File.Exists(FileName))
            {
                var txt = File.ReadAllText(FileName);
                if (!string.IsNullOrEmpty(txt))
                    CustomProperties = JsonConvert.DeserializeObject<CustomProperties>(txt);
            }
            if (CustomProperties == null)
                CustomProperties = new CustomProperties();
        }

        private void Save()
        {
            if (CustomProperties != null)
            {
                var txt = JsonConvert.SerializeObject(CustomProperties);
                if (!File.Exists(FileName))
                    File.Create(FileName);
                File.WriteAllText(FileName, txt);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Save();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                Save();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var prevContent = button.Content;
            button.Content = "Работаю...";
            Automation.IsEnabled = false;

            var msg = await FindAndExecuteAsync();
            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            button.Content = prevContent;
            Automation.IsEnabled = true;
        }

        private Task<string> FindAndExecuteAsync()
        {
            return Task.Run(() =>
            {
                var outDir = "out";//$"{DateTime.Now:yyyyMMddhhmmss}";
                var msg = FindAndExecute(CustomProperties.PathToSteem, CustomProperties.SearchItems, CustomProperties.SteemSearchItemsPath, "s", outDir);
                msg += FindAndExecute(CustomProperties.PathToGolos, CustomProperties.SearchItems, CustomProperties.GolosSearchItemsPath, "g", outDir);
                return msg;
            });
        }

        private string FindAndExecute(string dirPath, string searchItems, Dictionary<string, string> searchItemsPath, string pref, string outDir)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(searchItems))
                    return string.Empty;

                var items = searchItems.Split(new[] { Environment.NewLine, "\r\n", "\n\r", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in items)
                {
                    var searchLine = item.Trim();
                    var text = string.Empty;
                    if (searchItemsPath.ContainsKey(searchLine))
                    {
                        text = SearchInFile.Search(searchItemsPath[searchLine], searchLine);
                    }

                    if (string.IsNullOrEmpty(text))
                    {
                        var files = Directory.GetFiles(dirPath, "*.*", SearchOption.AllDirectories).Where(f => f.EndsWith(".cpp") || f.EndsWith(".hpp"));
                        foreach (var file in files)
                        {
                            text = SearchInFile.Search(file, searchLine);
                            if (!string.IsNullOrEmpty(text))
                            {
                                if (searchItemsPath.ContainsKey(searchLine))
                                {
                                    searchItemsPath[searchLine] = file;
                                }
                                else
                                {
                                    searchItemsPath.Add(searchLine, file);
                                }
                                break;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(text))
                    {
                        var path = String.Empty;
                        if (searchItemsPath.ContainsKey(searchLine))
                        {
                            var file = searchItemsPath[searchLine];
                            var startFrom = file.IndexOf("golos", StringComparison.Ordinal);
                            if (startFrom < 0)
                                startFrom = file.IndexOf("steem", StringComparison.Ordinal);
                            path = file.Substring(startFrom);
                        }
                        var converted = Converter.Execute(text, path);
                        if (!Directory.Exists(outDir))
                            Directory.CreateDirectory(outDir);
                        File.WriteAllText($"{outDir}\\in {searchLine} {pref}.txt", text);
                        File.WriteAllText($"{outDir}\\out {searchLine} {pref}.txt", converted);
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return string.Empty;
        }
    }
}