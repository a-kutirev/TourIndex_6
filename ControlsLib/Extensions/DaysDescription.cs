using ControlsLib.DBWrapper;
using ControlsLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlsLib.Extensions
{
    public static class DaysDescription
    {
        private static List<DayOptionModel> m_dayModelList = new List<DayOptionModel>();
        private static Dictionary<DateTime, DayOptionModel> m_dictList = new Dictionary<DateTime, DayOptionModel>();

        public static void UpdateDayModelList()
        {
            m_dayModelList.Clear();
            m_dictList.Clear();
            CreateList();
        }

        public static DayOptionModel GetDayModel(DateTime dt)
        {
            if (m_dictList.ContainsKey(dt))
                return m_dictList[dt];
            else
                return null;
        }

        private static void CreateList()
        {
            string sql = "select * from daysoptions";
            m_dayModelList = (List<DayOptionModel>)MySqlWrapper.Select(sql).ToList<DayOptionModel>();

            int error = 0;
            List<DateTime> errorDate = new List<DateTime>();

            for (int i = 0; i < m_dayModelList.Count; i++)
            {
                if(m_dictList.ContainsKey(m_dayModelList[i].Daysoptiondate))
                {
                    error++;
                    continue;
                }
                m_dictList.Add(m_dayModelList[i].Daysoptiondate, m_dayModelList[i]);
            }
        }
     }
}
