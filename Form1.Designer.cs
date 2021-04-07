
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStopAxisX1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnResetAxisX1);
            this.groupBox1.Controls.Add(this.btnJogMinAxisX1);
            this.groupBox1.Controls.Add(this.chkEnabledAxisX1);
            this.groupBox1.Controls.Add(this.btnMovePosAxisX1);
            this.groupBox1.Controls.Add(this.txtMoveVeloAxisX1);
            this.groupBox1.Controls.Add(this.txtGoToPosAxisX1);
            this.groupBox1.Controls.Add(this.txtActPosAxisX1);
            this.groupBox1.Controls.Add(this.btnJogPlusX1);
            this.groupBox1.Location = new System.Drawing.Point(329, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 232);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AxisX1";
            // 
            // btnStopAxisX1
            // 
            this.btnStopAxisX1.Location = new System.Drawing.Point(72, 140);
            this.btnStopAxisX1.Name = "btnStopAxisX1";
            this.btnStopAxisX1.Size = new System.Drawing.Size(60, 40);
            this.btnStopAxisX1.TabIndex = 13;
            this.btnStopAxisX1.Text = "STOP";
            this.btnStopAxisX1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Actuel Pos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Move Pos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(137, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "mm/sn";
            // 
            // btnResetAxisX1
            // 
            this.btnResetAxisX1.Location = new System.Drawing.Point(250, 186);
            this.btnResetAxisX1.Name = "btnResetAxisX1";
            this.btnResetAxisX1.Size = new System.Drawing.Size(60, 40);
            this.btnResetAxisX1.TabIndex = 9;
            this.btnResetAxisX1.Text = "RST";
            this.btnResetAxisX1.UseVisualStyleBackColor = true;
            this.btnResetAxisX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnResetAxisX1_MouseDown);
            this.btnResetAxisX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnResetAxisX1_MouseUp);
            // 
            // btnJogMinAxisX1
            // 
            this.btnJogMinAxisX1.Location = new System.Drawing.Point(6, 186);
            this.btnJogMinAxisX1.Name = "btnJogMinAxisX1";
            this.btnJogMinAxisX1.Size = new System.Drawing.Size(60, 40);
            this.btnJogMinAxisX1.TabIndex = 8;
            this.btnJogMinAxisX1.Text = "JOG -";
            this.btnJogMinAxisX1.UseVisualStyleBackColor = true;
            this.btnJogMinAxisX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMinAxisX1_MouseDown);
            this.btnJogMinAxisX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMinAxisX1_MouseUp);
            // 
            // chkEnabledAxisX1
            // 
            this.chkEnabledAxisX1.AutoSize = true;
            this.chkEnabledAxisX1.Enabled = false;
            this.chkEnabledAxisX1.Location = new System.Drawing.Point(250, 19);
            this.chkEnabledAxisX1.Name = "chkEnabledAxisX1";
            this.chkEnabledAxisX1.Size = new System.Drawing.Size(68, 17);
            this.chkEnabledAxisX1.TabIndex = 7;
            this.chkEnabledAxisX1.Text = "Powered";
            this.chkEnabledAxisX1.UseVisualStyleBackColor = true;
            // 
            // btnMovePosAxisX1
            // 
            this.btnMovePosAxisX1.Location = new System.Drawing.Point(6, 140);
            this.btnMovePosAxisX1.Name = "btnMovePosAxisX1";
            this.btnMovePosAxisX1.Size = new System.Drawing.Size(60, 40);
            this.btnMovePosAxisX1.TabIndex = 6;
            this.btnMovePosAxisX1.Text = "MOVE";
            this.btnMovePosAxisX1.UseVisualStyleBackColor = true;
            // 
            // txtMoveVeloAxisX1
            // 
            this.txtMoveVeloAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtMoveVeloAxisX1.Location = new System.Drawing.Point(16, 94);
            this.txtMoveVeloAxisX1.Name = "txtMoveVeloAxisX1";
            this.txtMoveVeloAxisX1.Size = new System.Drawing.Size(115, 26);
            this.txtMoveVeloAxisX1.TabIndex = 3;
            this.txtMoveVeloAxisX1.Text = "10";
            this.txtMoveVeloAxisX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtGoToPosAxisX1
            // 
            this.txtGoToPosAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.txtGoToPosAxisX1.Location = new System.Drawing.Point(16, 62);
            this.txtGoToPosAxisX1.Name = "txtGoToPosAxisX1";
            this.txtGoToPosAxisX1.Size = new System.Drawing.Size(115, 26);
            this.txtGoToPosAxisX1.TabIndex = 2;
            this.txtGoToPosAxisX1.Text = "100";
            this.txtGoToPosAxisX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtActPosAxisX1
            // 
            this.txtActPosAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActPosAxisX1.Location = new System.Drawing.Point(16, 29);
            this.txtActPosAxisX1.Name = "txtActPosAxisX1";
            this.txtActPosAxisX1.ReadOnly = true;
            this.txtActPosAxisX1.Size = new System.Drawing.Size(115, 26);
            this.txtActPosAxisX1.TabIndex = 1;
            this.txtActPosAxisX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnJogPlusX1
            // 
            this.btnJogPlusX1.Location = new System.Drawing.Point(71, 186);
            this.btnJogPlusX1.Name = "btnJogPlusX1";
            this.btnJogPlusX1.Size = new System.Drawing.Size(60, 40);
            this.btnJogPlusX1.TabIndex = 0;
            this.btnJogPlusX1.Text = "JOG +";
            this.btnJogPlusX1.UseVisualStyleBackColor = true;
            this.btnJogPlusX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogPlusX1_MouseDown);
            this.btnJogPlusX1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogPlusX1_MouseUp);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 425);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(29, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Error";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}

