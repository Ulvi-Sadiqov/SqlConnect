using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace SQLConnection
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			string connectionStr = ConfigurationManager.ConnectionStrings["myDb"].ConnectionString;
			List<Person> people = new List<Person>();
			SqlConnection sqlConnection = new SqlConnection(connectionStr);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand("SELECT Id,Name,Surname,Age,Salary FROM People",sqlConnection);
		 SqlDataReader sqlDataReader =	sqlCommand.ExecuteReader();


			while (sqlDataReader.Read())
			{
				people.Add(new Person
				{
					Age = Convert.ToByte(sqlDataReader["Age"]),
					FirstName = sqlDataReader["Name"].ToString(),
					Salary = Convert.ToDecimal(sqlDataReader["Salary"]),
					Id = Convert.ToInt32(sqlDataReader["Id"]),
					Surname = sqlDataReader["Surname"].ToString()
				}
					


					);
			}

			dataGridView1.DataSource = people;

		}
	}
}
