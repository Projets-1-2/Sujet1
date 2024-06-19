namespace myapp1
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
            textBox1 = new TextBox();
            panel1 = new Panel();
            panel9 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            panel7 = new Panel();
            panel6 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            button1 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel8 = new Panel();
            panel10 = new Panel();
            panel11 = new Panel();
            panel12 = new Panel();
            button4 = new Button();
            label4 = new Label();
            label5 = new Label();
            panel1.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(599, 156);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 23);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panel9);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Location = new Point(3, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(130, 449);
            panel1.TabIndex = 2;
            // 
            // panel9
            // 
            panel9.Location = new Point(126, 0);
            panel9.Name = "panel9";
            panel9.Size = new Size(671, 54);
            panel9.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13F);
            label3.Location = new Point(33, 8);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 0;
            label3.Text = "Tables";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Location = new Point(9, 103);
            panel3.Name = "panel3";
            panel3.Size = new Size(111, 33);
            panel3.TabIndex = 0;
            // 
            // panel7
            // 
            panel7.Location = new Point(9, 308);
            panel7.Name = "panel7";
            panel7.Size = new Size(111, 41);
            panel7.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Location = new Point(9, 255);
            panel6.Name = "panel6";
            panel6.Size = new Size(111, 37);
            panel6.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Location = new Point(9, 201);
            panel5.Name = "panel5";
            panel5.Size = new Size(111, 42);
            panel5.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Location = new Point(9, 151);
            panel4.Name = "panel4";
            panel4.Size = new Size(111, 35);
            panel4.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlLight;
            button1.ForeColor = Color.Black;
            button1.Location = new Point(466, 130);
            button1.Name = "button1";
            button1.Size = new Size(82, 31);
            button1.TabIndex = 3;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlLight;
            button2.Location = new Point(466, 202);
            button2.Name = "button2";
            button2.Size = new Size(82, 29);
            button2.TabIndex = 4;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel2
            // 
            panel2.Location = new Point(139, 86);
            panel2.Name = "panel2";
            panel2.Size = new Size(310, 171);
            panel2.TabIndex = 6;
            panel2.Paint += panel2_Paint;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F);
            label2.ForeColor = Color.Green;
            label2.Location = new Point(-3, 5);
            label2.Name = "label2";
            label2.Size = new Size(221, 28);
            label2.TabIndex = 8;
            label2.Text = "Databases management";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(600, 117);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 7;
            label1.Text = "name of database";
            // 
            // panel8
            // 
            panel8.Location = new Point(139, 296);
            panel8.Name = "panel8";
            panel8.Size = new Size(244, 144);
            panel8.TabIndex = 9;
            // 
            // panel10
            // 
            panel10.BackColor = Color.White;
            panel10.Controls.Add(label2);
            panel10.Location = new Point(132, 1);
            panel10.Name = "panel10";
            panel10.Size = new Size(668, 47);
            panel10.TabIndex = 9;
            // 
            // panel11
            // 
            panel11.Location = new Point(389, 296);
            panel11.Name = "panel11";
            panel11.Size = new Size(200, 144);
            panel11.TabIndex = 10;
            // 
            // panel12
            // 
            panel12.Location = new Point(588, 296);
            panel12.Name = "panel12";
            panel12.Size = new Size(200, 144);
            panel12.TabIndex = 11;
            // 
            // button4
            // 
            button4.Location = new Point(726, 156);
            button4.Name = "button4";
            button4.Size = new Size(44, 23);
            button4.TabIndex = 12;
            button4.Text = "OK";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F);
            label4.Location = new Point(139, 268);
            label4.Name = "label4";
            label4.Size = new Size(60, 25);
            label4.TabIndex = 13;
            label4.Text = "Childs";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13F);
            label5.Location = new Point(139, 58);
            label5.Name = "label5";
            label5.Size = new Size(61, 25);
            label5.TabIndex = 14;
            label5.Text = "Parent";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(panel12);
            Controls.Add(panel11);
            Controls.Add(panel10);
            Controls.Add(panel8);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Panel panel1;
        private Button button1;
        private Button button2;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Panel panel6;
        private Panel panel5;
        private Panel panel4;
        private Panel panel3;
        private Panel panel7;
        private Panel panel8;
        private Label label3;
        private Panel panel9;
        private Panel panel10;
        private Panel panel11;
        private Panel panel12;
        private Button button4;
        private Label label4;
        private Label label5;
    }
}
