/*Create a Web Application to display Employees aligned with their manager. As well as add a new employee into the system.
 * Created 7/25/2016 By: Niema Kitt*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Test_Results_Niema_Kitt;

namespace Test_Results_Niema_Kitt
{
	public partial class Default : System.Web.UI.Page
	{
		protected void Page_Load (object sender, EventArgs e)
		{
			//postback the dropdown to display the managers within the system
			if (!IsPostBack)
			{
				drpManager.DataSource = GetTable();
				//set the append data bound items to true to insert a blank space before the DataValue is displayed
				drpManager.AppendDataBoundItems = true;
				drpManager.Items.Insert(0, new ListItem(String.Empty, String.Empty));
				drpManager.SelectedIndex = 0;
				//Reference the string to combine the to columns together within the dropdown 
				drpManager.DataTextField = "FullName";
				drpManager.DataValueField = "FullName";
				drpManager.DataBind();


			}

		}

		protected void btnAdd_Click (object sender, EventArgs e)
		{
			//redirect the page to a new employee form when clicked
			Response.Redirect("~/UI/Add_Employee.aspx");
		}

		protected void drpManager_SelectedIndexChanged (object sender, EventArgs e)
		{
			//declared and assigned a string to store the value of the selected items within the dropdown
			string ebn = drpManager.SelectedValue.ToString();

			//located the manager base on their names 
			if (ebn == "Robert Smith")
			{
				//created a connection to the database employee
				using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
				{
					using (SqlCommand cm = new SqlCommand("SELECT Employee.First_Name, Employee.Last_Name, Employee.Empl_ID FROM Employee INNER JOIN Manager ON Employee.Empl_ID = Manager.Empl_ID WHERE (Manager.Man_Id = @Man_Id) ", cn))
					{
						cn.Open();
						//provided a parameter to hard code the manager felt this was better, however if more people are added as manager provide a dictionary and switch to select the manager with the index
						cm.Parameters.AddWithValue("@Man_Id", "1234");
						SqlDataReader dr = cm.ExecuteReader();
						if (dr.HasRows)
						{
							//provided a source to the gridview which is the results from the reader and bind the data
							grdEmployees.DataSource = dr;
							grdEmployees.DataBind();
						}
						dr.Close();//close the reader
					}
				}

			}
			else if (ebn == "Eric Nash")
			{
				using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
				{
					using (SqlCommand cm = new SqlCommand("SELECT Employee.First_Name, Employee.Last_Name, Employee.Empl_ID FROM Employee INNER JOIN Manager ON Employee.Empl_ID = Manager.Empl_ID WHERE (Manager.Man_Id = @Man_Id) ", cn))
					{
						cn.Open();

						cm.Parameters.AddWithValue("@Man_Id", "2345");
						SqlDataReader dr = cm.ExecuteReader();
						if (dr.HasRows)
						{
							grdEmployees.DataSource = dr;
							grdEmployees.DataBind();
						}
						dr.Close();
					}
				}
			}
			else if (ebn == "Bob Edwards")
			{
				using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
				{
					using (SqlCommand cm = new SqlCommand("SELECT Employee.First_Name, Employee.Last_Name, Employee.Empl_ID FROM Employee INNER JOIN Manager ON Employee.Empl_ID = Manager.Empl_ID WHERE (Manager.Man_Id = @Man_Id) ", cn))
					{
						cn.Open();

						cm.Parameters.AddWithValue("@Man_Id", "3456");
						SqlDataReader dr = cm.ExecuteReader();
						if (dr.HasRows)
						{
							grdEmployees.DataSource = dr;
							grdEmployees.DataBind();
						}
						dr.Close();
					}
				}
			}

		}
		DataTable GetTable ()
		{
			//declared and initialized a datatable to store the results of the query
			DataTable dt = new DataTable();
			using (SqlConnection Cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
			{
				using (SqlCommand cm = new SqlCommand("SELECT (EMployee.First_Name+ ' ' + EMployee.Last_Name) AS FullName FROM EMployee Where EMployee.Empl_ID = '1234' OR EMployee.Empl_ID = '3456' OR EMployee.Empl_ID = '2345' ", Cn))
				{
					//open the connection
					Cn.Open();
					//Declared and initialized a DataAdapter with the query
					SqlDataAdapter adpt = new SqlDataAdapter(cm);
					//filled the dataAdapter and full with the DataTable
					adpt.Fill(dt);
				}

			}
			//return the dataTable
			return dt;

		}
		//populated this event to create header manually
		protected void grdEmployees_RowCreated (object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.Header)
				{
					//Declared and Initialize the GriwView 
					GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

					//Declared and Initialize the TableCell
					TableCell HeaderCell = new TableCell();
					//Provided the Text and span for the columns to display a header
					HeaderCell.Text = "First Name";
					HeaderCell.ColumnSpan = 1;
					HeaderRow.Cells.Add(HeaderCell);

					HeaderCell = new TableCell();
					//Provided the Text and span for the columns to display a header
					HeaderCell.Text = "Last Name";
					HeaderCell.ColumnSpan = 1;
					HeaderRow.Cells.Add(HeaderCell);

					HeaderCell = new TableCell();
					//Provided the Text and span for the columns to display a header
					HeaderCell.Text = "Employee Id";
					HeaderCell.ColumnSpan = 2;
					HeaderRow.Cells.Add(HeaderCell);

					//locate the controls to and add the headerRow at 0 index for the gridview
					grdEmployees.Controls[0].Controls.AddAt(0, HeaderRow);

					GridViewRow HeaderRow1 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

					//locate the controls to and add the headerRow at 1 index for the gridview 
					grdEmployees.Controls[0].Controls.AddAt(1, HeaderRow1);
				}
			}
			catch (Exception ex)
			{
				//Show the exception error
				ex.Message.ToString();
			}
		}
	}
}
			
		

		

		
			
						
			
				
