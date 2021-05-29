
namespace ClientServerGame
{
    partial class PlayersWaitingArea
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
            this.flpPlayers = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblNumberOfPlayers = new System.Windows.Forms.Label();
            this.lblMatchID = new System.Windows.Forms.Label();
            this.lblJoinedPlayers = new System.Windows.Forms.Label();
            this.lblGameStarting = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpPlayers
            // 
            this.flpPlayers.BackColor = System.Drawing.Color.Gray;
            this.flpPlayers.Location = new System.Drawing.Point(56, 70);
            this.flpPlayers.Name = "flpPlayers";
            this.flpPlayers.Size = new System.Drawing.Size(306, 200);
            this.flpPlayers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Players in the lobby: ";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(56, 288);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(306, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Waiting for other Players";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.TextChanged += new System.EventHandler(this.btnStart_TextChanged);
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNumberOfPlayers
            // 
            this.lblNumberOfPlayers.AutoSize = true;
            this.lblNumberOfPlayers.Location = new System.Drawing.Point(245, 9);
            this.lblNumberOfPlayers.Name = "lblNumberOfPlayers";
            this.lblNumberOfPlayers.Size = new System.Drawing.Size(76, 15);
            this.lblNumberOfPlayers.TabIndex = 3;
            this.lblNumberOfPlayers.Text = "Max Players: ";
            // 
            // lblMatchID
            // 
            this.lblMatchID.AutoSize = true;
            this.lblMatchID.Location = new System.Drawing.Point(56, 9);
            this.lblMatchID.Name = "lblMatchID";
            this.lblMatchID.Size = new System.Drawing.Size(55, 15);
            this.lblMatchID.TabIndex = 4;
            this.lblMatchID.Text = "Match ID";
            // 
            // lblJoinedPlayers
            // 
            this.lblJoinedPlayers.AutoSize = true;
            this.lblJoinedPlayers.Location = new System.Drawing.Point(245, 41);
            this.lblJoinedPlayers.Name = "lblJoinedPlayers";
            this.lblJoinedPlayers.Size = new System.Drawing.Size(87, 15);
            this.lblJoinedPlayers.TabIndex = 5;
            this.lblJoinedPlayers.Text = "Joined Players: ";
            // 
            // lblGameStarting
            // 
            this.lblGameStarting.AutoSize = true;
            this.lblGameStarting.Location = new System.Drawing.Point(56, 342);
            this.lblGameStarting.Name = "lblGameStarting";
            this.lblGameStarting.Size = new System.Drawing.Size(107, 15);
            this.lblGameStarting.TabIndex = 6;
            this.lblGameStarting.Text = "Game Starting: No ";
            this.lblGameStarting.TextChanged += new System.EventHandler(this.lblGameStarting_TextChanged);
            // 
            // PlayersWaitingArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(429, 378);
            this.Controls.Add(this.lblGameStarting);
            this.Controls.Add(this.lblJoinedPlayers);
            this.Controls.Add(this.lblMatchID);
            this.Controls.Add(this.lblNumberOfPlayers);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpPlayers);
            this.Name = "PlayersWaitingArea";
            this.Text = "PlayersWaitingArea";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblNumberOfPlayers;
        private System.Windows.Forms.Label lblMatchID;
        private System.Windows.Forms.Label lblJoinedPlayers;
        private System.Windows.Forms.Label lblGameStarting;
    }
}