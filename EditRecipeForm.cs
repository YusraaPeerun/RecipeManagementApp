using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_management_app
{
	
	public partial class EditRecipeForm : Form
	{

		private int recipeId;
		private List<int> originalIngredientIDs;
		private List<int> originalStepIDs;

		public event EventHandler RecipeUpdated;
		public EditRecipeForm(int id)
		{
			InitializeComponent();
			recipeId = id;
			dgvSteps.RowsAdded += dgvSteps_RowsAdded;


			//this invisible column will be use for update
			dgvSteps.Columns.Add("StepID", "StepID");
			dgvSteps.Columns["StepID"].Visible = false;
			dgvIngredients.Columns.Add("StepID", "StepID");
			dgvIngredients.Columns["StepID"].Visible = false;
		}

		private void EditRecipeForm_Load(object sender, EventArgs e)
		{
			LoadRecipeDetails();
		}


		private void LoadRecipeDetails()
		{
			string query = "SELECT RecipeName, Instructions, Category, Image FROM Recipes WHERE RecipeID = @recipeId";

			using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
			using (SqlCommand cmd = new SqlCommand(query, conn))
			{
				cmd.Parameters.AddWithValue("@recipeId", recipeId);
				conn.Open();

				using (SqlDataReader reader = cmd.ExecuteReader())
				{
					if (reader.Read())
					{
						txtRecipeName.Text = reader["RecipeName"].ToString();
						txtInstructions.Text = reader["Instructions"].ToString();
						cboCategory.Text = reader["Category"].ToString();

						if (reader["Image"] != DBNull.Value)
						{
							byte[] imgBytes = (byte[])reader["Image"];
							using (MemoryStream ms = new MemoryStream(imgBytes))
							{
								pbRecipeImage.Image = Image.FromStream(ms);
							}
							lblDragDropHint.Visible = false;
						}
						else
						{
							pbRecipeImage.Image = null;
							lblDragDropHint.Visible = true;
						}
					}
				}
			}

			// Load ingredients
			LoadIngredients();

			// Load steps
			LoadSteps();
		}

		private void LoadIngredients()
		{
			string query = "SELECT IngredientName, Quantity, Cost FROM Ingredients WHERE RecipeID = @recipeId";
			using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
			using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
			{
				da.SelectCommand.Parameters.AddWithValue("@recipeId", recipeId);
				DataTable dt = new DataTable();
				da.Fill(dt);
				dgvIngredients.DataSource = dt;

				// Save original IngredientIDs for delete detection
				originalIngredientIDs = dt.AsEnumerable().Select(r => r.Field<int>("IngredientID")).ToList();
			}
		}

		private void LoadSteps()
		{
			string query = "SELECT StepNumber, Description FROM Steps WHERE RecipeID = @recipeId ORDER BY StepNumber";
			using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
			using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
			{
				da.SelectCommand.Parameters.AddWithValue("@recipeId", recipeId);
				DataTable dt = new DataTable();
				da.Fill(dt);
				dgvSteps.DataSource = dt;

				// Save original StepIDs for delete detection
				originalStepIDs = dt.AsEnumerable().Select(r => r.Field<int>("StepID")).ToList();
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			string recipeName = txtRecipeName.Text.Trim();
			string instructions = txtInstructions.Text.Trim();
			string category = cboCategory.Text;
			byte[] imgBytes = null;

			if (pbRecipeImage.Image != null)
			{
				using (MemoryStream ms = new MemoryStream())
				{
					pbRecipeImage.Image.Save(ms, pbRecipeImage.Image.RawFormat);
					imgBytes = ms.ToArray();
				}
			}

			using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
			{
				conn.Open();
				string query = "UPDATE Recipes SET RecipeName=@name, Instructions=@instructions, Category=@category, Image=@image WHERE RecipeID=@recipeId";


				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@name", recipeName);
					cmd.Parameters.AddWithValue("@instructions", instructions);
					cmd.Parameters.AddWithValue("@category", category);
					cmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = (object)imgBytes ?? DBNull.Value;
					cmd.Parameters.AddWithValue("@recipeId", recipeId);
					cmd.ExecuteNonQuery();
				}

				// Update ingredients
				foreach (DataGridViewRow row in dgvIngredients.Rows)
				{
					if (row.IsNewRow) continue;
					int ingredientId = row.Cells["IngredientID"].Value == DBNull.Value ? 0 : Convert.ToInt32(row.Cells["IngredientID"].Value);
					string name = row.Cells["IngredientName"].Value?.ToString() ?? "";
					string qty = row.Cells["Quantity"].Value?.ToString() ?? "";
					decimal cost = Convert.ToDecimal(row.Cells["Cost"].Value ?? 0);

					if (ingredientId == 0)
					{
						// New ingredient → INSERT
						string insertQuery = @"INSERT INTO Ingredients (RecipeID, IngredientName, Quantity, Cost) 
                               VALUES (@rid, @name, @qty, @cost)";
						using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
						{
							cmd.Parameters.AddWithValue("@rid", recipeId);
							cmd.Parameters.AddWithValue("@name", name);
							cmd.Parameters.AddWithValue("@qty", qty);
							cmd.Parameters.AddWithValue("@cost", cost);
							cmd.ExecuteNonQuery();
						}
					}
					else
					{
						// Existing ingredient → UPDATE
						string updateQuery = @"UPDATE Ingredients SET IngredientName=@name, Quantity=@qty, Cost=@cost WHERE IngredientID=@id";
						using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
						{
							cmd.Parameters.AddWithValue("@id", ingredientId);
							cmd.Parameters.AddWithValue("@name", name);
							cmd.Parameters.AddWithValue("@qty", qty);
							cmd.Parameters.AddWithValue("@cost", cost);
							cmd.ExecuteNonQuery();
						}
					}
				}

				// ---------- Delete removed ingredients ----------
				foreach (int id in originalIngredientIDs)
				{
					bool exists = dgvIngredients.Rows.Cast<DataGridViewRow>()
						.Any(r => r.Cells["IngredientID"].Value != DBNull.Value && Convert.ToInt32(r.Cells["IngredientID"].Value) == id);

					if (!exists)
					{
						string deleteQuery = "DELETE FROM Ingredients WHERE IngredientID=@id";
						using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
						{
							cmd.Parameters.AddWithValue("@id", id);
							cmd.ExecuteNonQuery();
						}
					}
				}



				// Update steps
				foreach (DataGridViewRow row in dgvSteps.Rows)
				{
					int stepID = row.Cells["StepID"].Value == DBNull.Value ? 0 : Convert.ToInt32(row.Cells["StepID"].Value);
					int stepNo = Convert.ToInt32(row.Cells["StepNumber"].Value);
					string desc = row.Cells["Description"].Value?.ToString() ?? "";

					if (stepID == 0)
					{
						// New step → INSERT
						string insertQuery = "INSERT INTO Steps (RecipeID, StepNumber, Description) VALUES (@rid, @no, @desc)";
						using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
						{
							cmd.Parameters.AddWithValue("@rid", recipeId);
							cmd.Parameters.AddWithValue("@no", stepNo);
							cmd.Parameters.AddWithValue("@desc", desc);
							cmd.ExecuteNonQuery();
						}
					}
					else
					{
						// Existing step → UPDATE
						string updateQuery = "UPDATE Steps SET StepNumber=@no, Description=@desc WHERE StepID=@id";
						using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
						{
							cmd.Parameters.AddWithValue("@no", stepNo);
							cmd.Parameters.AddWithValue("@desc", desc);
							cmd.Parameters.AddWithValue("@id", stepID);
							cmd.ExecuteNonQuery();
						}
					}
				}

				MessageBox.Show("Recipe updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				RecipeUpdated?.Invoke(this, EventArgs.Empty);
				this.Close();
			}
		}


		private void dgvSteps_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			for (int i = 0; i < dgvSteps.Rows.Count; i++)
			{
				if (!dgvSteps.Rows[i].IsNewRow)
				{
					dgvSteps.Rows[i].Cells["StepNumber"].Value = i + 1;
				}
			}
		}

	}
}
