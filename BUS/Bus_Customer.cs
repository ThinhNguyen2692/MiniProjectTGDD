using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelProject.Models;

namespace BUS
{
     public interface IBusCustomer
    {

        public List<Customer> GetCustomers();
        public Customer UpdateCustomer(Customer customer);
        public Customer GetCustomerByphone(string NumberPhone);
    }

    public class Bus_Customer: IBusCustomer
    {
       
        private IDalCustomer dal_Customer;

        public Bus_Customer(IDalCustomer dalCustomer)
        {
            dal_Customer = dalCustomer;
           
        }

        //lấy danh sách khách hàng
         public List<Customer> GetCustomers()
        {
            return dal_Customer.GetCustomers();
        }

        //cập nhật thông tin khách hàng
        public Customer UpdateCustomer(Customer customer)
        {
            return dal_Customer.UpdateCustomer(customer);

        }

        //lấy thông tin 1 khách hàng
        public Customer GetCustomerByphone(string NumberPhone)
        {
            return dal_Customer.GetCustomerByphone(NumberPhone);

        }
    }
}
