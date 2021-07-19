namespace cards
{
    partial class FormBlackjack
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
            this.metroButtonHit = new MetroFramework.Controls.MetroButton();
            this.metroButtonStand = new MetroFramework.Controls.MetroButton();
            this.metroButtonRestart = new MetroFramework.Controls.MetroButton();
            this.metroLabelDealerScore = new MetroFramework.Controls.MetroLabel();
            this.metroLabelPlayerScore = new MetroFramework.Controls.MetroLabel();
            this.metroListViewDealer = new MetroFramework.Controls.MetroListView();
            this.metroListViewPlayer = new MetroFramework.Controls.MetroListView();
            this.metroButtonConfirmBet = new MetroFramework.Controls.MetroButton();
            this.metroTextBoxBet = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabelMoney = new MetroFramework.Controls.MetroLabel();
            this.metroLabelRound = new MetroFramework.Controls.MetroLabel();
            this.metroLabelDisplay = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroButtonHit
            // 
            this.metroButtonHit.Location = new System.Drawing.Point(25, 274);
            this.metroButtonHit.Name = "metroButtonHit";
            this.metroButtonHit.Size = new System.Drawing.Size(100, 23);
            this.metroButtonHit.TabIndex = 13;
            this.metroButtonHit.Text = "Hit";
            this.metroButtonHit.UseSelectable = true;
            this.metroButtonHit.Click += new System.EventHandler(this.metroButtonHit_Click);
            // 
            // metroButtonStand
            // 
            this.metroButtonStand.Location = new System.Drawing.Point(131, 274);
            this.metroButtonStand.Name = "metroButtonStand";
            this.metroButtonStand.Size = new System.Drawing.Size(100, 23);
            this.metroButtonStand.TabIndex = 14;
            this.metroButtonStand.Text = "Stand";
            this.metroButtonStand.UseSelectable = true;
            this.metroButtonStand.Click += new System.EventHandler(this.metroButtonStand_Click);
            // 
            // metroButtonRestart
            // 
            this.metroButtonRestart.Location = new System.Drawing.Point(237, 274);
            this.metroButtonRestart.Name = "metroButtonRestart";
            this.metroButtonRestart.Size = new System.Drawing.Size(100, 23);
            this.metroButtonRestart.TabIndex = 15;
            this.metroButtonRestart.Text = "Draw Next Hand";
            this.metroButtonRestart.UseSelectable = true;
            this.metroButtonRestart.Click += new System.EventHandler(this.metroButtonRestart_Click);
            // 
            // metroLabelDealerScore
            // 
            this.metroLabelDealerScore.AutoSize = true;
            this.metroLabelDealerScore.Location = new System.Drawing.Point(23, 235);
            this.metroLabelDealerScore.Name = "metroLabelDealerScore";
            this.metroLabelDealerScore.Size = new System.Drawing.Size(98, 19);
            this.metroLabelDealerScore.TabIndex = 16;
            this.metroLabelDealerScore.Text = "Dealer Score: 0";
            // 
            // metroLabelPlayerScore
            // 
            this.metroLabelPlayerScore.AutoSize = true;
            this.metroLabelPlayerScore.Location = new System.Drawing.Point(187, 235);
            this.metroLabelPlayerScore.Name = "metroLabelPlayerScore";
            this.metroLabelPlayerScore.Size = new System.Drawing.Size(96, 19);
            this.metroLabelPlayerScore.TabIndex = 17;
            this.metroLabelPlayerScore.Text = "Player Score: 0";
            // 
            // metroListViewDealer
            // 
            this.metroListViewDealer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewDealer.FullRowSelect = true;
            this.metroListViewDealer.Location = new System.Drawing.Point(23, 63);
            this.metroListViewDealer.Name = "metroListViewDealer";
            this.metroListViewDealer.OwnerDraw = true;
            this.metroListViewDealer.Scrollable = false;
            this.metroListViewDealer.Size = new System.Drawing.Size(147, 169);
            this.metroListViewDealer.TabIndex = 18;
            this.metroListViewDealer.UseCompatibleStateImageBehavior = false;
            this.metroListViewDealer.UseSelectable = true;
            // 
            // metroListViewPlayer
            // 
            this.metroListViewPlayer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.metroListViewPlayer.FullRowSelect = true;
            this.metroListViewPlayer.Location = new System.Drawing.Point(187, 63);
            this.metroListViewPlayer.Name = "metroListViewPlayer";
            this.metroListViewPlayer.OwnerDraw = true;
            this.metroListViewPlayer.Scrollable = false;
            this.metroListViewPlayer.Size = new System.Drawing.Size(150, 169);
            this.metroListViewPlayer.TabIndex = 19;
            this.metroListViewPlayer.UseCompatibleStateImageBehavior = false;
            this.metroListViewPlayer.UseSelectable = true;
            // 
            // metroButtonConfirmBet
            // 
            this.metroButtonConfirmBet.Location = new System.Drawing.Point(438, 89);
            this.metroButtonConfirmBet.Name = "metroButtonConfirmBet";
            this.metroButtonConfirmBet.Size = new System.Drawing.Size(104, 23);
            this.metroButtonConfirmBet.TabIndex = 20;
            this.metroButtonConfirmBet.Text = "Confirm Bet";
            this.metroButtonConfirmBet.UseSelectable = true;
            this.metroButtonConfirmBet.Click += new System.EventHandler(this.metroButtonConfirmBet_Click);
            // 
            // metroTextBoxBet
            // 
            // 
            // 
            // 
            this.metroTextBoxBet.CustomButton.Image = null;
            this.metroTextBoxBet.CustomButton.Location = new System.Drawing.Point(82, 1);
            this.metroTextBoxBet.CustomButton.Name = "";
            this.metroTextBoxBet.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBoxBet.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBoxBet.CustomButton.TabIndex = 1;
            this.metroTextBoxBet.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBoxBet.CustomButton.UseSelectable = true;
            this.metroTextBoxBet.CustomButton.Visible = false;
            this.metroTextBoxBet.Lines = new string[0];
            this.metroTextBoxBet.Location = new System.Drawing.Point(438, 60);
            this.metroTextBoxBet.MaxLength = 32767;
            this.metroTextBoxBet.Name = "metroTextBoxBet";
            this.metroTextBoxBet.PasswordChar = '\0';
            this.metroTextBoxBet.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBoxBet.SelectedText = "";
            this.metroTextBoxBet.SelectionLength = 0;
            this.metroTextBoxBet.SelectionStart = 0;
            this.metroTextBoxBet.ShortcutsEnabled = true;
            this.metroTextBoxBet.Size = new System.Drawing.Size(104, 23);
            this.metroTextBoxBet.TabIndex = 21;
            this.metroTextBoxBet.UseSelectable = true;
            this.metroTextBoxBet.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBoxBet.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(350, 64);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(82, 19);
            this.metroLabel1.TabIndex = 22;
            this.metroLabel1.Text = "Bet Amount:";
            // 
            // metroLabelMoney
            // 
            this.metroLabelMoney.AutoSize = true;
            this.metroLabelMoney.Location = new System.Drawing.Point(350, 125);
            this.metroLabelMoney.Name = "metroLabelMoney";
            this.metroLabelMoney.Size = new System.Drawing.Size(49, 19);
            this.metroLabelMoney.TabIndex = 23;
            this.metroLabelMoney.Text = "money";
            // 
            // metroLabelRound
            // 
            this.metroLabelRound.AutoSize = true;
            this.metroLabelRound.Location = new System.Drawing.Point(350, 154);
            this.metroLabelRound.Name = "metroLabelRound";
            this.metroLabelRound.Size = new System.Drawing.Size(47, 19);
            this.metroLabelRound.TabIndex = 24;
            this.metroLabelRound.Text = "Round";
            // 
            // metroLabelDisplay
            // 
            this.metroLabelDisplay.Location = new System.Drawing.Point(350, 187);
            this.metroLabelDisplay.Name = "metroLabelDisplay";
            this.metroLabelDisplay.Size = new System.Drawing.Size(192, 96);
            this.metroLabelDisplay.TabIndex = 25;
            this.metroLabelDisplay.Text = "Display";
            this.metroLabelDisplay.WrapToLine = true;
            // 
            // FormBlackjack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 318);
            this.Controls.Add(this.metroLabelDisplay);
            this.Controls.Add(this.metroLabelRound);
            this.Controls.Add(this.metroLabelMoney);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroTextBoxBet);
            this.Controls.Add(this.metroButtonConfirmBet);
            this.Controls.Add(this.metroListViewPlayer);
            this.Controls.Add(this.metroListViewDealer);
            this.Controls.Add(this.metroLabelPlayerScore);
            this.Controls.Add(this.metroLabelDealerScore);
            this.Controls.Add(this.metroButtonRestart);
            this.Controls.Add(this.metroButtonStand);
            this.Controls.Add(this.metroButtonHit);
            this.Name = "FormBlackjack";
            this.Text = "Blackjack";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButtonHit;
        private MetroFramework.Controls.MetroButton metroButtonStand;
        private MetroFramework.Controls.MetroButton metroButtonRestart;
        private MetroFramework.Controls.MetroLabel metroLabelDealerScore;
        private MetroFramework.Controls.MetroLabel metroLabelPlayerScore;
        private MetroFramework.Controls.MetroListView metroListViewDealer;
        private MetroFramework.Controls.MetroListView metroListViewPlayer;
        private MetroFramework.Controls.MetroButton metroButtonConfirmBet;
        private MetroFramework.Controls.MetroTextBox metroTextBoxBet;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabelMoney;
        private MetroFramework.Controls.MetroLabel metroLabelRound;
        private MetroFramework.Controls.MetroLabel metroLabelDisplay;
    }
}

