using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{

    public interface IDalCustomer
    {
        public List<Customer> GetCustomers();
        public Customer UpdateCustomer(Customer customer);
        public Customer GetCustomerByphone(string NumberPhone);
    }

    public class Dal_Customer:IDalCustomer
    {
        
        private static MiniProjectTGDDContext context;

        public  Dal_Customer (MiniProjectTGDDContext miniProjectTGDDContext)
        {
            context = miniProjectTGDDContext; 
        }

        //lấy danh sách khách hàng
        public List<Customer> GetCustomers()
        {
            var data = context.Customers.ToList();
            return data;
        }

        //cập nhật thông tin khách hàng
        public Customer UpdateCustomer(Customer customer)
        {
            context = new MiniProjectTGDDContext();
             context.Customers.Update(customer);
             context.SaveChanges();
            return customer;
        }

        //lấy thông tin 1 khách hàng
        public Customer GetCustomerByphone(string NumberPhone)
        {
            var data = context.Customers.Where(c => c.CustomerPhone == NumberPhone).FirstOrDefault();
            return data;
        }
    }
}
