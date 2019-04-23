using Application.IO.Site.Services.Business.Select;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Application.IO.Site.Services.Reports
{
    public class AdvogadoReport
    {
        protected int GetWeekOfYear(DateTime date)
        {
            CultureInfo myCI = new CultureInfo("pt-BR");
            Calendar myCal = myCI.Calendar;

            return myCal.GetWeekOfYear(date, myCI.DateTimeFormat.CalendarWeekRule, myCI.DateTimeFormat.FirstDayOfWeek);
        }

        public List<int> CountUserReport(Guid user)
        {
            var date = DateTime.Now;
            var dateMesPas = date.AddMonths(-1);
            int ano = date.Year, mes = date.Month, dia = date.Day;
            var sem = GetWeekOfYear(date);

            var list = new AdvogadoSelect().GetGrid(user);

            var retorno = new List<int>();

            return new List<int> {
                    list.Count(c => c.Date.Year == dateMesPas.Year && c.Date.Month == dateMesPas.Month),
                    list.Count(c => c.Date.Year == ano && c.Date.Month == mes),
                    list.Count(c => GetWeekOfYear(c.Date) == sem),
                    list.Count(c => c.Date.Year == ano && c.Date.Month == mes && c.Date.Day == dia),
                };
        }
    }
}
