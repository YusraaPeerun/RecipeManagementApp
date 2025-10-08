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
	public partial class MainForm : Form
	{

	public MainForm()
		{
			InitializeComponent();
			cboCategory.SelectedIndex = 0;
			pbRecipeImage.AllowDrop = true;

			// Subscribe to events
			pbRecipeImage.DragEnter += pbRecipeImage_DragEnter;
			pbRecipeImage.DragDrop += pbRecipeImage_DragDrop;
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			AddRecipeForm addForm = new AddRecipeForm();
			if (addForm.ShowDialog() == DialogResult.OK)
			{
				int newRecipeId = (int)addForm.Tag; // Get the new RecipeID
			}
			LoadRecipes(); // Method to reload DataGridView from Recipes table
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if (dgvRecipes.CurrentRow == null)
			{
				MessageBox.Show("Please select a recipe to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			int recipeId = Convert.ToInt32(dgvRecipes.CurrentRow.Cells["RecipeID"].Value);

			EditRecipeForm editForm = new EditRecipeForm(recipeId);
			editForm.RecipeUpdated += EditForm_RecipeUpdated; // subscribe to event to refresh the main grid after edit
			editForm.ShowDialog();
		}

		private void EditForm_RecipeUpdated(object sender, EventArgs e)
		{
			LoadRecipes(); // re-fetch recipes to update the grid
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (dgvRecipes.SelectedRows.Count == 0)
			{
				MessageBox.Show("Please select at least one recipe to delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// Confirm deletion
			DialogResult result = MessageBox.Show($"Are you sure you want to delete {dgvRecipes.SelectedRows.Count} recipe(s)?",
												  "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result != DialogResult.Yes) return;

			// Delete each selected recipe
			foreach (DataGridViewRow row in dgvRecipes.SelectedRows)
			{
				int recipeId = Convert.ToInt32(row.Cells["RecipeID"].Value);
				DeleteRecipe(recipeId);  // Use the DeleteRecipe method from before
			}

			// Refresh DataGridView
			LoadRecipes();

			MessageBox.Show("Selected recipe(s) deleted successfully!");
		}

		private void DeleteRecipe(int recipeId)
		{

			using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
			{
				conn.Open();

				// --- Delete Ingredients first ---
				string queryIngredients = "DELETE FROM Ingredients WHERE RecipeID = @recipeId";
				using (SqlCommand cmd = new SqlCommand(queryIngredients, conn))
				{
					cmd.Parameters.AddWithValue("@recipeId", recipeId);
					cmd.ExecuteNonQuery();
				}

				// --- Delete Steps ---
				string querySteps = "DELETE FROM Steps WHERE RecipeID = @recipeId";
				using (SqlCommand cmd = new SqlCommand(querySteps, conn))
				{
					cmd.Parameters.AddWithValue("@recipeId", recipeId);
					cmd.ExecuteNonQuery();
				}

				// --- Delete the Recipe itself ---
				string queryRecipe = "DELETE FROM Recipes WHERE RecipeID = @recipeId";
				using (SqlCommand cmd = new SqlCommand(queryRecipe, conn))
				{
					cmd.Parameters.AddWithValue("@recipeId", recipeId);
					cmd.ExecuteNonQuery();
				}

				conn.Close();
			}
		}


		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			string selectedCategory = cboCategory.SelectedItem.ToString();
			LoadRecipes(selectedCategory);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			LoadRecipes();
		}

		
			private void LoadRecipes(string category = null, string keyword = null)
		{
			string query = "SELECT RecipeID, RecipeName FROM Recipes";
			List<string> conditions = new List<string>();
			SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString);
			using (SqlCommand cmd = new SqlCommand())
			{
				cmd.Connection = conn;

				if (!string.IsNullOrEmpty(category))
				{
					if (category.Equals("All")){
						cmd.Parameters.AddWithValue("@category", "*");
					} else { 
						conditions.Add("Category = @category");
					cmd.Parameters.AddWithValue("@category", category);

					}
				}

				if (!string.IsNullOrEmpty(keyword))
				{
					conditions.Add("RecipeName LIKE @keyword");
					cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
				}

				if (conditions.Count > 0)
				{
					query += " WHERE " + string.Join(" AND ", conditions);
				}

				cmd.CommandText = query;

				SqlDataAdapter adapter = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				adapter.Fill(dt);

				dgvRecipes.DataSource = dt;

				if (dgvRecipes.Columns.Contains("RecipeID"))
					dgvRecipes.Columns["RecipeID"].Visible = false;

				if (dgvRecipes.Columns.Contains("RecipeName"))
					dgvRecipes.Columns["RecipeName"].HeaderText = "Recipe Name";
			}
		}

		
		private void LoadIngredients(int recipeId)
		{
			SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString);
			{
				string query = "SELECT IngredientName, Quantity,Cost FROM Ingredients WHERE RecipeID=@recipeId";
				SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
				adapter.SelectCommand.Parameters.AddWithValue("@recipeId", recipeId);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				dgvIngredients.DataSource = dt;
				dgvIngredients.Columns["IngredientName"].HeaderText = "Ingredient";
			}
		}
			

		private void dgvSteps_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void LoadSteps(int recipeId)
		{
			SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString);
			{
				string query = "SELECT StepNumber, Description FROM Steps WHERE RecipeID=@recipeId ORDER BY StepNumber";
				SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
				adapter.SelectCommand.Parameters.AddWithValue("@recipeId", recipeId);
				DataTable dt = new DataTable();
				adapter.Fill(dt);
				dgvSteps.DataSource = dt;
				dgvSteps.Columns[0].Width = 50;
				dgvSteps.Columns["StepNumber"].HeaderText = "Step";
			}
		}

		private void dgvRecipes_SelectionChanged_1(object sender, EventArgs e)
		{
			if (dgvRecipes.SelectedRows.Count > 0)
			{
				int recipeId = Convert.ToInt32(dgvRecipes.SelectedRows[0].Cells["RecipeID"].Value);
				LoadIngredients(recipeId);
				LoadSteps(recipeId);
				decimal totalCost = GetTotalCost(recipeId);

				lblTotalCost.Text = $"Total Cost: {totalCost:C2}";  //display total cost

				LoadRecipeImage(recipeId);  //Load image
				
			}
			else
			{
				dgvIngredients.DataSource = null; // Clears the grid
				dgvSteps.DataSource = null;
			}
		}

		private decimal GetTotalCost(int recipeId)
		{
			decimal total = 0;
			string connectionString = DatabaseConfig.ConnectionString;

			using (SqlConnection conn = new SqlConnection(connectionString))
			{
				string query = "SELECT SUM(Cost) FROM Ingredients WHERE RecipeID = @recipeId";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@recipeId", recipeId);
					conn.Open();

					object result = cmd.ExecuteScalar();
					if (result != DBNull.Value)
						total = Convert.ToDecimal(result);

					conn.Close();
				}
			}

			return total;
		}

		private void LoadRecipeImage(int recipeId)
		{
			using (SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString))
			{
				string query = "SELECT Image FROM Recipes WHERE RecipeID = @recipeId";
				using (SqlCommand cmd = new SqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@recipeId", recipeId);
					conn.Open();

					object result = cmd.ExecuteScalar();
					conn.Close();

					if (result != DBNull.Value && result != null)
					{
						
						byte[] imgBytes = (byte[])result;
						using (MemoryStream ms = new MemoryStream(imgBytes))
						{
							pbRecipeImage.Image = Image.FromStream(ms);
							lblDragDropHint.Visible = false;  // hide ''Drag and drop a picture here'' text

						}
					}
					else
					{
						pbRecipeImage.Image = null; // no image stored
						lblDragDropHint.Visible = true;
					}
				}
			}
		}


		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			LoadRecipes(null,txtSearch.Text);
			lblSearchHint.Visible = false;

			if(string.IsNullOrEmpty(txtSearch.Text)) lblSearchHint.Visible = true;
		}

		private void pbRecipeImage_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
				if (files.Length > 0)
				{
					string ext = Path.GetExtension(files[0]).ToLower();
					if (ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp")
					{
						e.Effect = DragDropEffects.Copy; // valid image
					}
					else
					{
						e.Effect = DragDropEffects.None; // invalid file type
					}
				}
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		private void pbRecipeImage_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			if (files.Length > 0)
			{
				pbRecipeImage.Image = Image.FromFile(files[0]);
				pbRecipeImage.Tag = files[0]; // store file path temporarily

				SaveRecipeImage();
			}
		}

		private void SaveRecipeImage()
{
    if (dgvRecipes.CurrentRow == null)
    {
        MessageBox.Show("Please select a recipe first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }

    if (pbRecipeImage.Image == null)
    {
        MessageBox.Show("No image to save.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        return;
    }

    int recipeId = Convert.ToInt32(dgvRecipes.CurrentRow.Cells["RecipeID"].Value);

    // Convert image to byte array
    byte[] imgBytes = null;
    using (MemoryStream ms = new MemoryStream())
    {
        pbRecipeImage.Image.Save(ms, pbRecipeImage.Image.RawFormat);
        imgBytes = ms.ToArray();
    }

    // Update database
    string connectionString = DatabaseConfig.ConnectionString;
    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        string query = "UPDATE Recipes SET Image = @image WHERE RecipeID = @recipeId";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@image", imgBytes);
            cmd.Parameters.AddWithValue("@recipeId", recipeId);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }

    MessageBox.Show("Image saved successfully for the selected recipe!");
}

		private void MainForm_Load(object sender, EventArgs e)
		{

		}
	}
}
