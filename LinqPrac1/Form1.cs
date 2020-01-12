using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqPrac1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static List<Customer> customers = new List<Customer>
        {
            new Customer { Id = 1, FirstName = "Hyeyoung", LastName = "Byun", DOB = new DateTime(1989,10,7), IsActive = true, Balance = 29.90M },
            new Customer { Id = 2, FirstName = "Minyoung", LastName = "Jun", DOB = new DateTime(1989,11,2), IsActive = true, Balance = 39.90M },
            new Customer { Id = 3, FirstName = "Hyunah", LastName = "Lee", DOB = new DateTime(1995,11,7), IsActive = true, Balance = 0 },
            new Customer { Id = 4, FirstName = "Naeun", LastName = "Shin", DOB = new DateTime(1992,5,29), IsActive = true, Balance = 120.50M },
            new Customer { Id = 5, FirstName = "Hyobin", LastName = "Lee", DOB = new DateTime(1997,5,28), IsActive = true, Balance = 20 },
            new Customer { Id = 6, FirstName = "Hyerim", LastName = "Park", DOB = new DateTime(1989,10,30), IsActive = false, Balance = 0 },
            new Customer { Id = 7, FirstName = "Minyoung", LastName = "Lee", DOB = new DateTime(1975,1,14), IsActive = false, Balance = 131.10M },
            new Customer { Id = 8, FirstName = "Minah", LastName = "Lee", DOB = new DateTime(1981,10,7), IsActive = false, Balance = 5 },
            new Customer { Id = 9, FirstName = "Hyeyoung", LastName = "Ha", DOB = new DateTime(1988,9,10), IsActive = true, Balance = 229.5M },
            new Customer { Id = 10, FirstName = "Hannah", LastName = "Shim", DOB = new DateTime(1990,3,4), IsActive = true, Balance = 100 },
            new Customer { Id = 11, FirstName = "Yeseul", LastName = "Kim", DOB = new DateTime(1994,5,6), IsActive = true, Balance = 10.5M },
            new Customer { Id = 12, FirstName = "Sarang", LastName = "Yoo", DOB = new DateTime(2020,1,2), IsActive = false, Balance = 0 },
            new Customer { Id = 13, FirstName = "Jeonghyun", LastName = "Kim", DOB = new DateTime(1989,6,21), IsActive = true, Balance = 50 },
            new Customer { Id = 14, FirstName = "Jiyun", LastName = "Jo", DOB = new DateTime(1989,11,1), IsActive = false, Balance = 24.50M },
            new Customer { Id = 15, FirstName = "Youngun", LastName = "Park", DOB = new DateTime(1990,2,27), IsActive = true, Balance = 30.90M },
            new Customer { Id = 16, FirstName = "Jinah", LastName = "Kim", DOB = new DateTime(1983,10,7), IsActive = true, Balance = 90 },
        };

        private void button1_Click(object sender, EventArgs e)
        {
            //1. Get a customer with Id number 1
            var selectedCustomer = customers.Where(m => m.Id.Equals(1)).FirstOrDefault();
            DisplayResult(selectedCustomer);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //2. Get customers with Id number that is greater than 5 and smaller than 12
            var selectedCustomer = new List<Customer>();
            selectedCustomer = customers.Where(m => m.Id > 5 && m.Id < 12).ToList();
           
            //foreach (var element in customers.Where(m=> m.Id >5 && m.Id < 12))
            //{
            //    selectedCustomer.Add(element);
            //}
            
            DisplayResult(selectedCustomer);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //3. Get customers' last name in alphabetical order

            var selectedCustomer = new List<Customer>();
            selectedCustomer = customers.OrderBy(m => m.LastName).ToList();
            
            //foreach (var element in customers.OrderBy(x => x.LastName))
            //{
            //    selectedCustomer.Add(element);
            //}

            DisplayResult(selectedCustomer);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //4. Get customers who was born between 1991-1987 and is not inactive
            var selectedCustomer = new List<Customer>();
            selectedCustomer = customers.Where(m => m.DOB.Year <= 1991 && m.DOB.Year >= 1987 && m.IsActive == false).ToList();

            //foreach (var element in customers.Where(m => m.DOB.Year <= 1991 && m.DOB.Year >= 1987 && m.IsActive == false))
            //{
            //    selectedCustomer.Add(element);
            //}

            DisplayResult(selectedCustomer);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //5. Get number of customers who was born between Jan-Apr
            int selectedCustomer = customers.Where(m => m.DOB.Month <= 4 && m.DOB.Month >= 1).ToArray().Length;

            //foreach (var element in customers.Where(m => m.DOB.Month <= 4 && m.DOB.Month >= 1))
            //{
            //    selectedCustomer.Add(element);
            //}
            //int count = selectedCustomer.Count;

            //DisplayResult(count.ToString());

            DisplayResult(selectedCustomer.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //6. Get customers' firstname who are inactive and have any balances
            var selectedCustomer = customers.Where(m => m.IsActive == false && m.Balance > 0).Select(m => m.FirstName).ToList();

            //var selectedCustomer = new List<string>();
            //    foreach (Customer element in customers.Where(m => m.IsActive == false && m.Balance >0))
            //{
            //    selectedCustomer.Add(element.FirstName);
            //}

            DisplayResult(selectedCustomer);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //7. Get a customer who has the highest balance

            Customer selectedCustomers = customers.OrderByDescending(m => m.Balance).First();
            DisplayResult(selectedCustomers);

            //var selectedCustomer = new List<string>();
            //var selectedCustomer = new Customer();
            //var selectedCustomers = new List<Customer>();
            //foreach (Customer element in customers.OrderBy(m => m.Balance))
            //{
            //    selectedCustomers.Add(element);
            //}

            //selectedCustomer = selectedCustomers.Last();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //8. Get customers who have not zero balance and round up balance to the nearest dollar
            var selectedCustomer = new List<Customer>();
            selectedCustomer = customers.Where(m => m.Balance != 0).ToList();
            selectedCustomer.ForEach(m => Math.Round(m.Balance, 0, MidpointRounding.AwayFromZero));

                //.Select(m => new Customer
                //{
                //    FirstName = m.FirstName,
                //    LastName = m.LastName,
                //    Balance = Math.Round(m.Balance, 0, MidpointRounding.AwayFromZero),
                //    DOB = m.DOB,
                //    Id = m.Id,
                //    IsActive = m.IsActive
                //}).ToList();


            //foreach (Customer element in customers.Where(m => m.Balance != 0))
            //{
            //    var balance = element.Balance;
            //    element.Balance = Math.Round(element.Balance, 0);
            //    selectedCustomer.Add(element);
            //}
            DisplayResult(selectedCustomer);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //9. Get customers who have the same first name as others do in the list
            var selectedCustomer = new List<Customer>();
            selectedCustomer = customers.Where(m => customers.Any(n => n.FirstName.Equals(m.FirstName) && !m.Id.Equals(n.Id))).ToList();

            //foreach (Customer elements in customers.FindAll(m => m.FirstName.StartsWith(name)))
            //{
            //    name = elements.FirstName;
            //    selectedCustomer.Add(elements);
            //}

            DisplayResult(selectedCustomer);
        }

        /**********이 문제는 VIP class를 사용해야함**********/
        private void button10_Click(object sender, EventArgs e)
        {
            //10. Active한 사람들 중에 Balance가 $100 이상인 사람들은 VIP임. DOB를 Age(만 나이)로 바꾸고 Point는 $5당 1포인트.
            var vips = new List<VIP>();
            vips = customers.Where(m => m.IsActive == true && m.Balance >= 100)
                .Select(m => new VIP { FullName = m.FirstName + m.LastName, Age = DateTime.Now.Year - m.DOB.Year, Point = Convert.ToInt32(m.Balance / 5) }).ToList();

            //foreach (Customer elements in customers.Where(m => m.IsActive == true && m.Balance >= 100))
            //{
            //    string fullName = elements.FirstName + elements.LastName;
            //    int age = DateTime.Now.Year - elements.DOB.Year;
            //    int point = Convert.ToInt32(elements.Balance / 5);
            //    //vips.Add(fullName, age, point);
            //    //vips = new VIP { FullName = fullName, Age = age, Point = point }
            //}

            DisplayResult(vips);
        }

        private void DisplayResult(Customer c)
        {
            textBox1.Clear();
            textBox1.Text += "Id: " + c.Id + ", FirstName: " + c.FirstName + ", LastName: " + c.LastName + ", DOB: " + c.DOB.ToString("yyyy/MM/dd") + ", IsActive: " + c.IsActive.ToString() + ", Balance: " + c.Balance.ToString("C") + Environment.NewLine;
        }

        private void DisplayResult(List<Customer> customers)
        {
            textBox1.Clear();
            foreach(var c in customers)
            {
                textBox1.Text += "Id: " + c.Id + ", FirstName: " + c.FirstName + ", LastName: " + c.LastName + ", DOB: " + c.DOB.ToString("yyyy/MM/dd") + ", IsActive: " + c.IsActive.ToString() + ", Balance: " + c.Balance.ToString("C") + Environment.NewLine;
            }
        }

        private void DisplayResult(string value)
        {
            textBox1.Clear();
            textBox1.Text += value;
        }

        private void DisplayResult(List<string> values)
        {
            textBox1.Clear();
            foreach(var v in values)
            {
                textBox1.Text += v + Environment.NewLine;
            }
        }

        private void DisplayResult(List<VIP> vips)
        {
            textBox1.Clear();
            foreach(var v in vips)
            {
                textBox1.Text += "FullName: " + v.FullName + ", age: " + v.Age + ", Point: " + v.Point + Environment.NewLine;
            }
        }
    }
}
