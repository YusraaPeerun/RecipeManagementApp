namespace Recipe_management_app
{
	partial class MainForm
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
			this.dgvRecipes = new System.Windows.Forms.DataGridView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.dgvIngredients = new System.Windows.Forms.DataGridView();
			this.dgvSteps = new System.Windows.Forms.DataGridView();
			this.lblTotalCost = new System.Windows.Forms.Label();
			this.pbRecipeImage = new System.Windows.Forms.PictureBox();
			this.lblDragDropHint = new System.Windows.Forms.Label();
			this.lblSearchHint = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbRecipeImage)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvRecipes
			// 
			this.dgvRecipes.AllowUserToAddRows = false;
			this.dgvRecipes.AllowUserToDeleteRows = false;
			this.dgvRecipes.AllowUserToResizeColumns = false;
			this.dgvRecipes.AllowUserToResizeRows = false;
			this.dgvRecipes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvRecipes.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvRecipes.Location = new System.Drawing.Point(11, 43);
			this.dgvRecipes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dgvRecipes.Name = "dgvRecipes";
			this.dgvRecipes.ReadOnly = true;
			this.dgvRecipes.RowHeadersVisible = false;
			this.dgvRecipes.RowHeadersWidth = 62;
			this.dgvRecipes.RowTemplate.Height = 28;
			this.dgvRecipes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvRecipes.Size = new System.Drawing.Size(172, 266);
			this.dgvRecipes.TabIndex = 0;
			this.dgvRecipes.SelectionChanged += new System.EventHandler(this.dgvRecipes_SelectionChanged_1);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(211, 7);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(85, 29);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add Recipe";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(314, 7);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(85, 29);
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit Recipe";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(417, 7);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(85, 29);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete Recipe";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(8, 14);
			this.txtSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(71, 20);
			this.txtSearch.TabIndex = 5;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			// 
			// cboCategory
			// 
			this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.Items.AddRange(new object[] {
            "All",
            "Appetizer",
            "Main Course",
            "Dessert",
            "Snack"});
			this.cboCategory.Location = new System.Drawing.Point(97, 13);
			this.cboCategory.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(83, 21);
			this.cboCategory.TabIndex = 6;
			this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// dgvIngredients
			// 
			this.dgvIngredients.AllowUserToAddRows = false;
			this.dgvIngredients.AllowUserToDeleteRows = false;
			this.dgvIngredients.AllowUserToResizeColumns = false;
			this.dgvIngredients.AllowUserToResizeRows = false;
			this.dgvIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvIngredients.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIngredients.Location = new System.Drawing.Point(11, 352);
			this.dgvIngredients.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dgvIngredients.Name = "dgvIngredients";
			this.dgvIngredients.ReadOnly = true;
			this.dgvIngredients.RowHeadersVisible = false;
			this.dgvIngredients.RowHeadersWidth = 62;
			this.dgvIngredients.RowTemplate.Height = 28;
			this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvIngredients.Size = new System.Drawing.Size(347, 169);
			this.dgvIngredients.TabIndex = 7;
			// 
			// dgvSteps
			// 
			this.dgvSteps.AllowUserToAddRows = false;
			this.dgvSteps.AllowUserToDeleteRows = false;
			this.dgvSteps.AllowUserToResizeColumns = false;
			this.dgvSteps.AllowUserToResizeRows = false;
			this.dgvSteps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSteps.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
			this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSteps.Location = new System.Drawing.Point(391, 352);
			this.dgvSteps.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.dgvSteps.Name = "dgvSteps";
			this.dgvSteps.ReadOnly = true;
			this.dgvSteps.RowHeadersVisible = false;
			this.dgvSteps.RowHeadersWidth = 62;
			this.dgvSteps.RowTemplate.Height = 28;
			this.dgvSteps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSteps.Size = new System.Drawing.Size(322, 169);
			this.dgvSteps.TabIndex = 8;
			this.dgvSteps.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSteps_CellContentClick);
			// 
			// lblTotalCost
			// 
			this.lblTotalCost.AutoSize = true;
			this.lblTotalCost.Location = new System.Drawing.Point(652, 324);
			this.lblTotalCost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblTotalCost.Name = "lblTotalCost";
			this.lblTotalCost.Size = new System.Drawing.Size(54, 13);
			this.lblTotalCost.TabIndex = 10;
			this.lblTotalCost.Text = "Total cost";
			// 
			// pbRecipeImage
			// 
			this.pbRecipeImage.Location = new System.Drawing.Point(314, 51);
			this.pbRecipeImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.pbRecipeImage.Name = "pbRecipeImage";
			this.pbRecipeImage.Size = new System.Drawing.Size(289, 233);
			this.pbRecipeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbRecipeImage.TabIndex = 11;
			this.pbRecipeImage.TabStop = false;
			// 
			// lblDragDropHint
			// 
			this.lblDragDropHint.AutoSize = true;
			this.lblDragDropHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDragDropHint.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblDragDropHint.Location = new System.Drawing.Point(380, 151);
			this.lblDragDropHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDragDropHint.Name = "lblDragDropHint";
			this.lblDragDropHint.Size = new System.Drawing.Size(160, 15);
			this.lblDragDropHint.TabIndex = 12;
			this.lblDragDropHint.Text = "Drag and drop a picture here";
			this.lblDragDropHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSearchHint
			// 
			this.lblSearchHint.AutoSize = true;
			this.lblSearchHint.BackColor = System.Drawing.Color.White;
			this.lblSearchHint.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblSearchHint.Location = new System.Drawing.Point(16, 16);
			this.lblSearchHint.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.lblSearchHint.Name = "lblSearchHint";
			this.lblSearchHint.Size = new System.Drawing.Size(41, 13);
			this.lblSearchHint.TabIndex = 13;
			this.lblSearchHint.Text = "Search";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.AutoSize = true;
			this.BackColor = System.Drawing.Color.PeachPuff;
			this.ClientSize = new System.Drawing.Size(744, 552);
			this.Controls.Add(this.lblSearchHint);
			this.Controls.Add(this.lblDragDropHint);
			this.Controls.Add(this.pbRecipeImage);
			this.Controls.Add(this.lblTotalCost);
			this.Controls.Add(this.dgvSteps);
			this.Controls.Add(this.dgvIngredients);
			this.Controls.Add(this.cboCategory);
			this.Controls.Add(this.txtSearch);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.dgvRecipes);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "MainForm";
			this.Text = "Recipe and Price management";
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbRecipeImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvRecipes;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.DataGridView dgvIngredients;
		private System.Windows.Forms.DataGridView dgvSteps;
		private System.Windows.Forms.Label lblTotalCost;
		private System.Windows.Forms.PictureBox pbRecipeImage;
		private System.Windows.Forms.Label lblDragDropHint;
		private System.Windows.Forms.Label lblSearchHint;
	}
}

