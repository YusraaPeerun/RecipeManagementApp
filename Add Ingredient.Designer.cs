namespace Recipe_management_app
{
	partial class AddIngredientForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dgvIngredients = new System.Windows.Forms.DataGridView();
			this.IngredientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnSave = new System.Windows.Forms.Button();
			this.dgvSteps = new System.Windows.Forms.DataGridView();
			this.StepNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Cost = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvIngredients
			// 
			this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIngredients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IngredientName,
            this.Quantity});
			this.dgvIngredients.Location = new System.Drawing.Point(12, 22);
			this.dgvIngredients.Name = "dgvIngredients";
			this.dgvIngredients.RowHeadersWidth = 62;
			this.dgvIngredients.RowTemplate.Height = 28;
			this.dgvIngredients.Size = new System.Drawing.Size(369, 335);
			this.dgvIngredients.TabIndex = 0;
			// 
			// IngredientName
			// 
			this.IngredientName.HeaderText = "Ingredient Name";
			this.IngredientName.MinimumWidth = 8;
			this.IngredientName.Name = "IngredientName";
			this.IngredientName.Width = 150;
			// 
			// Quantity
			// 
			this.Quantity.HeaderText = "Quantity";
			this.Quantity.MinimumWidth = 8;
			this.Quantity.Name = "Quantity";
			this.Quantity.Width = 150;
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(458, 404);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(114, 34);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// dgvSteps
			// 
			this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StepNumber,
            this.Cost,
            this.Description});
			this.dgvSteps.Location = new System.Drawing.Point(419, 22);
			this.dgvSteps.Name = "dgvSteps";
			this.dgvSteps.RowHeadersWidth = 62;
			this.dgvSteps.RowTemplate.Height = 28;
			this.dgvSteps.Size = new System.Drawing.Size(369, 335);
			this.dgvSteps.TabIndex = 2;
			// 
			// StepNumber
			// 
			this.StepNumber.HeaderText = "Number";
			this.StepNumber.MinimumWidth = 8;
			this.StepNumber.Name = "StepNumber";
			this.StepNumber.ReadOnly = true;
			this.StepNumber.Width = 150;
			// 
			// Cost
			// 
			this.Cost.HeaderText = "Cost";
			this.Cost.MinimumWidth = 8;
			this.Cost.Name = "Cost";
			this.Cost.Width = 150;
			// 
			// Description
			// 
			this.Description.HeaderText = "Description";
			this.Description.MinimumWidth = 8;
			this.Description.Name = "Description";
			this.Description.Width = 150;
			// 
			// AddIngredientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.dgvSteps);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.dgvIngredients);
			this.Name = "AddIngredientForm";
			this.Text = "Add Ingredient and Steps";
			this.Load += new System.EventHandler(this.Add_Ingredient_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvIngredients;
		private System.Windows.Forms.DataGridViewTextBoxColumn IngredientName;
		private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.DataGridView dgvSteps;
		private System.Windows.Forms.DataGridViewTextBoxColumn StepNumber;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cost;
		private System.Windows.Forms.DataGridViewTextBoxColumn Description;
	}
}