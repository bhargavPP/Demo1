using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo1.Models;
using System.Text;
using Demo1.DbContext;

namespace Demo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Demo1DbContext _db;

        public HomeController(Demo1DbContext db)
        {
            _db = db;

        }
        //for inserting data to database
        public IActionResult Insert(SalesOrders sales)
        {

            //SAVE DATA IN DATABASE
            if (ModelState.IsValid)
            {
                _db.Add(sales);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
            ////uPDATE DATA IN DATABASE
            if (ModelState.IsValid)
            {
                _db.Add(sales);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
        }
        //for Updating data to database
        public IActionResult Update(SalesOrders sales)
        {

            //SAVE DATA IN DATABASE
            if (ModelState.IsValid)
            {
                _db.Add(sales);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
            ////uPDATE DATA IN DATABASE
            if (ModelState.IsValid)
            {
                _db.Add(sales);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(sales);
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //method that takes an integer and returns the location numeral in abbreviated form. That is, you pass in 9 and it returns “ad"
        //  [HttpPost]
        public async Task<IActionResult> Method1(int InputString1)
        {

            int HighestPower = 0;
            int difference = InputString1;
            int i = 0;
            string result = string.Empty;
            do
            {
                int p = (int)(Math.Log(difference) / Math.Log(2));
                HighestPower = (int)Math.Pow(2, p);
                // Location[i] = Convert.ToChar(p);
                result += Convert.ToChar(65 + p).ToString().ToLower();
                difference = difference - HighestPower;
                i++;
                // int remain = difference % 2;
            } while (difference > 0);

            char[] myArr = result.ToCharArray();
            Array.Reverse(myArr);
            ViewData["Output1"] = new string(myArr);
            Numeral nmc = new Numeral();
            nmc.Output1 = new string(myArr);
            return View("Index");
        }
       
        //method that takes a location numeral and returns its value as an integer. That is, you pass “ad” in, and it returns 9
        public async Task<IActionResult> Method2(string InputString2)
        {
            // double pow_ab = Math.Pow(2, InputString);
            // ViewBag.CurrentOutput = pow_ab;
            byte[] asciiBytes = Encoding.ASCII.GetBytes(InputString2.ToUpper());
            double total = 0;
            for (int i = 0; i < asciiBytes.Length; i++)
            {
                total += Math.Pow(2, Convert.ToInt32(asciiBytes[i] - 65));
            }
            Numeral nmc = new Numeral();
            nmc.Output2 =(int) total;
            ViewData["Output2"] = new string(total.ToString());
            return View("Index");
        }

        //One method that takes a location numeral and returns it in abbreviated form. That is, you pass in “abbc” and it returns “ad"
        public async Task<IActionResult> Method3(string InputString3)
        {
            char temp;

            string str = InputString3.ToLower();
            char[] charstr = str.ToCharArray();
            //sort the string
            for (int i = 1; i < charstr.Length; i++)
            {
                for (int j = 0; j < charstr.Length - 1; j++)
                {
                    if (charstr[j] > charstr[j + 1])
                    {
                        temp = charstr[j];
                        charstr[j] = charstr[j + 1];
                        charstr[j + 1] = temp;
                    }
                }
            }
            string sortStr = new string(charstr);
            //  string updatedStr = string.Empty;
            int length = sortStr.Length - 1;

            for (int i = 0; i < length; i++)
            {
                string newone = string.Empty;
                if (sortStr[i] == sortStr[i + 1])
                {
                    byte[] asciiBytes = Encoding.ASCII.GetBytes(sortStr[i].ToString().ToLower());
                    char next = Convert.ToChar(asciiBytes[0] + 1);
                    string old = sortStr[i].ToString();
                    int index = sortStr.IndexOf(sortStr[i].ToString());
                    newone = next.ToString();
                    sortStr = sortStr.Remove(index, 1);
                    sortStr = sortStr.Replace(old, newone);
                    //sortStr = sortStr.Remove(sortStr.IndexOf(old));

                    length = length - 1;
                    i--;
                }
                Numeral nmc = new Numeral();
                nmc.Output3 = sortStr;
                ViewData["Output3"] = sortStr;

                //if (newone != string.Empty)
                //{
                //    updatedStr += newone;
                //    //sortStr.Replace(sortStr[i].ToString(), (newone));
                //}
                //else
                //{
                //    updatedStr += sortStr[i];
                //}
            }

            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
