namespace SnakeGame {
    partial class SnakeGame {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.GameGrid = new System.Windows.Forms.DataGridView();
            this.GridYHeightNumBox = new System.Windows.Forms.NumericUpDown();
            this.GridXLengthNumBox = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.TimerBox = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.ChangeSnakeColorButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DifficultySelection = new System.Windows.Forms.ComboBox();
            this.WallhackCheckbox = new System.Windows.Forms.CheckBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.GameGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridYHeightNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridXLengthNumBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameGrid
            // 
            this.GameGrid.AllowUserToAddRows = false;
            this.GameGrid.AllowUserToDeleteRows = false;
            this.GameGrid.AllowUserToResizeColumns = false;
            this.GameGrid.AllowUserToResizeRows = false;
            this.GameGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GameGrid.Enabled = false;
            this.GameGrid.Location = new System.Drawing.Point(0, 0);
            this.GameGrid.Name = "GameGrid";
            this.GameGrid.RowHeadersWidth = 51;
            this.GameGrid.RowTemplate.Height = 29;
            this.GameGrid.Size = new System.Drawing.Size(800, 450);
            this.GameGrid.TabIndex = 0;
            // 
            // GridYHeightNumBox
            // 
            this.GridYHeightNumBox.Location = new System.Drawing.Point(121, 12);
            this.GridYHeightNumBox.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.GridYHeightNumBox.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.GridYHeightNumBox.Name = "GridYHeightNumBox";
            this.GridYHeightNumBox.Size = new System.Drawing.Size(93, 27);
            this.GridYHeightNumBox.TabIndex = 1;
            this.GridYHeightNumBox.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.GridYHeightNumBox.ValueChanged += new System.EventHandler(this.OnYHeightChanged);
            // 
            // GridXLengthNumBox
            // 
            this.GridXLengthNumBox.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.GridXLengthNumBox.Location = new System.Drawing.Point(121, 54);
            this.GridXLengthNumBox.Maximum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.GridXLengthNumBox.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.GridXLengthNumBox.Name = "GridXLengthNumBox";
            this.GridXLengthNumBox.Size = new System.Drawing.Size(92, 27);
            this.GridXLengthNumBox.TabIndex = 2;
            this.GridXLengthNumBox.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.GridXLengthNumBox.ValueChanged += new System.EventHandler(this.OnXLengthChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Bane-højde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Bane-længde";
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(111, 182);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(94, 29);
            this.StartGameButton.TabIndex = 5;
            this.StartGameButton.Text = "Start spil";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // TimerBox
            // 
            this.TimerBox.Interval = 85;
            this.TimerBox.Tick += new System.EventHandler(this.TimerBox_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ChangeSnakeColorButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.DifficultySelection);
            this.panel1.Controls.Add(this.WallhackCheckbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.StartGameButton);
            this.panel1.Controls.Add(this.GridYHeightNumBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.GridXLengthNumBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(282, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 253);
            this.panel1.TabIndex = 6;
            // 
            // ChangeSnakeColorButton
            // 
            this.ChangeSnakeColorButton.Location = new System.Drawing.Point(67, 124);
            this.ChangeSnakeColorButton.Name = "ChangeSnakeColorButton";
            this.ChangeSnakeColorButton.Size = new System.Drawing.Size(146, 30);
            this.ChangeSnakeColorButton.TabIndex = 9;
            this.ChangeSnakeColorButton.Text = "Skift slangefarve";
            this.ChangeSnakeColorButton.UseVisualStyleBackColor = true;
            this.ChangeSnakeColorButton.Click += new System.EventHandler(this.ChangeSnakeColorButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Sværhedsgrad";
            // 
            // DifficultySelection
            // 
            this.DifficultySelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DifficultySelection.FormattingEnabled = true;
            this.DifficultySelection.Items.AddRange(new object[] {
            "Super let",
            "Let",
            "Normal",
            "Svær",
            "Ekspert"});
            this.DifficultySelection.Location = new System.Drawing.Point(121, 90);
            this.DifficultySelection.Name = "DifficultySelection";
            this.DifficultySelection.Size = new System.Drawing.Size(117, 28);
            this.DifficultySelection.TabIndex = 7;
            this.DifficultySelection.SelectedIndexChanged += new System.EventHandler(this.DifficultySelection_SelectedIndexChanged);
            // 
            // WallhackCheckbox
            // 
            this.WallhackCheckbox.AutoSize = true;
            this.WallhackCheckbox.Checked = true;
            this.WallhackCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WallhackCheckbox.Location = new System.Drawing.Point(48, 152);
            this.WallhackCheckbox.Name = "WallhackCheckbox";
            this.WallhackCheckbox.Size = new System.Drawing.Size(190, 24);
            this.WallhackCheckbox.TabIndex = 6;
            this.WallhackCheckbox.Text = "Børnebander (Wallhack)";
            this.WallhackCheckbox.UseVisualStyleBackColor = true;
            this.WallhackCheckbox.CheckedChanged += new System.EventHandler(this.WallhackCheckbox_CheckedChanged);
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GameGrid);
            this.Name = "SnakeGame";
            this.Text = "Snake";
            this.Load += new System.EventHandler(this.SnakeGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SnakeGame_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.GameGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridYHeightNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridXLengthNumBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView GameGrid;
        private NumericUpDown GridYHeightNumBox;
        private NumericUpDown GridXLengthNumBox;
        private Label label1;
        private Label label2;
        private Button StartGameButton;
        private System.Windows.Forms.Timer TimerBox;
        private Panel panel1;
        private CheckBox WallhackCheckbox;
        private Label label3;
        private ComboBox DifficultySelection;
        private ColorDialog colorDialog;
        private Button ChangeSnakeColorButton;
    }
}