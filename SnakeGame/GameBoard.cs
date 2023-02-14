using System.ComponentModel;
using System.Windows.Forms.VisualStyles;

namespace SnakeGame {
    public partial class SnakeGame : Form {
        private Coordinate[,] PlayingField = new Coordinate[0, 0];
        private Snake? Snake = null;

        // This is the default  amount of  cells in horizontal   direction
        private int DefaultXLenght = 15;

        // This is the default amount of cells in a vertical  direction
        private int DefaultYHeight = 15;

        // This will be the default cell height
        private int DefaultRowHeight = 15;

        // This will be the default  cell  widht
        private int DefaultColumnWidth = 15;

        // Allows the snake to  pass through walls
        private bool WalkingThroughWallsIsEnabled = true;

        // https://www.fileformat.info/info/unicode/char/25a0/index.htm
        // The charachter for the gift, this is a black box
        private string GiftCode = "\u25A0";

        public SnakeGame() {
            InitializeComponent();
        }

        // Initialize the UI
        private void SnakeGame_Load(object sender, EventArgs e) {
            GameGrid.RowCount = DefaultYHeight;
            GameGrid.ColumnCount = DefaultXLenght;

            // Update widht and height
            UpdateColumnsWidth();
            UpdateRowHeight();

            // Hide Columns name and Rows names, only show the grid itself
            GameGrid.ColumnHeadersVisible = false;
            GameGrid.RowHeadersVisible = false;

            GameGrid.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DifficultySelection.SelectedIndex = 0;
            UpdateStartPosition();

        }

        // This will start the game
        private void StartGameButton_Click(object sender, EventArgs e) {
            int ColumnCount = GameGrid.Columns.Count;
            int RowCount = GameGrid.Rows.Count;
            
            // We initialize all the cells / Coordinates
            PlayingField = new Coordinate[RowCount, ColumnCount];
            for (int i = 0; i < RowCount; i++) {
                for (int t = 0; t < ColumnCount; t++) {
                    Coordinate tmpCord = new(t, i);
                    PlayingField[i, t] = tmpCord;
                }
            }

            // We initialze the snake
            Snake = new(PlayingField[RowCount / 2, ColumnCount / 2]);
            Snake.Positions.First().State = CoordinateState.OccupiedBySnaked;

            // We bind to the events
            Snake.OnPositionChanged += Snake_OnPositionChanged;
            Snake.OnCollision += Snake_OnCollision;

            // Disable  The num boxes
            GridYHeightNumBox.Enabled = false;
            GridXLengthNumBox.Enabled = false;

            // Disable start btton
            StartGameButton.Enabled = false;

            // Disable difficulty selector
            DifficultySelection.Enabled = false;

            // Disable checkbox
            WallhackCheckbox.Enabled = false;

            // Disable color selection
            ChangeSnakeColorButton.Enabled = false;

            // Spawn a gift
            SpawnGift();

            // Set focus to the Control
            this.Focus();

            // Start the timer
            TimerBox.Start();
        }

        // When a collision is detected
        private void Snake_OnCollision(object? sender, EventArgs e) {
            TimerBox.Stop();
            // Enable  The num boxes
            GridYHeightNumBox.Enabled = true;
            GridXLengthNumBox.Enabled = true;

            // Enable start btton
            StartGameButton.Enabled = true;

            // Enable checkbox
            WallhackCheckbox.Enabled = true;

            // Enable difficulty selector
            DifficultySelection.Enabled = true;

            // Enable color selection
            ChangeSnakeColorButton.Enabled = true;

            // Disconnect the events from listening to free up memory
            Snake!.OnPositionChanged -= Snake_OnPositionChanged;
            Snake!.OnCollision -= Snake_OnCollision;

            var giftCells = from Coordinate cord in PlayingField
                             where cord.State == CoordinateState.OccupiedByGift
                             select cord;

            if (giftCells.Count() != 0) {
                Coordinate tmp = giftCells.First();
                GameGrid.Rows[tmp.Y].Cells[tmp.X].Value = "";
            }

            PlayingField = new Coordinate[0, 0];
            Snake = null;

            UpdateStartPosition();
        }

