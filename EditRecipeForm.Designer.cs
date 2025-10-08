namespace Recipe_management_app
{
	partial class EditRecipeForm
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
			this.btnSave = new System.Windows.Forms.Button();
			this.txtRecipeName = new System.Windows.Forms.TextBox();
			this.dgvIngredients = new System.Windows.Forms.DataGridView();
			this.dgvSteps = new System.Windows.Forms.DataGridView();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.txtInstructions = new System.Windows.Forms.TextBox();
			this.lblDragDropHint = new System.Windows.Forms.Label();
			this.pbRecipeImage = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbRecipeImage)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(465, 487);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(71, 22);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// txtRecipeName
			// 
			this.txtRecipeName.Location = new System.Drawing.Point(6, 12);
			this.txtRecipeName.Name = "txtRecipeName";
			this.txtRecipeName.Size = new System.Drawing.Size(65, 20);
			this.txtRecipeName.TabIndex = 1;
			// 
			// dgvIngredients
			// 
			this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvIngredients.Location = new System.Drawing.Point(32, 255);
			this.dgvIngredients.Name = "dgvIngredients";
			this.dgvIngredients.Size = new System.Drawing.Size(239, 226);
			this.dgvIngredients.TabIndex = 2;
			// 
			// dgvSteps
			// 
			this.dgvSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSteps.Location = new System.Drawing.Point(297, 255);
			this.dgvSteps.Name = "dgvSteps";
			this.dgvSteps.Size = new System.Drawing.Size(239, 226);
			this.dgvSteps.TabIndex = 3;
			// 
			// cboCategory
			// 
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.Location = new System.Drawing.Point(98, 12);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(77, 21);
			this.cboCategory.TabIndex = 4;
			// 
			// txtInstructions
			// 
			this.txtInstructions.Location = new System.Drawing.Point(202, 12);
			this.txtInstructions.Multiline = true;
			this.txtInstructions.Name = "txtInstructions";
			this.txtInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtInstructions.Size = new System.Drawing.Size(87, 21);
			this.txtInstructions.TabIndex = 5;
			// 
			// lblDragDropHint
			// 
			this.lblDragDropHint.AutoSize = true;
			this.lblDragDropHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblDragDropHint.ForeColor = System.Drawing.SystemColors.GrayText;
			this.lblDragDropHint.Location = new System.Drawing.Point(217, 139);
			this.lblDragDropHint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.lblDragDropHint.Name = "lblDragDropHint";
			this.lblDragDropHint.Size = new System.Drawing.Size(160, 15);
			this.lblDragDropHint.TabIndex = 14;
			this.lblDragDropHint.Text = "Drag and drop a picture here";
			this.lblDragDropHint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pbRecipeImage
			// 
			this.pbRecipeImage.Location = new System.Drawing.Point(169, 51);
			this.pbRecipeImage.Margin = new System.Windows.Forms.Padding(2);
			this.pbRecipeImage.Name = "pbRecipeImage";
			this.pbRecipeImage.Size = new System.Drawing.Size(262, 199);
			this.pbRecipeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbRecipeImage.TabIndex = 13;
			this.pbRecipeImage.TabStop = false;
			// 
			// EditRecipeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoScroll = true;
			this.ClientSize = new System.Drawing.Size(649, 509);
			this.Controls.Add(this.lblDragDropHint);
			this.Controls.Add(this.pbRecipeImage);
			this.Controls.Add(this.txtInstructions);
			this.Controls.Add(this.cboCategory);
			this.Controls.Add(this.dgvSteps);
			this.Controls.Add(this.dgvIngredients);
			this.Controls.Add(this.txtRecipeName);
			this.Controls.Add(this.btnSave);
			this.Name = "EditRecipeForm";
			this.Text = "EditRecipeForm";
			this.Load += new System.EventHandler(this.EditRecipeForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSteps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbRecipeImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.TextBox txtRecipeName;
		private System.Windows.Forms.DataGridView dgvIngredients;
		private System.Windows.Forms.DataGridView dgvSteps;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.TextBox txtInstructions;
		private System.Windows.Forms.Label lblDragDropHint;
		private System.Windows.Forms.PictureBox pbRecipeImage;
	}
}