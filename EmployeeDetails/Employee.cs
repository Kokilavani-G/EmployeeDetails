using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeDetails.Class;

namespace EmployeeDetails
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        public async void btnGetAll_Click(object sender, EventArgs e)   //Get all User list
        {
           var response = await RestHelper.GetALL();
           txtresponse.Text = RestHelper.beautifyjson(response);  
        }
        public async void btnGet_Click(object sender, EventArgs e)     //Get single user list by passing user id
        {
            var response = await RestHelper.Get(txtID.Text);
            txtresponse.Text = RestHelper.beautifyjson(response);  
        }
        public async void btnPost_Click(object sender, EventArgs e)     //create a new employee
        {
            var response = await RestHelper.Post(txtName.Text,txtemail.Text,txtgender.Text,txtstatus.Text);
            txtresponse.Text = RestHelper.beautifyjson(response);  
            MessageBox.Show("Details Added successfully");
        }

        public async void btnPut_Click(object sender, EventArgs e)      //update the existing details
        {
            var response = await RestHelper.Put(txtID.Text, txtName.Text, txtemail.Text, txtgender.Text, txtstatus.Text);

            txtresponse.Text = RestHelper.beautifyjson(response);  
            MessageBox.Show("Details updated successfully");
        }

        public async void btnDelete_Click(object sender, EventArgs e)  //delete the employee details
        {
            var response = await Delete(txtID.Text);
            txtresponse.Text = response;  
        }
        public async Task<string> Delete(string id)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync("https://gorest.co.in/public-api/users/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        MessageBox.Show(((int)res.StatusCode).ToString() + "-" + res.StatusCode.ToString());
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                        {
                            return data;
                        }
                    }
                }
            }
            return string.Empty;
        }

        private void btnClear_Click(object sender, EventArgs e)        /// clear all textbox datas
        {
            txtID.Text = string.Empty;
            txtName.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtgender.Text = string.Empty;
            txtstatus.Text = string.Empty;
            txtresponse.Text = string.Empty;
        }
    }
}
