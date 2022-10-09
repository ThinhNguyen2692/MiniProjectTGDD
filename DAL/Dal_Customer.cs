using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using DAL.DataModel;

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

        private IRepository<Customer> repository;
        private IUnitOfWork _uniOfWork;


        public  Dal_Customer (IUnitOfWork uniOfWork)
        {
            _uniOfWork = uniOfWork;
            this.repository = _uniOfWork.Repository<Customer>();
        }

        //lấy danh sách khách hàng
        public List<Customer> GetCustomers()
        {
            var data = repository.List().ToList();
            return data;
        }

        //cập nhật thông tin khách hàng
        public Customer UpdateCustomer(Customer customer)
        {
            var old_information = GetCustomerByphone(customer.CustomerPhone);
             repository.Update(old_information,customer);
             _uniOfWork.SaveChanges();
            return customer;
        }

        //lấy thông tin 1 khách hàng
        public Customer GetCustomerByphone(string NumberPhone)
        {
            var data = repository.GetById(c => c.CustomerPhone == NumberPhone);

            return data;
        }
    }
}
