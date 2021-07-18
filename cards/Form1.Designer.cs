namespace cards
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
            this.buttonHit = new System.Windows.Forms.Button();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonRestart = new System.Windows.Forms.Button();
            this.listBoxDealer = new System.Windows.Forms.ListBox();
            this.listBoxPlayer = new System.Windows.Forms.ListBox();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.labelDealerScore = new System.Windows.Forms.Label();
            this.labelPlayerScore = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxBet = new System.Windows.Forms.TextBox();
            this.buttonConfirmBet = new System.Windows.Forms.Button();
            this.labelRound = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonHit
            // 
            this.buttonHit.Location = new System.Drawing.Point(10, 207);
            this.buttonHit.Name = "buttonHit";
            this.buttonHit.Size = new System.Drawing.Size(100, 25);
            this.buttonHit.TabIndex = 0;
            this.buttonHit.Text = "Hit";
            this.buttonHit.UseVisualStyleBackColor = true;
            this.buttonHit.Click += new System.EventHandler(this.buttonHit_Click);
            // 
            // buttonStand
            // 
            this.buttonStand.Location = new System.Drawing.Point(116, 207);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(100, 25);
            this.buttonStand.TabIndex = 1;
            this.buttonStand.Text = "Stand";
            this.buttonStand.UseVisualStyleBackColor = true;
            this.buttonStand.Click += new System.EventHandler(this.buttonStand_Click);
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(222, 207);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(100, 25);
            this.buttonRestart.TabIndex = 2;
            this.buttonRestart.Text = "Draw Next Hand";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.buttonRestart_Click);
            // 
            // listBoxDealer
            // 
            this.listBoxDealer.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxDealer.FormattingEnabled = true;
            this.listBoxDealer.ItemHeight = 15;
            this.listBoxDealer.Location = new System.Drawing.Point(10, 12);
            this.listBoxDealer.Name = "listBoxDealer";
            this.listBoxDealer.Size = new System.Drawing.Size(147, 169);
            this.listBoxDealer.TabIndex = 3;
            // 
            // listBoxPlayer
            // 
            this.listBoxPlayer.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPlayer.FormattingEnabled = true;
            this.listBoxPlayer.ItemHeight = 15;
            this.listBoxPlayer.Location = new System.Drawing.Point(175, 12);
            this.listBoxPlayer.Name = "listBoxPlayer";
            this.listBoxPlayer.Size = new System.Drawing.Size(147, 169);
            this.listBoxPlayer.TabIndex = 4;
            // 
            // labelDisplay
            // 
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplay.Location = new System.Drawing.Point(328, 139);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(57, 20);
            this.labelDisplay.TabIndex = 5;
            this.labelDisplay.Text = "display";
            // 
            // labelDealerScore
            // 
            this.labelDealerScore.AutoSize = true;
            this.labelDealerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDealerScore.Location = new System.Drawing.Point(11, 184);
            this.labelDealerScore.Name = "labelDealerScore";
            this.labelDealerScore.Size = new System.Drawing.Size(119, 20);
            this.labelDealerScore.TabIndex = 6;
            this.labelDealerScore.Text = "Dealer Score: 0";
            // 
            // labelPlayerScore
            // 
            this.labelPlayerScore.AutoSize = true;
            this.labelPlayerScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayerScore.Location = new System.Drawing.Point(171, 184);
            this.labelPlayerScore.Name = "labelPlayerScore";
            this.labelPlayerScore.Size = new System.Drawing.Size(111, 20);
            this.labelPlayerScore.TabIndex = 7;
            this.labelPlayerScore.Text = "PlayerScore: 0";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.Location = new System.Drawing.Point(331, 69);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(56, 20);
            this.labelMoney.TabIndex = 8;
            this.labelMoney.Text = "money";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(331, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Bet Amount:";
            // 
            // textBoxBet
            // 
            this.textBoxBet.Location = new System.Drawing.Point(435, 12);
            this.textBoxBet.Name = "textBoxBet";
            this.textBoxBet.Size = new System.Drawing.Size(92, 20);
            this.textBoxBet.TabIndex = 10;
            // 
            // buttonConfirmBet
            // 
            this.buttonConfirmBet.Location = new System.Drawing.Point(435, 38);
            this.buttonConfirmBet.Name = "buttonConfirmBet";
            this.buttonConfirmBet.Size = new System.Drawing.Size(92, 23);
            this.buttonConfirmBet.TabIndex = 11;
            this.buttonConfirmBet.Text = "Confirm Bet";
            this.buttonConfirmBet.UseVisualStyleBackColor = true;
            this.buttonConfirmBet.Click += new System.EventHandler(this.buttonConfirmBet_Click);
            // 
            // labelRound
            // 
            this.labelRound.AutoSize = true;
            this.labelRound.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRound.Location = new System.Drawing.Point(331, 107);
            this.labelRound.Name = "labelRound";
            this.labelRound.Size = new System.Drawing.Size(57, 20);
            this.labelRound.TabIndex = 12;
            this.labelRound.Text = "Round";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 247);
            this.Controls.Add(this.labelRound);
            this.Controls.Add(this.buttonConfirmBet);
            this.Controls.Add(this.textBoxBet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.labelPlayerScore);
            this.Controls.Add(this.labelDealerScore);
            this.Controls.Add(this.labelDisplay);
            this.Controls.Add(this.listBoxPlayer);
            this.Controls.Add(this.listBoxDealer);
            this.Controls.Add(this.buttonRestart);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.buttonHit);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Button buttonStand;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.ListBox listBoxDealer;
        private System.Windows.Forms.ListBox listBoxPlayer;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.Label labelDealerScore;
        private System.Windows.Forms.Label labelPlayerScore;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBet;
        private System.Windows.Forms.Button buttonConfirmBet;
        private System.Windows.Forms.Label labelRound;
    }
}

