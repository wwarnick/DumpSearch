namespace DumpSearch
{
	partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.txtTableName = new System.Windows.Forms.TextBox();
			this.txtKeyColumn = new System.Windows.Forms.TextBox();
			this.txtKeyValue = new System.Windows.Forms.TextBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lblTableName = new System.Windows.Forms.Label();
			this.lblKeyColumn = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblKeyValue = new System.Windows.Forms.Label();
			this.txtShowColumn = new System.Windows.Forms.TextBox();
			this.lblShowColumn = new System.Windows.Forms.Label();
			this.lblPath = new System.Windows.Forms.Label();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.dlgBrowse = new System.Windows.Forms.OpenFileDialog();
			this.gdvData = new System.Windows.Forms.DataGridView();
			this.lblSortBy = new System.Windows.Forms.Label();
			this.txtSortBy = new System.Windows.Forms.TextBox();
			this.rdoAscending = new System.Windows.Forms.RadioButton();
			this.rdoDescending = new System.Windows.Forms.RadioButton();
			this.txtInsert = new System.Windows.Forms.TextBox();
			this.lblInsert = new System.Windows.Forms.Label();
			this.ttpTooltip = new System.Windows.Forms.ToolTip(this.components);
			((System.ComponentModel.ISupportInitialize)(this.gdvData)).BeginInit();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(87, 12);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(265, 20);
			this.txtPath.TabIndex = 0;
			this.ttpTooltip.SetToolTip(this.txtPath, "The path of the file to query.");
			// 
			// txtTableName
			// 
			this.txtTableName.Location = new System.Drawing.Point(87, 38);
			this.txtTableName.Name = "txtTableName";
			this.txtTableName.Size = new System.Drawing.Size(293, 20);
			this.txtTableName.TabIndex = 2;
			this.ttpTooltip.SetToolTip(this.txtTableName, "The name of the table to query (ex. \'cases\' w/o quotes).");
			// 
			// txtKeyColumn
			// 
			this.txtKeyColumn.Location = new System.Drawing.Point(87, 64);
			this.txtKeyColumn.Name = "txtKeyColumn";
			this.txtKeyColumn.Size = new System.Drawing.Size(293, 20);
			this.txtKeyColumn.TabIndex = 3;
			this.ttpTooltip.SetToolTip(this.txtKeyColumn, "The key column to match to (ex. \'id\' w/o quotes).  Leave blank to return all reco" +
        "rds.");
			// 
			// txtKeyValue
			// 
			this.txtKeyValue.Location = new System.Drawing.Point(87, 90);
			this.txtKeyValue.Name = "txtKeyValue";
			this.txtKeyValue.Size = new System.Drawing.Size(293, 20);
			this.txtKeyValue.TabIndex = 4;
			this.ttpTooltip.SetToolTip(this.txtKeyValue, "The value to search for in the key column.");
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(305, 174);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 9;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lblTableName
			// 
			this.lblTableName.AutoSize = true;
			this.lblTableName.Location = new System.Drawing.Point(20, 41);
			this.lblTableName.Name = "lblTableName";
			this.lblTableName.Size = new System.Drawing.Size(65, 13);
			this.lblTableName.TabIndex = 6;
			this.lblTableName.Text = "Table Name";
			// 
			// lblKeyColumn
			// 
			this.lblKeyColumn.AutoSize = true;
			this.lblKeyColumn.Location = new System.Drawing.Point(22, 67);
			this.lblKeyColumn.Name = "lblKeyColumn";
			this.lblKeyColumn.Size = new System.Drawing.Size(63, 13);
			this.lblKeyColumn.TabIndex = 7;
			this.lblKeyColumn.Text = "Key Column";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(50, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 13);
			this.label3.TabIndex = 8;
			// 
			// lblKeyValue
			// 
			this.lblKeyValue.AutoSize = true;
			this.lblKeyValue.Location = new System.Drawing.Point(30, 93);
			this.lblKeyValue.Name = "lblKeyValue";
			this.lblKeyValue.Size = new System.Drawing.Size(55, 13);
			this.lblKeyValue.TabIndex = 9;
			this.lblKeyValue.Text = "Key Value";
			// 
			// txtShowColumn
			// 
			this.txtShowColumn.Location = new System.Drawing.Point(87, 116);
			this.txtShowColumn.Name = "txtShowColumn";
			this.txtShowColumn.Size = new System.Drawing.Size(293, 20);
			this.txtShowColumn.TabIndex = 5;
			this.ttpTooltip.SetToolTip(this.txtShowColumn, "A comma-delimited list of columns to show.  Leave blank to show all columns.");
			// 
			// lblShowColumn
			// 
			this.lblShowColumn.AutoSize = true;
			this.lblShowColumn.Location = new System.Drawing.Point(2, 119);
			this.lblShowColumn.Name = "lblShowColumn";
			this.lblShowColumn.Size = new System.Drawing.Size(83, 13);
			this.lblShowColumn.TabIndex = 10;
			this.lblShowColumn.Text = "Show Column(s)";
			this.lblShowColumn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPath
			// 
			this.lblPath.AutoSize = true;
			this.lblPath.Location = new System.Drawing.Point(37, 15);
			this.lblPath.Name = "lblPath";
			this.lblPath.Size = new System.Drawing.Size(48, 13);
			this.lblPath.TabIndex = 11;
			this.lblPath.Text = "File Path";
			// 
			// lblSeparator
			// 
			this.lblSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblSeparator.Location = new System.Drawing.Point(12, 209);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(368, 2);
			this.lblSeparator.TabIndex = 12;
			this.lblSeparator.Text = "label7";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(358, 12);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(22, 20);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// dlgBrowse
			// 
			this.dlgBrowse.FileName = "openFileDialog1";
			this.dlgBrowse.Filter = "SQL Files|*.sql";
			this.dlgBrowse.Title = "Choose Backup SQL File";
			// 
			// gdvData
			// 
			this.gdvData.AllowUserToAddRows = false;
			this.gdvData.AllowUserToDeleteRows = false;
			this.gdvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.gdvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.gdvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.gdvData.DefaultCellStyle = dataGridViewCellStyle8;
			this.gdvData.Location = new System.Drawing.Point(12, 249);
			this.gdvData.Name = "gdvData";
			this.gdvData.ReadOnly = true;
			this.gdvData.Size = new System.Drawing.Size(368, 105);
			this.gdvData.TabIndex = 10;
			// 
			// lblSortBy
			// 
			this.lblSortBy.AutoSize = true;
			this.lblSortBy.Location = new System.Drawing.Point(45, 145);
			this.lblSortBy.Name = "lblSortBy";
			this.lblSortBy.Size = new System.Drawing.Size(40, 13);
			this.lblSortBy.TabIndex = 14;
			this.lblSortBy.Text = "Sort by";
			this.lblSortBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSortBy
			// 
			this.txtSortBy.Location = new System.Drawing.Point(87, 142);
			this.txtSortBy.Name = "txtSortBy";
			this.txtSortBy.Size = new System.Drawing.Size(128, 20);
			this.txtSortBy.TabIndex = 6;
			this.ttpTooltip.SetToolTip(this.txtSortBy, "A comma-delimited list of columns to sort by.  Leave blank to ignore sorting.");
			// 
			// rdoAscending
			// 
			this.rdoAscending.AutoSize = true;
			this.rdoAscending.Checked = true;
			this.rdoAscending.Location = new System.Drawing.Point(221, 143);
			this.rdoAscending.Name = "rdoAscending";
			this.rdoAscending.Size = new System.Drawing.Size(75, 17);
			this.rdoAscending.TabIndex = 7;
			this.rdoAscending.TabStop = true;
			this.rdoAscending.Text = "Ascending";
			this.rdoAscending.UseVisualStyleBackColor = true;
			// 
			// rdoDescending
			// 
			this.rdoDescending.AutoSize = true;
			this.rdoDescending.Location = new System.Drawing.Point(302, 143);
			this.rdoDescending.Name = "rdoDescending";
			this.rdoDescending.Size = new System.Drawing.Size(82, 17);
			this.rdoDescending.TabIndex = 8;
			this.rdoDescending.Text = "Descending";
			this.rdoDescending.UseVisualStyleBackColor = true;
			// 
			// txtInsert
			// 
			this.txtInsert.Location = new System.Drawing.Point(87, 223);
			this.txtInsert.Name = "txtInsert";
			this.txtInsert.ReadOnly = true;
			this.txtInsert.Size = new System.Drawing.Size(293, 20);
			this.txtInsert.TabIndex = 15;
			this.ttpTooltip.SetToolTip(this.txtInsert, "An INSERT statement in SQL for the records found, using the displayed columns.");
			// 
			// lblInsert
			// 
			this.lblInsert.AutoSize = true;
			this.lblInsert.Location = new System.Drawing.Point(25, 226);
			this.lblInsert.Name = "lblInsert";
			this.lblInsert.Size = new System.Drawing.Size(60, 13);
			this.lblInsert.TabIndex = 16;
			this.lblInsert.Text = "Insert SQL:";
			// 
			// ttpTooltip
			// 
			this.ttpTooltip.AutoPopDelay = 10000;
			this.ttpTooltip.InitialDelay = 500;
			this.ttpTooltip.ReshowDelay = 100;
			// 
			// frmMain
			// 
			this.AcceptButton = this.btnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 366);
			this.Controls.Add(this.lblInsert);
			this.Controls.Add(this.txtInsert);
			this.Controls.Add(this.rdoDescending);
			this.Controls.Add(this.rdoAscending);
			this.Controls.Add(this.lblSortBy);
			this.Controls.Add(this.txtSortBy);
			this.Controls.Add(this.gdvData);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.lblSeparator);
			this.Controls.Add(this.lblPath);
			this.Controls.Add(this.lblShowColumn);
			this.Controls.Add(this.txtShowColumn);
			this.Controls.Add(this.lblKeyValue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.lblKeyColumn);
			this.Controls.Add(this.lblTableName);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.txtKeyValue);
			this.Controls.Add(this.txtKeyColumn);
			this.Controls.Add(this.txtTableName);
			this.Controls.Add(this.txtPath);
			this.MinimumSize = new System.Drawing.Size(400, 393);
			this.Name = "frmMain";
			this.Text = "Backup Search 1.0.2";
			this.Load += new System.EventHandler(this.frmMain_Load);
			((System.ComponentModel.ISupportInitialize)(this.gdvData)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.TextBox txtTableName;
		private System.Windows.Forms.TextBox txtKeyColumn;
		private System.Windows.Forms.TextBox txtKeyValue;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblTableName;
		private System.Windows.Forms.Label lblKeyColumn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblKeyValue;
		private System.Windows.Forms.TextBox txtShowColumn;
		private System.Windows.Forms.Label lblShowColumn;
		private System.Windows.Forms.Label lblPath;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.OpenFileDialog dlgBrowse;
		private System.Windows.Forms.DataGridView gdvData;
		private System.Windows.Forms.Label lblSortBy;
		private System.Windows.Forms.TextBox txtSortBy;
		private System.Windows.Forms.RadioButton rdoAscending;
		private System.Windows.Forms.RadioButton rdoDescending;
		private System.Windows.Forms.TextBox txtInsert;
		private System.Windows.Forms.Label lblInsert;
		private System.Windows.Forms.ToolTip ttpTooltip;
	}
}

