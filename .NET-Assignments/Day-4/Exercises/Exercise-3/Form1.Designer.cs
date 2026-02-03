namespace Exercise_3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txtCountry = new TextBox();
            txtState = new TextBox();
            chkPostal = new CheckBox();
            chkEmail = new CheckBox();
            rbMale = new RadioButton();
            rbFemale = new RadioButton();
            comboBoxState = new ComboBox();
            btnAdd = new Button();
            btnRemoveCountry = new Button();
            btnRemoveState = new Button();
            btnShowDetails = new Button();
            CountryView = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(70, 40);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 0;
            label1.Text = "Country";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 91);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 1;
            label2.Text = "State";
            // 
            // txtCountry
            // 
            txtCountry.Location = new Point(152, 33);
            txtCountry.Name = "txtCountry";
            txtCountry.Size = new Size(221, 27);
            txtCountry.TabIndex = 6;
            txtCountry.TextChanged += txtCountry_TextChanged;
            // 
            // txtState
            // 
            txtState.Location = new Point(152, 84);
            txtState.Name = "txtState";
            txtState.Size = new Size(221, 27);
            txtState.TabIndex = 7;
            // 
            // chkPostal
            // 
            chkPostal.AutoSize = true;
            chkPostal.Location = new Point(70, 168);
            chkPostal.Name = "chkPostal";
            chkPostal.Size = new Size(103, 24);
            chkPostal.TabIndex = 8;
            chkPostal.Text = "Postal Mail";
            chkPostal.UseVisualStyleBackColor = true;
            // 
            // chkEmail
            // 
            chkEmail.AutoSize = true;
            chkEmail.Location = new Point(70, 209);
            chkEmail.Name = "chkEmail";
            chkEmail.Size = new Size(68, 24);
            chkEmail.TabIndex = 9;
            chkEmail.Text = "Email";
            chkEmail.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(215, 167);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(63, 24);
            rbMale.TabIndex = 10;
            rbMale.TabStop = true;
            rbMale.Text = "Male";
            rbMale.UseVisualStyleBackColor = true;
            rbMale.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(215, 209);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(78, 24);
            rbFemale.TabIndex = 11;
            rbFemale.TabStop = true;
            rbFemale.Text = "Female";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // comboBoxState
            // 
            comboBoxState.FormattingEnabled = true;
            comboBoxState.Location = new Point(409, 205);
            comboBoxState.Name = "comboBoxState";
            comboBoxState.Size = new Size(151, 28);
            comboBoxState.TabIndex = 13;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(70, 276);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click_1;
            // 
            // btnRemoveCountry
            // 
            btnRemoveCountry.Location = new Point(206, 276);
            btnRemoveCountry.Name = "btnRemoveCountry";
            btnRemoveCountry.Size = new Size(141, 29);
            btnRemoveCountry.TabIndex = 15;
            btnRemoveCountry.Text = "Remove Country";
            btnRemoveCountry.UseVisualStyleBackColor = true;
            btnRemoveCountry.Click += btnRemoveCountry_Click;
            // 
            // btnRemoveState
            // 
            btnRemoveState.Location = new Point(399, 276);
            btnRemoveState.Name = "btnRemoveState";
            btnRemoveState.Size = new Size(139, 29);
            btnRemoveState.TabIndex = 16;
            btnRemoveState.Text = "Remove State";
            btnRemoveState.UseVisualStyleBackColor = true;
            btnRemoveState.Click += btnRemoveState_Click_1;
            // 
            // btnShowDetails
            // 
            btnShowDetails.Location = new Point(588, 276);
            btnShowDetails.Name = "btnShowDetails";
            btnShowDetails.Size = new Size(130, 29);
            btnShowDetails.TabIndex = 17;
            btnShowDetails.Text = "Show Details";
            btnShowDetails.UseVisualStyleBackColor = true;
            btnShowDetails.Click += btnShowDetails_Click_1;
            // 
            // CountryView
            // 
            CountryView.CheckBoxes = true;
            CountryView.Location = new Point(409, 33);
            CountryView.Name = "CountryView";
            CountryView.Size = new Size(324, 158);
            CountryView.TabIndex = 18;
            CountryView.UseCompatibleStateImageBehavior = false;
            CountryView.View = View.List;
            CountryView.SelectedIndexChanged += CountryView_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(CountryView);
            Controls.Add(btnShowDetails);
            Controls.Add(btnRemoveState);
            Controls.Add(btnRemoveCountry);
            Controls.Add(btnAdd);
            Controls.Add(comboBoxState);
            Controls.Add(rbFemale);
            Controls.Add(rbMale);
            Controls.Add(chkEmail);
            Controls.Add(chkPostal);
            Controls.Add(txtState);
            Controls.Add(txtCountry);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Country Info";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCountry;
        private TextBox txtState;
        private CheckBox chkPostal;
        private CheckBox chkEmail;
        private RadioButton rbMale;
        private RadioButton rbFemale;
        private ComboBox comboBoxState;
        private Button btnAdd;
        private Button btnRemoveCountry;
        private Button btnRemoveState;
        private Button btnShowDetails;
        private ListView CountryView;
    }
}
