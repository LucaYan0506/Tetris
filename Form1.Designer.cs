
namespace Tetriis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.blocksContainer = new System.Windows.Forms.Panel();
            this.nxt_blockContainer = new System.Windows.Forms.Panel();
            this.next_blockImg = new System.Windows.Forms.PictureBox();
            this.background = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.linesLbl = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.speedLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.scoreLbl = new System.Windows.Forms.Label();
            this.detailPanel = new System.Windows.Forms.Label();
            this.blockDown = new System.Windows.Forms.Timer(this.components);
            this.Label2 = new System.Windows.Forms.Label();
            this.timeLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playBtn = new Tetriis.NonSelectableButton();
            this.restartBtn = new Tetriis.NonSelectableButton();
            this.change_speedBtn = new Tetriis.NonSelectableButton();
            this.nxt_blockContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.next_blockImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(77, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Next";
            // 
            // blocksContainer
            // 
            this.blocksContainer.BackColor = System.Drawing.Color.Gray;
            this.blocksContainer.Location = new System.Drawing.Point(0, 0);
            this.blocksContainer.Name = "blocksContainer";
            this.blocksContainer.Size = new System.Drawing.Size(400, 800);
            this.blocksContainer.TabIndex = 5;
            // 
            // nxt_blockContainer
            // 
            this.nxt_blockContainer.BackColor = System.Drawing.Color.Gray;
            this.nxt_blockContainer.Controls.Add(this.next_blockImg);
            this.nxt_blockContainer.Controls.Add(this.label1);
            this.nxt_blockContainer.Controls.Add(this.background);
            this.nxt_blockContainer.Location = new System.Drawing.Point(410, 12);
            this.nxt_blockContainer.Name = "nxt_blockContainer";
            this.nxt_blockContainer.Size = new System.Drawing.Size(201, 155);
            this.nxt_blockContainer.TabIndex = 6;
            // 
            // next_blockImg
            // 
            this.next_blockImg.BackColor = System.Drawing.Color.Transparent;
            this.next_blockImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.next_blockImg.Location = new System.Drawing.Point(39, 42);
            this.next_blockImg.Name = "next_blockImg";
            this.next_blockImg.Size = new System.Drawing.Size(127, 86);
            this.next_blockImg.TabIndex = 2;
            this.next_blockImg.TabStop = false;
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.DimGray;
            this.background.Location = new System.Drawing.Point(23, 32);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(157, 106);
            this.background.TabIndex = 3;
            this.background.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.Controls.Add(this.linesLbl);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.speedLbl);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.scoreLbl);
            this.panel3.Controls.Add(this.detailPanel);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(410, 173);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(201, 185);
            this.panel3.TabIndex = 7;
            // 
            // linesLbl
            // 
            this.linesLbl.BackColor = System.Drawing.Color.DimGray;
            this.linesLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.linesLbl.Location = new System.Drawing.Point(19, 140);
            this.linesLbl.Name = "linesLbl";
            this.linesLbl.Size = new System.Drawing.Size(161, 27);
            this.linesLbl.TabIndex = 6;
            this.linesLbl.Text = "0";
            this.linesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(19, 113);
            this.label7.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 27);
            this.label7.TabIndex = 5;
            this.label7.Text = "Lines";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedLbl
            // 
            this.speedLbl.BackColor = System.Drawing.Color.DimGray;
            this.speedLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.speedLbl.Location = new System.Drawing.Point(19, 85);
            this.speedLbl.Name = "speedLbl";
            this.speedLbl.Size = new System.Drawing.Size(161, 27);
            this.speedLbl.TabIndex = 4;
            this.speedLbl.Text = "1";
            this.speedLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 58);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 27);
            this.label5.TabIndex = 3;
            this.label5.Text = "Speed";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scoreLbl
            // 
            this.scoreLbl.BackColor = System.Drawing.Color.DimGray;
            this.scoreLbl.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.scoreLbl.Location = new System.Drawing.Point(23, 29);
            this.scoreLbl.Name = "scoreLbl";
            this.scoreLbl.Size = new System.Drawing.Size(161, 27);
            this.scoreLbl.TabIndex = 2;
            this.scoreLbl.Text = "0";
            this.scoreLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // detailPanel
            // 
            this.detailPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailPanel.ForeColor = System.Drawing.Color.White;
            this.detailPanel.Location = new System.Drawing.Point(23, 2);
            this.detailPanel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.detailPanel.Name = "detailPanel";
            this.detailPanel.Size = new System.Drawing.Size(161, 27);
            this.detailPanel.TabIndex = 1;
            this.detailPanel.Text = "Score";
            this.detailPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blockDown
            // 
            this.blockDown.Interval = 1000;
            this.blockDown.Tick += new System.EventHandler(this.blockDown_Tick);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(410, 361);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(201, 27);
            this.Label2.TabIndex = 11;
            this.Label2.Text = "Time";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLbl
            // 
            this.timeLbl.Location = new System.Drawing.Point(410, 388);
            this.timeLbl.Name = "timeLbl";
            this.timeLbl.Size = new System.Drawing.Size(201, 33);
            this.timeLbl.TabIndex = 12;
            this.timeLbl.Text = "00 : 00 : 00";
            this.timeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(416, 756);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(201, 33);
            this.playBtn.TabIndex = 10;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // restartBtn
            // 
            this.restartBtn.Location = new System.Drawing.Point(416, 717);
            this.restartBtn.Name = "restartBtn";
            this.restartBtn.Size = new System.Drawing.Size(201, 33);
            this.restartBtn.TabIndex = 10;
            this.restartBtn.Text = "Restart";
            this.restartBtn.UseVisualStyleBackColor = true;
            this.restartBtn.Click += new System.EventHandler(this.restartBtn_Click);
            // 
            // change_speedBtn
            // 
            this.change_speedBtn.Location = new System.Drawing.Point(416, 678);
            this.change_speedBtn.Name = "change_speedBtn";
            this.change_speedBtn.Size = new System.Drawing.Size(201, 33);
            this.change_speedBtn.TabIndex = 10;
            this.change_speedBtn.Text = "Change Speed";
            this.change_speedBtn.UseVisualStyleBackColor = true;
            this.change_speedBtn.Click += new System.EventHandler(this.change_speedBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 800);
            this.Controls.Add(this.timeLbl);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.playBtn);
            this.Controls.Add(this.restartBtn);
            this.Controls.Add(this.change_speedBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.blocksContainer);
            this.Controls.Add(this.nxt_blockContainer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Tetrix";
            this.nxt_blockContainer.ResumeLayout(false);
            this.nxt_blockContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.next_blockImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel blocksContainer;
        private System.Windows.Forms.Panel nxt_blockContainer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label detailPanel;
        private System.Windows.Forms.PictureBox next_blockImg;
        private System.Windows.Forms.Label linesLbl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label speedLbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label scoreLbl;
        private System.Windows.Forms.Timer blockDown;
        private System.Windows.Forms.PictureBox background;
        private NonSelectableButton change_speedBtn;
        private NonSelectableButton restartBtn;
        private NonSelectableButton playBtn;
        private System.Windows.Forms.Label Label2;
        private System.Windows.Forms.Label timeLbl;
        private System.Windows.Forms.Timer timer1;
    }
}

