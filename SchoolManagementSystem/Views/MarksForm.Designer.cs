namespace SchoolManagementSystem.Views
{
    partial class MarkForm
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
            this.lblMrksInput = new System.Windows.Forms.Label();
            this.txtMarksInput = new System.Windows.Forms.TextBox();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.cmbSubject = new System.Windows.Forms.ComboBox();
            this.cmbExam = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bntAdd = new System.Windows.Forms.Button();
            this.bntUpdate = new System.Windows.Forms.Button();
            this.bntDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMrksInput
            // 
            this.lblMrksInput.AutoSize = true;
            this.lblMrksInput.Location = new System.Drawing.Point(17, 34);
            this.lblMrksInput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMrksInput.Name = "lblMrksInput";
            this.lblMrksInput.Size = new System.Drawing.Size(69, 13);
            this.lblMrksInput.TabIndex = 0;
            this.lblMrksInput.Text = "Input Marks :";
            // 
            // txtMarksInput
            // 
            this.txtMarksInput.Location = new System.Drawing.Point(95, 34);
            this.txtMarksInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMarksInput.Name = "txtMarksInput";
            this.txtMarksInput.Size = new System.Drawing.Size(68, 20);
            this.txtMarksInput.TabIndex = 1;
            // 
            // cmbStudent
            // 
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(39, 78);
            this.cmbStudent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(93, 21);
            this.cmbStudent.TabIndex = 3;
            this.cmbStudent.Text = "Select Student ";
            // 
            // cmbSubject
            // 
            this.cmbSubject.FormattingEnabled = true;
            this.cmbSubject.Location = new System.Drawing.Point(181, 78);
            this.cmbSubject.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbSubject.Name = "cmbSubject";
            this.cmbSubject.Size = new System.Drawing.Size(94, 21);
            this.cmbSubject.TabIndex = 5;
            this.cmbSubject.Text = "Select Subject ";
            // 
            // cmbExam
            // 
            this.cmbExam.FormattingEnabled = true;
            this.cmbExam.Location = new System.Drawing.Point(339, 78);
            this.cmbExam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbExam.Name = "cmbExam";
            this.cmbExam.Size = new System.Drawing.Size(82, 21);
            this.cmbExam.TabIndex = 7;
            this.cmbExam.Text = "Select Exam ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(54, 155);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(328, 118);
            this.dataGridView1.TabIndex = 8;
            // 
            // bntAdd
            // 
            this.bntAdd.Location = new System.Drawing.Point(54, 116);
            this.bntAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntAdd.Name = "bntAdd";
            this.bntAdd.Size = new System.Drawing.Size(50, 21);
            this.bntAdd.TabIndex = 9;
            this.bntAdd.Text = "Add";
            this.bntAdd.UseVisualStyleBackColor = true;
            // 
            // bntUpdate
            // 
            this.bntUpdate.Location = new System.Drawing.Point(159, 116);
            this.bntUpdate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntUpdate.Name = "bntUpdate";
            this.bntUpdate.Size = new System.Drawing.Size(50, 21);
            this.bntUpdate.TabIndex = 10;
            this.bntUpdate.Text = "Update";
            this.bntUpdate.UseVisualStyleBackColor = true;
            // 
            // bntDelete
            // 
            this.bntDelete.Location = new System.Drawing.Point(271, 116);
            this.bntDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(50, 21);
            this.bntDelete.TabIndex = 11;
            this.bntDelete.Text = "Delete";
            this.bntDelete.UseVisualStyleBackColor = true;
           
            // 
            // MarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.bntDelete);
            this.Controls.Add(this.bntUpdate);
            this.Controls.Add(this.bntAdd);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmbExam);
            this.Controls.Add(this.cmbSubject);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.txtMarksInput);
            this.Controls.Add(this.lblMrksInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MarksForm";
            this.Text = "MarksForm";
            
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMrksInput;
        private System.Windows.Forms.TextBox txtMarksInput;
        private System.Windows.Forms.ComboBox cmbStudent;
        private System.Windows.Forms.ComboBox cmbSubject;
        private System.Windows.Forms.ComboBox cmbExam;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bntAdd;
        private System.Windows.Forms.Button bntUpdate;
        private System.Windows.Forms.Button bntDelete;
    }
}