using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Test_Results_Niema_Kitt;
using System.Data;

namespace Test_Results_Niema_Kitt
{
	public partial class Add_Employee : System.Web.UI.Page
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


		protected void btnCancel_Click (object sender, EventArgs e)
		{
			Response.Write("<script language='javascript'> window.close();</javascript>");
			Response.Redirect("~/UI/Default.aspx");
		}

		protected void DropDownList1_SelectedIndexChanged (object sender, EventArgs e)
		{
			string ebn = drpManager.SelectedValue.ToString();

			//located the manager base on their names 
			if (ebn == "Robert Smith")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Manager Assigned is Robert Smith');", true);
			}
			else if (ebn == "Eric Nash")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Manager Assigned is Eric Nash');", true);
			}
			else if (ebn == "Bob Edwards")
			{
				ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Manager Assigned is Bob Edwards');", true);
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

		protected void btnSave_Click (object sender, EventArgs e)
		{

			//declared and assigned a string to store the value of the selected items within the dropdown
			string ebn = drpManager.SelectedValue.ToString();

			//located the manager base on their names 
			if (ebn == "Robert Smith")
			{
				{
					using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
					{
						using (SqlCommand cm = new SqlCommand("SELECT Employee.First_Name, Employee.Last_Name, Employee.Empl_ID FROM Employee INNER JOIN Manager ON Employee.Empl_ID = Manager.Empl_ID WHERE (Manager.Man_Id = @Man_Id) ", cn))
						{
							cn.Open();

							cm.Parameters.AddWithValue("@Man_Id", "1234");
							SqlDataReader dr = cm.ExecuteReader();
							if (dr.HasRows)
							{
								cn.Close();
								using (SqlConnection cnd = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
								{
									using (SqlCommand cmd = new SqlCommand("INSERT INTO EMployee (Empl_ID, First_Name, Last_Name) VALUES( @Empl_Id,  @First_Name , @Last_Name)", cnd))
									{
										cnd.Open();

										cmd.Parameters.AddWithValue("@Empl_Id", txtEmployeeID.Text.Trim());
										cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text.Trim());
										cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text.Trim());

										int resut = cmd.ExecuteNonQuery();

										if (resut > 0)
										{
											cnd.Close();
											using (SqlConnection cnds = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
											{

												using (SqlCommand cmds = new SqlCommand("INSERT INTO Manager (Empl_ID, Man_Id, Roles_Id) VALUES(@Empl_Id , @Man_Id , @Roles_Id)", cnds))
												{
													string lists = lstRoles.Items[lstRoles.SelectedIndex].ToString();


													if (lists == "Support")
													{
														lists = "202";
													}
													else if (lists == "Etc.")
													{
														lists = "303";
													}
													else if (lists == "IT")
													{
														lists = "404";
													}
													cnds.Open();

													cmds.Parameters.AddWithValue("@Empl_Id", txtEmployeeID.Text);
													cmds.Parameters.AddWithValue("@Man_Id", "1234");
													cmds.Parameters.AddWithValue("@Roles_Id", lists);

													int resuts = cmds.ExecuteNonQuery();

													if (resuts > 0)
													{
														ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New Employee Add');", true);
														txtEmployeeID.Text = "";
														txtFirstName.Text = "";
														txtLastName.Text = "";
														drpManager.SelectedValue = null;
														lstRoles.SelectedValue = null;

													}
													cnds.Close();
													cnds.Dispose();
												}
											}
										}

									}
								}
							}
							dr.Close();
							dr.Dispose();
							cn.Dispose();
						}
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
							cn.Close();
							using (SqlConnection cnd = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
							{
								using (SqlCommand cmd = new SqlCommand("INSERT INTO EMployee (Empl_ID, First_Name, Last_Name) VALUES( @Empl_Id,  @First_Name , @Last_Name)", cnd))
								{
									cnd.Open();

									cmd.Parameters.AddWithValue("@Empl_Id", txtEmployeeID.Text.Trim());
									cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text.Trim());
									cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text.Trim());

									int resut = cmd.ExecuteNonQuery();

									if (resut > 0)
									{
										cnd.Close();
										using (SqlConnection cnds = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
										{

											using (SqlCommand cmds = new SqlCommand("INSERT INTO Manager (Empl_ID, Man_Id, Roles_Id) VALUES(@Empl_Id , @Man_Id , @Roles_Id)", cnds))
											{
												string lists = lstRoles.Items[lstRoles.SelectedIndex].ToString();


												if (lists == "Support")
												{
													lists = "202";
												}
												else if (lists == "Etc.")
												{
													lists = "303";
												}
												else if (lists == "IT")
												{
													lists = "404";
												}
												cnds.Open();

												cmds.Parameters.AddWithValue("@Empl_Id", txtEmployeeID.Text);
												cmds.Parameters.AddWithValue("@Man_Id", "2345");
												cmds.Parameters.AddWithValue("@Roles_Id", lists);

												int resuts = cmds.ExecuteNonQuery();

												if (resuts > 0)
												{
													ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New Employee Add');", true);
													txtEmployeeID.Text = "";
													txtFirstName.Text = "";
													txtLastName.Text = "";
													drpManager.SelectedValue = null;
													lstRoles.SelectedValue = null;

												}
												cnds.Close();
												cnds.Dispose();
											}
										}
									}

								}
							}
						}
						dr.Close();
						dr.Dispose();
						cn.Dispose();
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
							cn.Close();
							using (SqlConnection cnd = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
							{
								using (SqlCommand cmd = new SqlCommand("INSERT INTO EMployee (Empl_ID, First_Name, Last_Name) VALUES( @Empl_Id,  @First_Name , @Last_Name)", cnd))
								{
									cnd.Open();

									cmd.Parameters.AddWithValue("@Empl_Id", txtEmployeeID.Text.Trim());
									cmd.Parameters.AddWithValue("@First_Name", txtFirstName.Text.Trim());
									cmd.Parameters.AddWithValue("@Last_Name", txtLastName.Text.Trim());

									int resut = cmd.ExecuteNonQuery();

									if (resut > 0)
									{
										cnd.Close();
										using (SqlConnection cnds = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionEmployee"].ConnectionString))
										{

											using (SqlCommand cmds = new SqlCommand("INSERT INTO Manager (Empl_ID, Man_Id, Roles_Id) VALUES(@Empl_Id , @Man_Id , @Roles_Id)", cnds))
											{
												string lists = lstRoles.Items[lstRoles.SelectedIndex].ToString();


												if (lists == "Support")
												{
													lists = "202";
												}
												else if (lists == "Etc.")
												{
													lists = "303";
												}
												else if (lists == "IT")
												{
													lists = "404";
												}
												cnds.Open();

												cmds.Parameters.AddWithValue("@Empl_Id", txtEmployeeID.Text);
												cmds.Parameters.AddWithValue("@Man_Id", "3456");
												cmds.Parameters.AddWithValue("@Roles_Id", lists);

												int resuts = cmds.ExecuteNonQuery();

												if (resuts > 0)
												{
													ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('New Employee Add');", true);
													txtEmployeeID.Text = "";
													txtFirstName.Text = "";
													txtLastName.Text = "";
													drpManager.SelectedValue = null;
													lstRoles.SelectedValue = null;

												}
												cnds.Close();
												cnds.Dispose();
											}
										}
									}

								}
							}
						}
						dr.Close();
						dr.Dispose();
						cn.Dispose();
					}
				}
			}
		}
	}
}


