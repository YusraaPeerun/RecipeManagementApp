using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recipe_management_app
{
	public partial class AddRecipeForm : Form
	{

		MainForm mainform = new MainForm();
		public AddRecipeForm()
		{
			InitializeComponent();
		}

		private void Form2_Load(object sender, EventArgs e)
		{

		}

		private void dgvIngredients_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			string recipeName = txtRecipeName.Text.Trim();
			string instructions = txtInstructions.Text.Trim();
			string category = cboCategory.SelectedItem?.ToString();

			if (string.IsNullOrEmpty(recipeName) || string.IsNullOrEmpty(category))
			{
				MessageBox.Show("Please fill in Recipe Name and select a Category.");
				return;
			}

			// Check uniqueness
			if (!IsRecipeNameUnique(recipeName))
			{
				MessageBox.Show("Recipe Name already exists. Please enter a unique name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


			int newRecipeId;

			SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString);
			{
				string query = @"INSERT INTO Recipes (RecipeName, Instructions, Category, DateCreated)
                         VALUES (@name, @instructions, @category, @dateCreated);
                         SELECT SCOPE_IDENTITY();";

				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@name", recipeName);
				cmd.Parameters.AddWithValue("@instructions", instructions);
				cmd.Parameters.AddWithValue("@category", category);
				cmd.Parameters.AddWithValue("@dateCreated", DateTime.Now);

				conn.Open();
				newRecipeId = Convert.ToInt32(cmd.ExecuteScalar());
			}

			// Open AddIngredientForm and pass the new RecipeID
			AddIngredientForm ingredientForm = new AddIngredientForm(newRecipeId);
			ingredientForm.StartPosition = FormStartPosition.CenterParent;
			ingredientForm.ShowDialog();
			this.Close();
		}


		private bool IsRecipeNameUnique(string recipeName)
		{
			bool isUnique = false;
			SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString);
			{
				string query = "SELECT COUNT(*) FROM Recipes WHERE RecipeName = @name";
				SqlCommand cmd = new SqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@name", recipeName);

				conn.Open();
				int count = (int)cmd.ExecuteScalar();
				conn.Close();

				isUnique = count == 0;
			}

			return isUnique;
		}

	}
	}

