using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salary
{
    public class ProductSalary
    {
        public int MaNV { get; set; }
        public int PrSalaryID { get; set; }
        public string PrSalaryName { get; set; }
        public int PrSalaryPrice { get; set; }
        public int PrSalaryAmount { get; set; }
        public int PrSalaryTotal { get; set; }
    }
    public class Deduct
    {
        public int MaNV { get; set; }
        public int DeductID { get; set; }
        public string DeductName { get; set; }
        public int DeductMoney { get; set; }
    }
    public class Allowance
    {
        public int MaNV { get; set; }
        public int AllowanceID { get; set; }
        public string AllowanceName { get; set; }
        public int AllowanceMoney { get; set; }
    }
    public class SalaryHistory
    {
        public int MaNV { get; set; }
        public int AllowanceID { get; set; }
        public int SAprodID { get; set; }
        public int DeductID { get; set; }
        public int SAprodPrice { get; set; }
        public int SAprodAmount { get; set; }
        public int Money { get; set; }
    }
    public class TotalSalary
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public int TolalAllowance { get; set; }
        public int TotalDeduct { get; set; }
        public int RealReceive { get; set; }
    }
    public class Charity
    {
        public int MaNV { get; set; }
        public string Tennhanvien { get; set; }
        public int NumberOfLate { get; set; }
        public int Money { get; set; }
    }
}
