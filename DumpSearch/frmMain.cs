using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DumpSearch
{
	public partial class frmMain : Form
	{
		int diffBrowseLeft;
		int diffPathWidth;
		int diffTableNameWidth;
		int diffKeyColumnWidth;
		int diffKeyValueWidth;
		int diffShowColumnWidth;
		int diffSearchLeft;
		int diffSeparatorWidth;
		int diffInsertWidth;
		int diffDataWidth;
		int diffDataHeight;

		public frmMain()
		{
			InitializeComponent();

			diffBrowseLeft = this.Width - btnBrowse.Left;
			diffPathWidth = btnBrowse.Left - txtPath.Width;
			diffTableNameWidth = this.Width - txtTableName.Width;
			diffKeyColumnWidth = this.Width - txtKeyColumn.Width;
			diffKeyValueWidth = this.Width - txtKeyValue.Width;
			diffShowColumnWidth = this.Width - txtShowColumn.Width;
			diffSearchLeft = this.Width - btnSearch.Left;
			diffSeparatorWidth = this.Width - lblSeparator.Width;
			diffInsertWidth = this.Width - txtInsert.Width;
			diffDataWidth = this.Width - gdvData.Width;
			diffDataHeight = this.Height - gdvData.Height;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.Resize += frmMain_OnResize;
		}

		protected void frmMain_OnResize(object sender, EventArgs e)
		{
			btnBrowse.Left = this.Width - diffBrowseLeft;
			txtPath.Width = btnBrowse.Left - diffPathWidth;
			txtTableName.Width = this.Width - diffTableNameWidth;
			txtKeyColumn.Width = this.Width - diffKeyColumnWidth;
			txtKeyValue.Width = this.Width - diffKeyValueWidth;
			txtShowColumn.Width = this.Width - diffShowColumnWidth;
			btnSearch.Left = this.Width - diffSearchLeft;
			lblSeparator.Width = this.Width - diffSeparatorWidth;
			txtInsert.Width = this.Width - diffInsertWidth;
			gdvData.Width = this.Width - diffDataWidth;
			gdvData.Height = this.Height - diffDataHeight;
		}

		private enum ColDataType { BigInt, Int, VarChar, Text, Decimal, Double, Date, DateTime, TimeSpan, TinyInt, Bit }

		private void btnSearch_Click(object sender, EventArgs e)
		{
			string errorMessage = string.Empty;
			DataTable dt = new DataTable();
			List<string> showCols;
			bool allCols;
			StringBuilder insertSQL = new StringBuilder();

			if (string.IsNullOrWhiteSpace(txtShowColumn.Text))
			{
				allCols = true;
				showCols = new List<string>();
			}
			else
			{
				allCols = false;
				showCols = new List<string>(txtShowColumn.Text.Split(','));
				for (int j = 0; j < showCols.Count; j++)
				{
					showCols[j] = showCols[j].Trim(' ', '`');
					dt.Columns.Add("data" + j.ToString());
				}
			}

			btnSearch.Text = "Searching...";
			setEnableAll(false);

			TextReader reader = null;
			try
			{
				reader = new StreamReader(txtPath.Text);
				string line = null;
				bool found = false;
				bool startCounting = false; // if true then it is reading the table structure
				List<int> showColsI = allCols ? new List<int>() : new List<int>(showCols.Count);
				List<ColDataType> colDataType = new List<ColDataType>(showCols.Count);
				for (int j = 0; j < showCols.Count; j++)
				{
					showColsI.Add(-1);
					colDataType.Add(ColDataType.Int);
				}
				int showColsFound = 0;
				bool useKey = !string.IsNullOrEmpty(txtKeyColumn.Text);
				int keyColNum = -1;
				int i = 0;
				bool atLeastOne = false;

				while ((line = reader.ReadLine()) != null)
				{
					if (line.StartsWith("CREATE TABLE `" + txtTableName.Text + "` ("))
					{
						found = true;
						startCounting = true;
					}
					else if (startCounting)
					{
						// this only occurs once table structure is completely read
						// it should only happen if either some columns are missing or when showing all columns and finished reading
						if (!line.StartsWith("  `"))
						{
							List<string> notFound = new List<string>();

							if (useKey && keyColNum == -1)
								notFound.Add(txtKeyColumn.Text);

							if (showColsFound < showCols.Count)
							{
								for (int j = 0; j < showCols.Count; j++)
								{
									if (showColsI[j] == -1)
										notFound.Add(showCols[j]);
								}
							}

							if (notFound.Count == 0)
							{
								if (!allCols)
									errorMessage += "At least one column was found, but loop was not exited.";
							}
							else if (notFound.Count == 1)
							{
								errorMessage += "Column `" + notFound[0] + "` not found.";
							}
							else
							{
								StringBuilder buf = new StringBuilder();

								for (int j = 0; j < notFound.Count; j++)
								{
									buf.Append(((buf.Length == 0) ? "" : ((notFound.Count == 2) ? " " : ", ")) + ((notFound.Count > 1 && j == notFound.Count - 1) ? "and " : "") + "`" + notFound[j] + "`");
								}

								errorMessage += "Columns " + buf.ToString() + " not found.";
							}

							if (notFound.Count > 0 || !allCols)
							{
								found = true;
								break;
							}
							else
							{
								startCounting = false;
							}
						}
						else // if still reading table structure
						{
							if (allCols)
							{
								showCols.Add(line.Substring(3, line.IndexOf('`', 3) - 3));
								showColsI.Add(i);
								colDataType.Add(getDataType(line.Substring(showCols[showCols.Count - 1].Length + 5), ref errorMessage));
								dt.Columns.Add("data" + i.ToString());
								showColsFound++;
							}
							else
							{
								for (int j = 0; j < showCols.Count; j++)
								{
									if (line.StartsWith("  `" + showCols[j] + "` "))
									{
										showColsI[j] = i;
										colDataType[j] = getDataType(line.Substring(showCols[j].Length + 5), ref errorMessage);

										showColsFound++;
									}
								}
							}

							if (!string.IsNullOrEmpty(errorMessage))
								break;
						}

						if (useKey && line.StartsWith("  `" + txtKeyColumn.Text + "` "))
							keyColNum = i;

						if (showColsFound < showCols.Count || (useKey && keyColNum == -1) || allCols)
							i++;
						else
							startCounting = false;
					}
					else if (line.StartsWith("INSERT INTO `" + txtTableName.Text + "` VALUES "))
					{
						if (!found)
						{
							errorMessage += "Table was not created before insert statement.";
							found = true;
							break;
						}
						int start = line.IndexOf("(") + 1;
						string[] records = line.Substring(start, line.Length - start - 2).Split(new string[] { "),(" }, StringSplitOptions.None);
						string asString = "'" + txtKeyValue.Text + "'";
						int sort = -1;
						if (!string.IsNullOrEmpty(txtSortBy.Text))
						{
							string sortCol = txtSortBy.Text.Trim(' ', '`');
							for (int j = 0; j < showCols.Count; j++)
							{
								if (showCols[j] == sortCol)
								{
									sort = j;
									break;
								}
							}

							if (sort == -1)
								errorMessage += "Column `" + sortCol + "` not found.";
						}

						if (string.IsNullOrEmpty(errorMessage))
						{
							foreach (string record in records)
							{
								string[] fields = parseCSV(record);

								if (!useKey || fields[keyColNum] == txtKeyValue.Text || fields[keyColNum] == asString)
								{
									DataRow dr = dt.NewRow();

									StringBuilder insertVals = new StringBuilder();
									for (int j = 0; j < showCols.Count; j++)
									{
										dr["data" + j.ToString()] = fields[showColsI[j]];
										if (insertVals.Length > 0)
											insertVals.Append(',');
										if (fields[showColsI[j]] != "NULL"
											&& (colDataType[j] == ColDataType.Date
											|| colDataType[j] == ColDataType.DateTime
											|| colDataType[j] == ColDataType.TimeSpan
											|| colDataType[j] == ColDataType.VarChar
											|| colDataType[j] == ColDataType.Text))
										{
											insertVals.Append('\'');
											insertVals.Append(fields[showColsI[j]]);
											insertVals.Append('\'');
										}
										else
										{
											insertVals.Append(fields[showColsI[j]]);
										}
									}

									if (sort == -1)
										dt.Rows.Add(dr);
									else
										insertSortDT(dr, sort, dt, rdoAscending.Checked, colDataType[sort]);

									if (insertSQL.Length > 0)
										insertSQL.Append(',');
									insertSQL.Append('(');
									insertSQL.Append(insertVals);
									insertSQL.Append(')');
									atLeastOne = true;
								}
							}
						}
					}
					else if (found && line.StartsWith("CREATE "))
					{
						break;
					}
				}

				if (!found)
					errorMessage += "Table not found.";
				else if (!atLeastOne && string.IsNullOrWhiteSpace(errorMessage))
					errorMessage += "Record not found.";

			}
			catch (Exception ex)
			{
				errorMessage += ex.Message + "\n\n";
			}
			finally { if (reader != null) reader.Close(); }

			setEnableAll(true);
			btnSearch.Text = "Search";

			if (string.IsNullOrWhiteSpace(errorMessage))
			{
				gdvData.Columns.Clear();

				for (int j = 0; j < showCols.Count; j++)
				{
					System.Windows.Forms.DataGridViewTextBoxColumn col = new System.Windows.Forms.DataGridViewTextBoxColumn();
					col.DataPropertyName = "data" + j;
					col.HeaderText = showCols[j];
					col.Name = "data" + j;
					col.ReadOnly = true;
					col.Width = 200;

					this.gdvData.Columns.Add(col);
				}

				gdvData.DataSource = dt;

				if (insertSQL.Length > 0)
				{
					txtInsert.Text = "INSERT INTO `" + txtTableName.Text + "` (`" + string.Join("`,`", showCols) + "`) VALUES " + insertSQL.ToString() + ";";
				}
				else
				{
					txtInsert.Text = string.Empty;
				}
			}
			else
				MessageBox.Show(errorMessage, "Backup Search");
		}

		private void insertSortDT(DataRow dr, int sortCol, DataTable dt, bool ascending, ColDataType colDataType)
		{
			int count = dt.Rows.Count;
			string sortItem = (string)dr[sortCol];
			int lookFor = 0;
			int i = 0;
			int castInt = 0;
			double castDec = 0;
			DateTime castDat = new DateTime();

			switch (colDataType)
			{
				case ColDataType.VarChar:
				case ColDataType.Text:
					lookFor = ascending ? 1 : -1;
					break;
				case ColDataType.BigInt:
				case ColDataType.Int:
				case ColDataType.TinyInt:
				case ColDataType.Bit:
					if (!int.TryParse(sortItem, out castInt))
						throw new Exception("Invalid int cast: " + sortItem);
					break;
				case ColDataType.Decimal:
				case ColDataType.Double:
					if (!double.TryParse(sortItem, out castDec))
						throw new Exception("Invalid double cast: " + sortItem);
					break;
				case ColDataType.Date:
				case ColDataType.DateTime:
				case ColDataType.TimeSpan:
					if (!DateTime.TryParse(sortItem, out castDat))
						throw new Exception("Invalid DateTime cast: " + sortItem);
					break;
				default:
					throw new Exception("Unrecognized datatype: " + colDataType.ToString());
			}

			for (i = 0; i < count; i++)
			{
				bool doBreak = false;
				switch (colDataType)
				{
					case ColDataType.VarChar:
					case ColDataType.Text:
						doBreak = string.Compare(sortItem, (string)dt.Rows[i][sortCol], true) != lookFor;
						break;
					case ColDataType.BigInt:
					case ColDataType.Int:
					case ColDataType.TinyInt:
					case ColDataType.Bit:
						int tempInt = 0;
						if (!int.TryParse((string)dt.Rows[i][sortCol], out tempInt))
							throw new Exception("Invalid int cast: " + (string)dt.Rows[i][sortCol]);
						doBreak = !(ascending ? (castInt > tempInt) : (castInt < tempInt));
						break;
					case ColDataType.Decimal:
					case ColDataType.Double:
						double tempDouble = 0;
						if (!double.TryParse((string)dt.Rows[i][sortCol], out tempDouble))
							throw new Exception("Invalid double cast: " + (string)dt.Rows[i][sortCol]);
						doBreak = !(ascending ? (castDec > tempDouble) : (castDec < tempDouble));
						break;
					case ColDataType.Date:
					case ColDataType.DateTime:
					case ColDataType.TimeSpan:
						DateTime tempDat = new DateTime();
						if (!DateTime.TryParse((string)dt.Rows[i][sortCol], out tempDat))
							throw new Exception("Invalid DateTime cast: " + (string)dt.Rows[i][sortCol]);
						doBreak = !(ascending ? (castDat > tempDat) : (castDat < tempDat));
						break;
					default:
						throw new Exception("Unrecognized datatype: " + colDataType.ToString());
				}

				if (doBreak)
					break;
			}

			dt.Rows.InsertAt(dr, i);
		}

		private ColDataType getDataType(string dt, ref string errorMessage)
		{
			string test = dt.ToUpper();

			return test.StartsWith("BIGINT") ? ColDataType.BigInt
				: test.StartsWith("VARCHAR") ? ColDataType.VarChar
				: test.StartsWith("TEXT") ? ColDataType.Text
				: test.StartsWith("INT") ? ColDataType.Int
				: test.StartsWith("DECIMAL") ? ColDataType.Decimal
				: test.StartsWith("DOUBLE") ? ColDataType.Double
				: test.StartsWith("DATETIME") ? ColDataType.DateTime
				: test.StartsWith("DATE") ? ColDataType.Date
				: test.StartsWith("TIMESTAMP") ? ColDataType.TimeSpan
				: test.StartsWith("TINYINT") ? ColDataType.TinyInt
				: ColDataType.Bit;
		}

		private void setEnableAll(bool enable)
		{
			txtPath.Enabled = enable;
			txtTableName.Enabled = enable;
			txtKeyColumn.Enabled = enable;
			txtKeyValue.Enabled = enable;
			txtShowColumn.Enabled = enable;
			btnSearch.Enabled = enable;
			gdvData.Enabled = enable;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			if (dlgBrowse.ShowDialog().ToString().Equals("OK"))
				txtPath.Text = dlgBrowse.FileName;
		}

		private string[] parseCSV(string str)
		{
			string[] result = null;
			int pos = 0;

			List<string> buf = new List<string>();
			while (pos < str.Length)
			{
				if (str[pos] == '\'')
				{
					int index = str.IndexOf("\',", pos + 1);
					if (index == -1)
					{
						buf.Add(str.Substring(pos + 1, str.Length - pos - 2));
						pos = str.Length;
					}
					else
					{
						buf.Add(str.Substring(pos + 1, index - pos - 1));
						pos = index + 2;
					}
				}
				else
				{
					int index = str.IndexOf(',', pos);
					if (index == -1)
					{
						buf.Add(str.Substring(pos, str.Length - pos));
						pos = str.Length;
					}
					else
					{
						buf.Add(str.Substring(pos, index - pos));
						pos = index + 1;
					}
				}
			}

			result = new string[buf.Count];
			buf.CopyTo(result);

			return result;
		}
	}
}
