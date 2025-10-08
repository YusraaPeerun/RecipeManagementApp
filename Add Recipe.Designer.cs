namespace Recipe_management_app
{
	partial class AddRecipeForm
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
			this.txtRecipeName = new System.Windows.Forms.TextBox();
			this.txtInstructions = new System.Windows.Forms.TextBox();
			this.cboCategory = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtRecipeName
			// 
			this.txtRecipeName.Location = new System.Drawing.Point(123, 44);
			this.txtRecipeName.Name = "txtRecipeName";
			this.txtRecipeName.Size = new System.Drawing.Size(153, 26);
			this.txtRecipeName.TabIndex = 0;
			// 
			// txtInstructions
			// 
			this.txtInstructions.Location = new System.Drawing.Point(123, 105);
			this.txtInstructions.Name = "txtInstructions";
			this.txtInstructions.Size = new System.Drawing.Size(153, 26);
			this.txtInstructions.TabIndex = 1;
			// 
			// cboCategory
			// 
			this.cboCategory.FormattingEnabled = true;
			this.cboCategory.Items.AddRange(new object[] {
            "Appetizer",
            "Main Course",
            "Dessert",
            "Snack"});
			this.cboCategory.Location = new System.Drawing.Point(123, 179);
			this.cboCategory.Name = "cboCategory";
			this.cboCategory.Size = new System.Drawing.Size(153, 28);
			this.cboCategory.TabIndex = 2;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(174, 261);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(91, 36);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 50);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(105, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Recipe Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 111);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(84, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Instruction";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 182);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(73, 20);
			this.label3.TabIndex = 7;
			this.label3.Text = "Category";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(5, 261);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(91, 36);
			this.btnNext.TabIndex = 8;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// AddRecipeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 373);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.cboCategory);
			this.Controls.Add(this.txtInstructions);
			this.Controls.Add(this.txtRecipeName);
			this.Name = "AddRecipeForm";
			this.Text = "Add Recipe";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtRecipeName;
		private System.Windows.Forms.TextBox txtInstructions;
		private System.Windows.Forms.ComboBox cboCategory;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnNext;
	}
}