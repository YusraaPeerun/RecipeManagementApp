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
	public partial class AddIngredientForm : Form
	{
		private int recipeId;

		public AddIngredientForm(int recipeId)
		{
			InitializeComponent();
			this.recipeId = recipeId;
		}

		private void Add_Ingredient_Load(object sender, EventArgs e)
		{
			{
				// --- Ingredients DataGridView ---
				dgvIngredients.Columns.Clear();
				dgvIngredients.Columns.Add("IngredientName", "Ingredient Name");
				dgvIngredients.Columns.Add("Quantity", "Quantity");
				dgvIngredients.Columns.Add("Cost", "Cost");
				dgvIngredients.AllowUserToAddRows = true;

				// --- Steps DataGridView ---
				dgvSteps.Columns.Clear();
				dgvSteps.Columns.Add("StepNumber", "Step No");
				dgvSteps.Columns.Add("Description", "Step Description");

				dgvSteps.AllowUserToAddRows = true;
				dgvSteps.EditMode = DataGridViewEditMode.EditOnEnter;
				dgvSteps.Columns["StepNumber"].ReadOnly = true;

				// Fill StepNumber for existing rows (if any)
				dgvSteps.RowsAdded += DgvSteps_RowsAdded;
				dgvSteps.RowsRemoved += DgvSteps_RowsRemoved;
			}

		}

		private void DgvSteps_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
		{
			UpdateStepNumbers();
		}

		private void DgvSteps_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
		{
			UpdateStepNumbers();
		}

		private void UpdateStepNumbers()
		{
			int step = 1;
			foreach (DataGridViewRow row in dgvSteps.Rows)
			{
				if (row.IsNewRow) continue;
				row.Cells["StepNumber"].Value = step;
				step++;
			}
		}


		private void AddRecipeForm_Load(object sender, EventArgs e)
		{
			dgvIngredients.Columns.Clear();
			dgvIngredients.Columns.Add("IngredientName", "Ingredient Name");
			dgvIngredients.Columns.Add("Quantity", "Quantity");

			dgvIngredients.AllowUserToAddRows = true;  // lets user add rows
			dgvIngredients.EditMode = DataGridViewEditMode.EditOnEnter;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			SqlConnection conn = new SqlConnection(DatabaseConfig.ConnectionString);
			{
				conn.Open();


				//Add ingredients in DB
				foreach (DataGridViewRow row in dgvIngredients.Rows)
				{
					if (row.IsNewRow) continue; // skip the blank row

					string name = row.Cells["IngredientName"].Value?.ToString();
					string qty = row.Cells["Quantity"].Value?.ToString();
					string costText = row.Cells["Cost"].Value?.ToString();

					decimal cost = 0;
					if (!string.IsNullOrWhiteSpace(costText))
						decimal.TryParse(costText, out cost);

					// Validation: check if Name or Quantity is empty
					if (string.IsNullOrWhiteSpace(qty))
					{
						MessageBox.Show($"Quantity is required for ingredient '{name}'", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvIngredients.CurrentCell = row.Cells["Quantity"]; // focus on Quantity cell
						return; // stop saving
					}
					else if (string.IsNullOrWhiteSpace(name))
					{
						MessageBox.Show($"Name is required for quantity '{qty}'", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						dgvIngredients.CurrentCell = row.Cells["IngredientName"]; // focus on Name cell
						return;
					}


					string queryIngredient = "INSERT INTO Ingredients (RecipeID, IngredientName, Quantity, Cost) VALUES (@recipeId, @name, @qty, @cost)";
					SqlCommand cmdIngredient = new SqlCommand(queryIngredient, conn);
					cmdIngredient.Parameters.AddWithValue("@recipeId", recipeId);
					cmdIngredient.Parameters.AddWithValue("@name", name);
					cmdIngredient.Parameters.AddWithValue("@qty", qty);
					cmdIngredient.Parameters.AddWithValue("@cost", cost);
					cmdIngredient.ExecuteNonQuery();
				}

				//Add ingredients in Steps
				foreach (DataGridViewRow row in dgvSteps.Rows)
				{
					if (row.IsNewRow) continue;

					string desc = row.Cells["Description"].Value?.ToString();
					int stepNumber = Convert.ToInt32(row.Cells["StepNumber"].Value);

					if (string.IsNullOrWhiteSpace(desc))
					{
						MessageBox.Show("Step description cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}

					string querySteps = "INSERT INTO Steps (RecipeID, StepNumber, Description) VALUES (@recipeId, @stepNumber, @desc)";
					using (SqlCommand cmdSteps = new SqlCommand(querySteps, conn))
					{
						cmdSteps.Parameters.AddWithValue("@recipeId", recipeId);
						cmdSteps.Parameters.AddWithValue("@stepNumber", stepNumber);
						cmdSteps.Parameters.AddWithValue("@desc", desc);
						cmdSteps.ExecuteNonQuery();
					}

				}

				conn.Close();
				MessageBox.Show("Ingredients and Steps added successfully!");
				this.DialogResult = DialogResult.OK;
				this.Close();
			}

		}

	}
}

