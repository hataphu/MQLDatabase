using System;
/// <summary>
/// Summary description for Commons
/// </summary>

namespace MQLDatabase.Common
{
    public static class Commons
    {
        public static DateTime GetFirstDayOfWeek(int year, int month, int weekNumber)
        {
            DateTime dt = new DateTime(year, month, 1);
            if (weekNumber == 1)
            {
                return dt;
            }
            else
            {
                dt = dt.AddDays((weekNumber - 1) * 7);

                switch (dt.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        dt = dt.AddDays(-6);
                        break;
                    case DayOfWeek.Monday:
                        dt = dt.AddDays(0);
                        break;
                    case DayOfWeek.Tuesday:
                        dt = dt.AddDays(-1);
                        break;
                    case DayOfWeek.Wednesday:
                        dt = dt.AddDays(-2);
                        break;
                    case DayOfWeek.Thursday:
                        dt = dt.AddDays(-3);
                        break;
                    case DayOfWeek.Friday:
                        dt = dt.AddDays(-4);
                        break;
                    case DayOfWeek.Saturday:
                        dt = dt.AddDays(-5);
                        break;
                    default:
                        break;
                }

                if (dt.Month > month)
                {
                    throw new Exception("Không tồn tại tuần thứ " + weekNumber.ToString() + " trong tháng " + month.ToString() + " năm " + year.ToString());
                }
            }

            return dt;
        }

        public static DateTime GetLastDayOfWeek(int year, int month, int weekNumber)
        {
            DateTime dt = new DateTime(year, month, 1, 23, 59, 59);

            dt = dt.AddDays((weekNumber - 1) * 7);

            switch (dt.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dt = dt.AddDays(0);
                    break;
                case DayOfWeek.Monday:
                    dt = dt.AddDays(6);
                    break;
                case DayOfWeek.Tuesday:
                    dt = dt.AddDays(5);
                    break;
                case DayOfWeek.Wednesday:
                    dt = dt.AddDays(4);
                    break;
                case DayOfWeek.Thursday:
                    dt = dt.AddDays(3);
                    break;
                case DayOfWeek.Friday:
                    dt = dt.AddDays(2);
                    break;
                case DayOfWeek.Saturday:
                    dt = dt.AddDays(1);
                    break;
                default:
                    break;
            }

            if (dt.Month > month)
            {
                for (int i = 0; i < 7; i++)
                {
                    dt = dt.AddDays(-1);
                    if (dt.Month == month)
                    {
                        break;
                    }
                }
            }

            return dt;
        }

        public static int CountWeeksInMonth(DateTime thisMonth)
        {
            int mondays = 0;
            int month = thisMonth.Month;
            int year = thisMonth.Year;
            int daysThisMonth = DateTime.DaysInMonth(year, month);
            DateTime beginingOfThisMonth = new DateTime(year, month, 1);
            for (int i = 0; i < daysThisMonth; i++)
                if (beginingOfThisMonth.AddDays(i).DayOfWeek == DayOfWeek.Monday)
                    mondays++;
            return mondays;
        }
    }
}