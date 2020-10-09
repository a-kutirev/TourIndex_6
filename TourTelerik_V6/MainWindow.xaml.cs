using ControlsLib.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Calendar;

namespace TourTelerik_V6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region Private members

        private DateTime m_currentDate;
        private string m_titleString;
        private DateTime contextCalendarDateTime;

        public event PropertyChangedEventHandler PropertyChanged;

        public DateTime CurrentDate
        {
            get => m_currentDate;
            set
            {
                m_currentDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CurrentDate"));                
            }
        }

        public string TitleString
        {
            get => m_titleString;
            set
            {
                m_titleString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TitleString"));
            }
        }
        #endregion

        #region Конструктор
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            calendar.FirstDayOfWeek = DayOfWeek.Monday;
            CurrentDate = DateTime.Now;
            TitleString = $"Дата: {m_currentDate.ToString("d MMMM yyyy")} г. Всего: XX экскурсий";
            DaysDescription.UpdateDayModelList();

            #region Set theme
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.RibbonView.xaml", UriKind.RelativeOrAbsolute) });
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
            { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.ScheduleView.xaml", UriKind.RelativeOrAbsolute) });
            #endregion
        }
        #endregion

        #region Установка темы
        private void a1_Checked(object sender, RoutedEventArgs e)
        {
            string name = (sender as RadRibbonRadioButton).Name;

            Application.Current.Resources.MergedDictionaries.Clear();

            switch (name)
            {
                case "a1":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.RibbonView.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.SheduleView.xaml", UriKind.RelativeOrAbsolute) });

                    break;
                case "a2":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Blue;component/Themes/Telerik.Windows.Controls.RibbonView.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.ScheduleView.xaml", UriKind.RelativeOrAbsolute) });

                    break;
                case "a3":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Transparent;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Transparent;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Transparent;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Transparent;component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Transparent;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Transparent;component/Themes/Telerik.Windows.Controls.RibbonView.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.ScheduleView.xaml", UriKind.RelativeOrAbsolute) });

                    break;
                case "a4":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Green;component/Themes/Telerik.Windows.Controls.RibbonView.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.ScheduleView.xaml", UriKind.RelativeOrAbsolute) });
                    GreenPalette.LoadPreset(GreenPalette.ColorVariation.Dark);

                    break;
                case "a5":
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.VisualStudio2019;component/Themes/System.Windows.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.VisualStudio2019;component/Themes/Telerik.Windows.Controls.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.VisualStudio2019;component/Themes/Telerik.Windows.Controls.Input.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.VisualStudio2019;component/Themes/Telerik.Windows.Controls.Docking.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.VisualStudio2019;component/Themes/Telerik.Windows.Controls.Navigation.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.VisualStudio2019;component/Themes/Telerik.Windows.Controls.RibbonView.xaml", UriKind.RelativeOrAbsolute) });
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary()
                    { Source = new Uri("/Telerik.Windows.Themes.Office_Silver;component/Themes/Telerik.Windows.Controls.ScheduleView.xaml", UriKind.RelativeOrAbsolute) });

                    VisualStudio2019Palette.LoadPreset(VisualStudio2019Palette.ColorVariation.Blue);
                    break;
            }
        }

        #endregion

        #region Щелчок прравой клавишей мыши на календаре
        private void CalendarContext_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            MessageBox.Show(contextCalendarDateTime.ToString("dd MMMM yyyy"));
        }               

        private void CalendarContext_Opened(object sender, RoutedEventArgs e)
        {
            CalendarButton calendarButton = (sender as RadContextMenu).GetClickedElement<CalendarButton>();
            if (calendarButton != null)
            {
                CalendarButtonContent calendarButtonContent = calendarButton.Content as CalendarButtonContent;
                if (calendarButtonContent != null)
                {
                    contextCalendarDateTime = calendarButtonContent.Date;
                }
            }
        }
        #endregion

        #region События календаря
        private void Calendar_Click(object sender, RoutedEventArgs e)
        {
            CalendarWindow cw = new CalendarWindow();
            cw.ShowDialog();
        }

        private void calendar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            container.Children.Clear();
            TitleString = $"Дата: {m_currentDate.ToString("d MMMM yyyy")} г. Всего: XX экскурсий.";

            UpdateGuidTree();
            UpdateMissTree();           
        }

        private void calendar_DisplayDateChanged(object sender, Telerik.Windows.Controls.Calendar.CalendarDateChangedEventArgs e)
        {
            DaysDescription.UpdateDayModelList();
        }
        #endregion

        #region Обновление дерева назначенных экскурсоводов
        private void UpdateGuidTree()
        {

        }
        #endregion

        #region Обновление списка отсутствующих
        private void UpdateMissTree()
        {

        }
        #endregion
    }
}
