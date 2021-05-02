using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PbClient.Controllers
{
    public class RevenueController : Controller
    {
        public IActionResult Index()
        {
            var records = new List<string>();
            SqlConnection connection = new SqlConnection("Server=DESKTOP-9N59O8O\\SQLEXPRESS; Database=PizzaBox;Trusted_Connection=True;MultipleActiveResultSets=True");
            SqlCommand cmd = new SqlCommand("SELECT StoreId as Store, SUM(TotalPrice) AS Rev, DATEPART(YEAR, DateTime) AS Year, DATEPART(MONTH, DateTime) AS Month, datepart(week, datetime) as Week FROM Orders GROUP BY StoreId, DATEPART(YEAR, DateTime), DATEPART(MONTH, DateTime), datepart(week, datetime);", connection);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.HasRows)
            {
                while(reader.Read())
                {
                    var revenue = new Revenue();
                    revenue.Rev = reader.GetDouble(reader.GetOrdinal("Rev"));
                    revenue.Year = reader.GetInt32(reader.GetOrdinal("Year"));
                    revenue.Week = reader.GetInt32(reader.GetOrdinal("Week"));
                    revenue.Month = reader.GetInt32(reader.GetOrdinal("Month"));
                    revenue.Store = reader.GetInt32(reader.GetOrdinal("Store"));
                    records.Add(revenue.ToString());
                }
            }
            return View(records);
        }
    }
}
