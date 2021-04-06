
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
            this.txtActPosAxisX1 = new System.Windows.Forms.TextBox();
            this.btnJogPlusX1 = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrWaitFormLoad = new System.Windows.Forms.Timer(this.components);
            this.tmrAssignToPlc = new System.Windows.Forms.Timer(this.components);
            this.tmrReadPlcVal = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtActPosAxisX1);
            this.groupBox1.Controls.Add(this.btnJogPlusX1);
            this.groupBox1.Location = new System.Drawing.Point(243, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 232);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AxisX1";
            // 
            // txtActPosAxisX1
            // 
            this.txtActPosAxisX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtActPosAxisX1.Location = new System.Drawing.Point(16, 29);
            this.txtActPosAxisX1.Name = "txtActPosAxisX1";
            this.txtActPosAxisX1.ReadOnly = true;
            this.txtActPosAxisX1.Size = new System.Drawing.Size(100, 26);
            this.txtActPosAxisX1.TabIndex = 1;
            // 
            // btnJogPlusX1
            // 
            this.btnJogPlusX1.Location = new System.Drawing.Point(16, 69);
            this.btnJogPlusX1.Name = "btnJogPlusX1";
            this.btnJogPlusX1.Size = new System.Drawing.Size(57, 39);
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
            // tmrAssignToPlc
            // 
            this.tmrAssignToPlc.Tick += new System.EventHandler(this.tmrAssignToPlc_Tick);
            // 
            // tmrReadPlcVal
            // 
            this.tmrReadPlcVal.Tick += new System.EventHandler(this.tmrReadPlcVal_Tick);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
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
        private System.Windows.Forms.Timer tmrAssignToPlc;
        private System.Windows.Forms.Timer tmrReadPlcVal;
    }
}