        // When the snaked has moved
        private void Snake_OnPositionChanged(object? sender, SnakePositionChangedArgs e) {
            int Y = e.PositionToAdd.Y;
            int X = e.PositionToAdd.X;
            if (e.PositionToAdd.State == CoordinateState.OccupiedByGift) {
                e.PositionToAdd.State = CoordinateState.OccupiedBySnaked;
                GameGrid.Rows[Y].Cells[X].Value = "";
                SpawnGift();
            }

            GameGrid.Rows[Y].Cells[X].Selected = true;
            e.PositionToAdd.State = CoordinateState.OccupiedBySnaked;

            if (e.PositionToDelete is not null) {
                int DeleteX = e.PositionToDelete.X;
                int DeleteY = e.PositionToDelete.Y;
                GameGrid.Rows[DeleteY].Cells[DeleteX].Selected = false;
                e.PositionToDelete.State = CoordinateState.Unoccupied;
            }
        }

        // This will get the snake moving
        private void TimerBox_Tick(object sender, EventArgs e) {
            // We get the head of the snake
            Coordinate SnakeHead = Snake!.Positions.First();
            // We get the snake direction, and will get the next cell it will move to
            switch (Snake!.Direction) {
                case SnakeDirection.Up:
                    if (SnakeHead.Y == 0) {
                        // If not enable, we will force a collision, by moving the snakehead,
                        // to itself, since that will trigger a collision
                        if (WalkingThroughWallsIsEnabled is false) {
                            Snake!.MoveSnake(SnakeHead);
                        }
                        // We get the bottom column, on the opposite side of the playingfield
                        else {
                            int rowBottom = GameGrid.Rows.Count - 1;
                            Snake!.MoveSnake(PlayingField[rowBottom, SnakeHead.X]);
                        }
                    }
                    // We simply move the snake
                    else {
                        Snake!.MoveSnake(PlayingField[SnakeHead.Y - 1, SnakeHead.X]);
                    }
                    break;
                case SnakeDirection.Down:
                    if (SnakeHead.Y == GameGrid.Rows.Count - 1) {
                        if (WalkingThroughWallsIsEnabled is false) {
                            Snake!.MoveSnake(SnakeHead);
                        }
                        else {
                            int RowsTop = 0;
                            Snake!.MoveSnake(PlayingField[RowsTop, SnakeHead.X]);
                        }
                    }
                    else {
                        Snake!.MoveSnake(PlayingField[SnakeHead.Y + 1, SnakeHead.X]);
                    }
                    break;
                case SnakeDirection.Left:
                    if (SnakeHead.X == 0) {
                        if (WalkingThroughWallsIsEnabled is false) {
                            Snake!.MoveSnake(SnakeHead);
                        }
                        else {
                            int columnEnd = GameGrid.Columns.Count - 1;
                            Snake!.MoveSnake(PlayingField[SnakeHead.Y, columnEnd]);
                        }
                    }
                    else {
                        Snake!.MoveSnake(PlayingField[SnakeHead.Y, SnakeHead.X - 1]);
                    }
                    break;
                case SnakeDirection.Right:
                    if (SnakeHead.X == GameGrid.Columns.Count - 1) {
                        if (WalkingThroughWallsIsEnabled is false) {
                            Snake!.MoveSnake(SnakeHead);
                        }
                        else {
                            int columnStart = 0;
                            Snake!.MoveSnake(PlayingField[SnakeHead.Y, columnStart]);
                        }
                    }
                    else {
                        Snake!.MoveSnake(PlayingField[SnakeHead.Y, SnakeHead.X + 1]);
                    }
                    break;
            }
        }

