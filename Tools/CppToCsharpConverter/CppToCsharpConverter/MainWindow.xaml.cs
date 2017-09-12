using System;
using System.IO;
using System.Text;
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
        private const string FileName = "SettingsViewModel.txt";


        public StructConverter StructConverter;
        public InterfaceConverter InterfaceConverter;
        public SettingsViewModel SettingsViewModel { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            Load();
            DataContext = SettingsViewModel;
            StructConverter = new StructConverter(SettingsViewModel.KnownTypes);
            InterfaceConverter = new InterfaceConverter(SettingsViewModel.KnownTypes);

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
                SettingsViewModel.AddTask(search, converter, dir);
        }

        #region Automation

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var prevContent = button.Content;
            button.Content = "Работаю...";
            button.IsEnabled = false;

            var msg = await FindAndExecuteAsync();
            AddNewTasks(InterfaceConverter);
            InterfaceConverter.UnknownTypes.Clear();
            AddNewTasks(StructConverter);
            StructConverter.UnknownTypes.Clear();
            SettingsViewModel.SearchTasks.Sort();
            Save();

            if (!string.IsNullOrEmpty(msg))
                MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            button.Content = prevContent;
            button.IsEnabled = true;
        }

        private Task<string> FindAndExecuteAsync()
        {
            return Task.Run(() =>
            {
                var msg = new StringBuilder();
                foreach (var item in SettingsViewModel.SearchTasks)
                {
                    try
                    {
                        switch (item.Converter)
                        {
                            case KnownConverter.InterfaceConverter:
                                {
                                    InterfaceConverter.FindAndExecute(item);
                                    break;
                                }
                            case KnownConverter.StructConverter:
                                {
                                    StructConverter.FindAndExecute(item);
                                    break;
                                }
                        }
                    }
                    catch (Exception e)
                    {
                        msg.AppendLine(e.Message);
                        msg.AppendLine(e.StackTrace);
                    }
                }
                return msg.ToString();
            });
        }


        private void AddNewTasks(BaseConverter converter)
        {
            foreach (var itm in converter.UnknownTypes)
                SettingsViewModel.AddTask(itm);
        }


        #endregion

        #region Convert

        protected void OutputContentChanged()
        {
            try
            {
                // Output.Text = StructConverter.TryParseText(Input.Text, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Input_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                OutputContentChanged();
        }

        private void Input_OnLostFocus(object sender, RoutedEventArgs e)
        {
            OutputContentChanged();
        }

        #endregion Convert



    }
}