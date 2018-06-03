using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Newtonsoft.Json;
using Converter.Core;

namespace CppToCsharpConverter
{
    public partial class MainWindow
    {
        private const string FileName = "SettingsViewModel.txt";
        private SettingsViewModel SettingsViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Load();
            DataContext = SettingsViewModel;

            ConverterBox.ItemsSource = Enum.GetValues(typeof(KnownConverter));
            ConverterBox.SelectedIndex = 0;
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
                    SettingsViewModel = JsonConvert.DeserializeObject<SettingsViewModel>(txt);
            }
            if (SettingsViewModel == null)
                SettingsViewModel = new SettingsViewModel();
            SettingsViewModel.SearchTasks.Sort();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DirLostFocus(null, null);
            SettingsViewModel.SearchTasks.Sort();
            Save();
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.S && (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)))
            {
                DirLostFocus(null, null);
                SettingsViewModel.SearchTasks.Sort();
                Save();
            }
        }

        private void Save()
        {
            if (SettingsViewModel != null)
            {
                var txt = JsonConvert.SerializeObject(SettingsViewModel);
                if (!File.Exists(FileName))
                    File.Create(FileName);
                File.WriteAllText(FileName, JsonBeautifier.Beautify(txt));
            }
        }

        private void DirLostFocus(object sender, RoutedEventArgs e)
        {
            if (DirBox.SelectedItem != null)
                return;
            var newItem = DirBox.Text;

            if (!string.IsNullOrEmpty(newItem) && !SettingsViewModel.KnownDirectories.Contains(newItem))
                SettingsViewModel.KnownDirectories.Add(newItem);

            DirBox.SelectedItem = newItem;
        }

        private void AddLineClick(object sender, RoutedEventArgs e)
        {
            var dir = DirBox.SelectedItem as string;
            var search = SearchBox.Text;
            var converter = (KnownConverter)ConverterBox.SelectedItem;
            if (!string.IsNullOrEmpty(dir) && !string.IsNullOrEmpty(search))
                SettingsViewModel.SearchTasks.AddTask(search, converter, dir);
        }

        private void ClearItems(object sender, RoutedEventArgs e)
        {
            SettingsViewModel.SearchTasks.Clear();
        }

        #region Automation

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var prevContent = button.Content;
            button.Content = "Работаю...";
            button.IsEnabled = false;

            var tasks = await FindAndExecuteAsync();
            SettingsViewModel.SearchTasks.ResetTasks(tasks);
            Save();

            button.Content = prevContent;
            button.IsEnabled = true;
        }

        private Task<List<SearchTask>> FindAndExecuteAsync()
        {
            return Task.Run(() =>
            {
                var storeResultDir = "OutFiles";
                try
                {
                    if (Directory.Exists(storeResultDir))
                        Directory.Delete(storeResultDir, true);
                    Directory.CreateDirectory(storeResultDir);
                }
                catch
                {
                    //skip
                }

                var gt = SettingsViewModel.SearchTasks.GroupBy(t => t.SearchDir);

                var tasks = new List<SearchTask>();
                foreach (var tasts in gt)
                {
                    if (tasts.Key.IndexOf("BitShares", StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var manager = new Converter.BitShares.ConverterManager(SettingsViewModel.KnownTypes);
                        var list = manager.Execute(tasts.ToList(), storeResultDir);
                        tasks.AddRange(list);
                    }

                    if (tasts.Key.IndexOf("Golos", StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var manager = new Converter.Golos.ConverterManager(SettingsViewModel.KnownTypes);
                        var list = manager.Execute(tasts.ToList(), storeResultDir);
                        tasks.AddRange(list);
                    }

                    if (tasts.Key.IndexOf("Steem", StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var manager = new Converter.Steem.ConverterManager(SettingsViewModel.KnownTypes);
                        var list = manager.Execute(tasts.ToList(), storeResultDir);
                        tasks.AddRange(list);
                    }
                }

                return tasks;
            });
        }

        #endregion
    }
}