        // This will capture user input
        private void SnakeGame_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Left:
                    Snake?.ChangeSnakeDirection(SnakeDirection.Left);
                    break;
                case Keys.Up:
                    Snake?.ChangeSnakeDirection(SnakeDirection.Up);
                    break;
                case Keys.Right:
                    Snake?.ChangeSnakeDirection(SnakeDirection.Right);
                    break;
                case Keys.Down:
                    Snake?.ChangeSnakeDirection(SnakeDirection.Down);
                    break;
            }
        }

        // This gets called each time we change the amount of vertical cells
        private void OnYHeightChanged(object sender, EventArgs e) {
            // Here we grab the new updated value,
            // First we cast the sender from object to NumericUpDown
            // Then we cast the Value property from decimal to int
            int NewRowCount = (int)((NumericUpDown)sender).Value;

            // Here we update the RowCount property of our grid
            GameGrid.RowCount = NewRowCount;
            UpdateRowHeight();
        }

        // This gets called each time we change the amount of horizontal cells
        private void OnXLengthChanged(object sender, EventArgs e) {
            // Here we grab the new updated value,
            // First we cast the sender from object to NumericUpDown
            // Then we cast the Value property from decimal to int
            int NewColumnCount = (int)((NumericUpDown)sender).Value;

            // Here we update the RowCount property of our grid
            GameGrid.ColumnCount = NewColumnCount;
            UpdateColumnsWidth();
        }


        // Will spawn a gift somewhere
        private void SpawnGift() {
            // We select all fields not occupied by snake
            var emptyCells = from Coordinate cord in PlayingField
                             where cord.State == CoordinateState.Unoccupied
                             select cord;

            // We get a random entry
            int randomNumber = new Random().Next(0, emptyCells.Count());
            
            SpawnGiftInCell(emptyCells.ElementAt(randomNumber));
        }


        private void SpawnGiftInCell(Coordinate coordinate) {
            GameGrid.Rows[coordinate.Y].Cells[coordinate.X].Value = GiftCode;
            coordinate.State = CoordinateState.OccupiedByGift;
        }

        private (int, int) CalculateCenter() {
            int XCenter = GameGrid.Rows.Count / 2;
            int YCenter = GameGrid.Columns.Count / 2;
            return (XCenter, YCenter);
        }

        private void UpdateColumnsWidth() {
            // We update the width of each column
            for (int i = 0; i < GameGrid.Columns.Count; i++) {
                DataGridViewColumn column = GameGrid.Columns[i];
                column.Width = DefaultColumnWidth;
            }
            // Update the size of the grid
            GameGrid.Width = GameGrid.Columns.GetColumnsWidth(new()) + 3;
            while (this.Width < (GameGrid.Width + panel1.Width + 25)) {
                this.Size = new Size(this.Size.Width + panel1.Width + 25, this.Size.Height);
            }

            

            UpdateStartPosition();
        }

        private void UpdateRowHeight() {
            // We update the height of each row
            for (int i = 0; i < GameGrid.Rows.Count; i++) {
                DataGridViewRow row = GameGrid.Rows[i];
                row.Height = DefaultRowHeight;
            }

            // Update the size of the grid
            GameGrid.Height = GameGrid.Rows.GetRowsHeight(new()) + 3;
            
            while (this.Height < (GameGrid.Height + 50)) {
                this.Size = new Size(this.Size.Width, this.Size.Height + 50);
            }

            UpdateStartPosition();
        }

        private void UpdateStartPosition() {
            // We clear the default selection
             GameGrid.ClearSelection();

            // We select the center position
            // We get Center and hightlight it
            (int, int) Center = CalculateCenter();
            int xcenter = Center.Item1;
            int ycenter = Center.Item2;
            GameGrid.Rows[xcenter].Cells[ycenter].Selected = true;
        }

        private void WallhackCheckbox_CheckedChanged(object sender, EventArgs e) {
            WalkingThroughWallsIsEnabled = WallhackCheckbox.Checked;
        }

        // We change the interval  on our timer, remember it is in ms.
        private void DifficultySelection_SelectedIndexChanged(object sender, EventArgs e) {
            switch (DifficultySelection.SelectedIndex) {
                case 0: // super let
                    TimerBox.Interval = 200;
                    break;
                case 1: // let
                    TimerBox.Interval = 150;
                    break;
                case 2: // Normal
                    TimerBox.Interval = 100;
                    break;
                case 3: // Svær
                    TimerBox.Interval = 75;
                    break;
                case 4: // Ekspert
                    TimerBox.Interval = 50;
                    break;
            }
        }

        // When we want to change the color of our snake
        private void ChangeSnakeColorButton_Click(object sender, EventArgs e) {
            // We call ShowDialog, and if it return DialogResult.OK means that a selection has occured
            if (colorDialog.ShowDialog() == DialogResult.OK) {
                // We update the cellstyle to include the new color selected
                GameGrid.DefaultCellStyle.SelectionBackColor = colorDialog.Color;
            }
        }
    }
}