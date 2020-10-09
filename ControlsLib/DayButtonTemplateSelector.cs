using ControlsLib.Extensions;
using ControlsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Controls.Calendar;

namespace ControlsLib
{
    public class DayButtonTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate WeekendDayTemplate { get; set; }
        public DataTemplate AddGuidDayTemplate { get; set; }
        public DayButtonTemplateSelector(){}

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var calendarButton = item as CalendarButtonContent;
            var currDate = calendarButton.Date;

            if(calendarButton.ButtonType == CalendarButtonType.Date)
            {
                DayOptionModel model = DaysDescription.GetDayModel(currDate);

                if (calendarButton.Date.DayOfWeek == DayOfWeek.Monday || calendarButton.Date.DayOfWeek == DayOfWeek.Tuesday)
                {
                    if(model == null)
                        return this.WeekendDayTemplate;
                    else
                    {
                        if(model.Workday == 0)
                            return this.WeekendDayTemplate;
                    }
                }
                else
                {
                    if(model != null)
                        if(model.Workday == 0)
                            return this.WeekendDayTemplate;
                }
                
                if(model != null)
                {
                    if (model.Addguid == 1)
                        return AddGuidDayTemplate;
                }
            }

            return this.DefaultTemplate;
        }

    }
}
