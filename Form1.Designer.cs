
namespace BRCommTest
{
    partial class Form1
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
            this.gbxAxisX1 = new System.Windows.Forms.GroupBox();
            this.btnStopAxisX1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetAxisX1 = new System.Windows.Forms.Button();
            this.btnJogMinAxisX1 = new System.Windows.Forms.Button();
            this.chkEnabledAxisX1 = new System.Windows.Forms.CheckBox();
            this.btnMovePosAxisX1 = new System.Windows.Forms.Button();
            this.txtMoveVeloAxisX1 = new System.Windows.Forms.TextBox();
            this.txtGoToPosAxisX1 = new System.Windows.Forms.TextBox();
            this.txtActPosAxisX1 = new System.Windows.Forms.TextBox();
            this.btnJogPlusX1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrWaitFormLoad = new System.Windows.Forms.Timer(this.components);
            this.tmrVisuUpdate = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStructReader = new System.Windows.Forms.Button();
            this.gbxAxisX2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txtActPosAxisX2 = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.gbxAxisX1.SuspendLayout();
            this.gbxAxisX2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxAxisX1
            // 
            this.gbxAxisX1.Controls.Add(this.btnStopAxisX1);
            this.gbxAxisX1.Controls.Add(this.label3);
            this.gbxAxisX1.Controls.Add(this.label2);
            this.gbxAxisX1.Controls.Add(this.label1);
            this.gbxAxisX1.Controls.Add(this.btnResetAxisX1);
            this.gbxAxisX1.Controls.Add(this.btnJogMinAxisX1);
            this.gbxAxisX1.Controls.Add(this.chkEnabledAxisX1);
            this.gbxAxisX1.Controls.Add(this.btnMovePosAxisX1);
            this.gbxAxisX1.Controls.Add(this.txtMoveVeloAxisX1);
            this.gbxAxisX1.Controls.Add(this.txtGoToPosAxisX1);
            this.gbxAxisX1.Controls.Add(this.txtActPosAxisX1);
            this.gbxAxisX1.Controls.Add(this.btnJogPlusX1);
            this.gbxAxisX1.Location = new System.Drawing.Point(336, 19);
            this.gbxAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxAxisX1.Name = "gbxAxisX1";
            this.gbxAxisX1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxAxisX1.Size = new System.Drawing.Size(316, 356);
            this.gbxAxisX1.TabIndex = 4;
            this.gbxAxisX1.TabStop = false;
            this.gbxAxisX1.Text = "AxisX1";
            // 
            // btnStopAxisX1
            // 
            this.btnStopAxisX1.Location = new System.Drawing.Point(108, 215);
            this.btnStopAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStopAxisX1.Name = "btnStopAxisX1";
            this.btnStopAxisX1.Size = new System.Drawing.Size(90, 61);
            this.btnStopAxisX1.TabIndex = 13;
            this.btnStopAxisX1.Text = "STOP";
            this.btnStopAxisX1.UseVisualStyleBackColor = true;
            this.btnStopAxisX1.Click += new System.EventHandler(this.btnStopAxisX1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 58);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Actuel Pos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 108);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Move Pos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(206, 158);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "mm/sn";
            // 
            // btnResetAxisX1
            // 
            this.btnResetAxisX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetAxisX1.Location = new System.Drawing.Point(216, 285);
            this.btnResetAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetAxisX1.Name = "btnResetAxisX1";
            this.btnResetAxisX1.Size = new System.Drawing.Size(90, 61);
            this.btnResetAxisX1.TabIndex = 9;
            this.btnResetAxisX1.Text = "RST";
            this.btnResetAxisX1.UseVisualStyleBackColor = true;
            this.btnResetAxisX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnResetAxisX1_MouseDown);
            this.btnResetAxisX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnResetAxisX1_MouseUp);
            // 
            // btnJogMinAxisX1
            // 
            this.btnJogMinAxisX1.Location = new System.Drawing.Point(9, 286);
            this.btnJogMinAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnJogMinAxisX1.Name = "btnJogMinAxisX1";
            this.btnJogMinAxisX1.Size = new System.Drawing.Size(90, 61);
            this.btnJogMinAxisX1.TabIndex = 8;
            this.btnJogMinAxisX1.Text = "JOG -";
            this.btnJogMinAxisX1.UseVisualStyleBackColor = true;
            this.btnJogMinAxisX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMinAxisX1_MouseDown);
            this.btnJogMinAxisX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMinAxisX1_MouseUp);
            // 
            // chkEnabledAxisX1
            // 
            this.chkEnabledAxisX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkEnabledAxisX1.AutoSize = true;
            this.chkEnabledAxisX1.Enabled = false;
            this.chkEnabledAxisX1.Location = new System.Drawing.Point(209, 27);
            this.chkEnabledAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnabledAxisX1.Name = "chkEnabledAxisX1";
            this.chkEnabledAxisX1.Size = new System.Drawing.Size(97, 24);
            this.chkEnabledAxisX1.TabIndex = 7;
            this.chkEnabledAxisX1.Text = "Powered";
            this.chkEnabledAxisX1.UseVisualStyleBackColor = true;
            // 
            // btnMovePosAxisX1
            // 
            this.btnMovePosAxisX1.Location = new System.Drawing.Point(9, 215);
            this.btnMovePosAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMovePosAxisX1.Name = "btnMovePosAxisX1";
            this.btnMovePosAxisX1.Size = new System.Drawing.Size(90, 61);
            this.btnMovePosAxisX1.TabIndex = 6;
            this.btnMovePosAxisX1.Text = "MOVE";
            this.btnMovePosAxisX1.UseVisualStyleBackColor = true;
            this.btnMovePosAxisX1.Click += new System.EventHandler(this.btnMovePosAxisX1_Click);
            // 
            // txtMoveVeloAxisX1
            // 
            this.txtMoveVeloAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtMoveVeloAxisX1.Location = new System.Drawing.Point(24, 145);
            this.txtMoveVeloAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMoveVeloAxisX1.Name = "txtMoveVeloAxisX1";
            this.txtMoveVeloAxisX1.Size = new System.Drawing.Size(170, 35);
            this.txtMoveVeloAxisX1.TabIndex = 3;
            this.txtMoveVeloAxisX1.Text = "10";
            this.txtMoveVeloAxisX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGoToPosAxisX1
            // 
            this.txtGoToPosAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtGoToPosAxisX1.Location = new System.Drawing.Point(24, 95);
            this.txtGoToPosAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtGoToPosAxisX1.Name = "txtGoToPosAxisX1";
            this.txtGoToPosAxisX1.Size = new System.Drawing.Size(170, 35);
            this.txtGoToPosAxisX1.TabIndex = 2;
            this.txtGoToPosAxisX1.Text = "100";
            this.txtGoToPosAxisX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtActPosAxisX1
            // 
            this.txtActPosAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActPosAxisX1.Location = new System.Drawing.Point(24, 45);
            this.txtActPosAxisX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtActPosAxisX1.Name = "txtActPosAxisX1";
            this.txtActPosAxisX1.ReadOnly = true;
            this.txtActPosAxisX1.Size = new System.Drawing.Size(170, 35);
            this.txtActPosAxisX1.TabIndex = 1;
            this.txtActPosAxisX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnJogPlusX1
            // 
            this.btnJogPlusX1.Location = new System.Drawing.Point(107, 286);
            this.btnJogPlusX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnJogPlusX1.Name = "btnJogPlusX1";
            this.btnJogPlusX1.Size = new System.Drawing.Size(90, 61);
            this.btnJogPlusX1.TabIndex = 0;
            this.btnJogPlusX1.Text = "JOG +";
            this.btnJogPlusX1.UseVisualStyleBackColor = true;
            this.btnJogPlusX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPlusX1_MouseDown);
            this.btnJogPlusX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPlusX1_MouseUp);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 476);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 20);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Error";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrWaitFormLoad
            // 
            this.tmrWaitFormLoad.Interval = 3000;
            this.tmrWaitFormLoad.Tick += new System.EventHandler(this.tmrWaitFormLoad_Tick);
            // 
            // tmrVisuUpdate
            // 
            this.tmrVisuUpdate.Tick += new System.EventHandler(this.tmrVisuUpdate_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(100, 378);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(220, 378);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 35);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 304);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(194, 26);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "BRPlcVar1";
            // 
            // btnStructReader
            // 
            this.btnStructReader.Location = new System.Drawing.Point(75, 42);
            this.btnStructReader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStructReader.Name = "btnStructReader";
            this.btnStructReader.Size = new System.Drawing.Size(112, 35);
            this.btnStructReader.TabIndex = 9;
            this.btnStructReader.Text = "button3";
            this.btnStructReader.UseVisualStyleBackColor = true;
            this.btnStructReader.Click += new System.EventHandler(this.btnStructReader_Click);
            // 
            // gbxAxisX2
            // 
            this.gbxAxisX2.Controls.Add(this.button3);
            this.gbxAxisX2.Controls.Add(this.label4);
            this.gbxAxisX2.Controls.Add(this.label5);
            this.gbxAxisX2.Controls.Add(this.label6);
            this.gbxAxisX2.Controls.Add(this.button4);
            this.gbxAxisX2.Controls.Add(this.button5);
            this.gbxAxisX2.Controls.Add(this.checkBox1);
            this.gbxAxisX2.Controls.Add(this.button6);
            this.gbxAxisX2.Controls.Add(this.textBox2);
            this.gbxAxisX2.Controls.Add(this.textBox3);
            this.gbxAxisX2.Controls.Add(this.txtActPosAxisX2);
            this.gbxAxisX2.Controls.Add(this.button7);
            this.gbxAxisX2.Location = new System.Drawing.Point(670, 19);
            this.gbxAxisX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxAxisX2.Name = "gbxAxisX2";
            this.gbxAxisX2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbxAxisX2.Size = new System.Drawing.Size(316, 356);
            this.gbxAxisX2.TabIndex = 14;
            this.gbxAxisX2.TabStop = false;
            this.gbxAxisX2.Text = "AxisX2";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(108, 215);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(90, 61);
            this.button3.TabIndex = 13;
            this.button3.Text = "STOP";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(206, 58);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Actuel Pos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(206, 108);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Move Pos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(206, 158);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "mm/sn";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(216, 285);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(90, 61);
            this.button4.TabIndex = 9;
            this.button4.Text = "RST";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(9, 286);
            this.button5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(90, 61);
            this.button5.TabIndex = 8;
            this.button5.Text = "JOG -";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(209, 27);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(97, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Powered";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(9, 215);
            this.button6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(90, 61);
            this.button6.TabIndex = 6;
            this.button6.Text = "MOVE";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBox2.Location = new System.Drawing.Point(24, 145);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 35);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "10";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBox3.Location = new System.Drawing.Point(24, 95);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(170, 35);
            this.textBox3.TabIndex = 2;
            this.textBox3.Text = "100";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtActPosAxisX2
            // 
            this.txtActPosAxisX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActPosAxisX2.Location = new System.Drawing.Point(24, 45);
            this.txtActPosAxisX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtActPosAxisX2.Name = "txtActPosAxisX2";
            this.txtActPosAxisX2.ReadOnly = true;
            this.txtActPosAxisX2.Size = new System.Drawing.Size(170, 35);
            this.txtActPosAxisX2.TabIndex = 1;
            this.txtActPosAxisX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(107, 286);
            this.button7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(90, 61);
            this.button7.TabIndex = 0;
            this.button7.Text = "JOG +";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.gbxAxisX2);
            this.Controls.Add(this.btnStructReader);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.gbxAxisX1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxAxisX1.ResumeLayout(false);
            this.gbxAxisX1.PerformLayout();
            this.gbxAxisX2.ResumeLayout(false);
            this.gbxAxisX2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbxAxisX1;
        private System.Windows.Forms.TextBox txtActPosAxisX1;
        private System.Windows.Forms.Button btnJogPlusX1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer tmrWaitFormLoad;
        private System.Windows.Forms.TextBox txtGoToPosAxisX1;
        private System.Windows.Forms.TextBox txtMoveVeloAxisX1;
        private System.Windows.Forms.Button btnMovePosAxisX1;
        private System.Windows.Forms.CheckBox chkEnabledAxisX1;
        private System.Windows.Forms.Button btnJogMinAxisX1;
        private System.Windows.Forms.Button btnResetAxisX1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopAxisX1;
        private System.Windows.Forms.Timer tmrVisuUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStructReader;
        private System.Windows.Forms.GroupBox gbxAxisX2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox txtActPosAxisX2;
        private System.Windows.Forms.Button button7;
    }
}

