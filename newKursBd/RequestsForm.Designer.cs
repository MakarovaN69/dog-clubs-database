
namespace newKursBd
{
    partial class RequestsForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CountRecordinglabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SelectscomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.OutputcomboBox = new System.Windows.Forms.ComboBox();
            this.InputtextBox = new System.Windows.Forms.TextBox();
            this.Applybutton = new System.Windows.Forms.Button();
            this.exportToExcelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(641, 338);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(354, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Запросы";
            // 
            // CountRecordinglabel
            // 
            this.CountRecordinglabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CountRecordinglabel.AutoSize = true;
            this.CountRecordinglabel.Location = new System.Drawing.Point(12, 419);
            this.CountRecordinglabel.Name = "CountRecordinglabel";
            this.CountRecordinglabel.Size = new System.Drawing.Size(114, 13);
            this.CountRecordinglabel.TabIndex = 2;
            this.CountRecordinglabel.Text = "Количество записей:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Название запроса:";
            // 
            // SelectscomboBox
            // 
            this.SelectscomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectscomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SelectscomboBox.FormattingEnabled = true;
            this.SelectscomboBox.Location = new System.Drawing.Point(138, 38);
            this.SelectscomboBox.Name = "SelectscomboBox";
            this.SelectscomboBox.Size = new System.Drawing.Size(506, 21);
            this.SelectscomboBox.TabIndex = 4;
            this.toolTip1.SetToolTip(this.SelectscomboBox, "Элемент");
            this.SelectscomboBox.SelectedIndexChanged += new System.EventHandler(this.SelectscomboBox_SelectedIndexChanged);
            this.SelectscomboBox.MouseHover += new System.EventHandler(this.SelectscomboBox_MouseHover);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(682, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "от:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(682, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "до:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(709, 97);
            this.dateTimePicker1.MaxDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(1980, 1, 17, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(81, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2.Location = new System.Drawing.Point(710, 127);
            this.dateTimePicker2.MaxDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker2.MinDate = new System.DateTime(1979, 1, 18, 0, 0, 0, 0);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(81, 20);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // OutputcomboBox
            // 
            this.OutputcomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OutputcomboBox.FormattingEnabled = true;
            this.OutputcomboBox.Location = new System.Drawing.Point(663, 169);
            this.OutputcomboBox.Name = "OutputcomboBox";
            this.OutputcomboBox.Size = new System.Drawing.Size(155, 21);
            this.OutputcomboBox.TabIndex = 9;
            this.toolTip1.SetToolTip(this.OutputcomboBox, "Элемент");
            this.OutputcomboBox.MouseHover += new System.EventHandler(this.OutputcomboBox_MouseHover);
            // 
            // InputtextBox
            // 
            this.InputtextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InputtextBox.Location = new System.Drawing.Point(663, 223);
            this.InputtextBox.Name = "InputtextBox";
            this.InputtextBox.Size = new System.Drawing.Size(155, 20);
            this.InputtextBox.TabIndex = 10;
            // 
            // Applybutton
            // 
            this.Applybutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Applybutton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Applybutton.Location = new System.Drawing.Point(685, 269);
            this.Applybutton.Name = "Applybutton";
            this.Applybutton.Size = new System.Drawing.Size(128, 35);
            this.Applybutton.TabIndex = 11;
            this.Applybutton.Text = "Применить";
            this.Applybutton.UseVisualStyleBackColor = false;
            this.Applybutton.Click += new System.EventHandler(this.Applybutton_Click);
            // 
            // exportToExcelButton
            // 
            this.exportToExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportToExcelButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.exportToExcelButton.Location = new System.Drawing.Point(685, 334);
            this.exportToExcelButton.Name = "exportToExcelButton";
            this.exportToExcelButton.Size = new System.Drawing.Size(128, 35);
            this.exportToExcelButton.TabIndex = 12;
            this.exportToExcelButton.Text = "Экспорт в Excel";
            this.exportToExcelButton.UseVisualStyleBackColor = false;
            this.exportToExcelButton.Click += new System.EventHandler(this.exportToExcelButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(691, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Входные данные:";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "xls files (*.xlsx)|*.xlsx";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(663, 196);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 21);
            this.comboBox1.TabIndex = 14;
            this.toolTip1.SetToolTip(this.comboBox1, "Элемент");
            // 
            // RequestsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(215)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(830, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.exportToExcelButton);
            this.Controls.Add(this.Applybutton);
            this.Controls.Add(this.InputtextBox);
            this.Controls.Add(this.OutputcomboBox);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelectscomboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CountRecordinglabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RequestsForm";
            this.Text = "Запросы";
            this.Load += new System.EventHandler(this.RequestsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CountRecordinglabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SelectscomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox OutputcomboBox;
        private System.Windows.Forms.TextBox InputtextBox;
        private System.Windows.Forms.Button Applybutton;
        private System.Windows.Forms.Button exportToExcelButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}