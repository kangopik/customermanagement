using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CustomerManagement.Models;
using Dapper;
using System.Linq;
using System.Web;

namespace CustomerManagement.Repository
{
    public class CustomerRepositories
    {
        public SqlConnection con;
        public void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["CustomerConnection"].ToString();
            con = new SqlConnection(constr);
        }

        public List<Customer> GetAllCustomer()
        {
            try
            {
                connection();
                con.Open();
                IList<Customer> CustomerList = SqlMapper.Query<Customer>(con, "SPSelectCustomerAll").ToList();
                con.Close();
                return CustomerList.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Customer> GetCustomerById(int id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", id);
                connection();
                con.Open();
                List<Customer> CustomerList = SqlMapper.Query<Customer>(con, "SPSelectCustomerById", param, commandType: CommandType.StoredProcedure).ToList();
                con.Close();
                return CustomerList.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddCustomer(Customer objCustomer)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@FirstName", objCustomer.FirstName);
                param.Add("@LastName", objCustomer.LastName);
                param.Add("@DOB", objCustomer.DOB);
                param.Add("@Gender", objCustomer.Gender);
                param.Add("@PhoneNumber", objCustomer.PhoneNumber);
                param.Add("@EmailAddress", objCustomer.EmailAddress);
                param.Add("@CompanyName", objCustomer.CompanyName);
                connection();
                con.Open();
                con.Execute("SPInsertCustomer", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCustomer(Customer objCustomer)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", objCustomer.CustomerID);
                param.Add("@FirstName", objCustomer.FirstName);
                param.Add("@LastName", objCustomer.LastName);
                param.Add("@DOB", objCustomer.DOB);
                param.Add("@Gender", objCustomer.Gender);
                param.Add("@PhoneNumber", objCustomer.PhoneNumber);
                param.Add("@EmailAddress", objCustomer.EmailAddress);
                param.Add("@CompanyName", objCustomer.CompanyName);
                connection();
                con.Open();
                con.Execute("SPUpdateCustomer", param, commandType: CommandType.StoredProcedure);
                con.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteCustomer(int Id)
        {
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@CustomerID", Id);
                connection();
                con.Open();
                con.Execute("SPDeleteCustomer", param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}