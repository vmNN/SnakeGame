using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame; 
public class Snake {
    public List<Coordinate> Positions { get; private set; } = new();
    public event EventHandler? OnCollision;
    public event EventHandler<SnakePositionChangedArgs>? OnPositionChanged;

    // We put private set, to force any change of direction to go throgh ChangeSnakeDirection method,
    // In order to avoid going the opposite direction, which is considered an illegal move.
    public SnakeDirection Direction { get; private set; } = SnakeDirection.Up;
    private SnakeDirection LastDirectionMoved = SnakeDirection.Up;

    // Check to make sure that the direction is not the same as the LastDirectionMoved property
    public void ChangeSnakeDirection(SnakeDirection direction) {
        switch (direction) {
            case SnakeDirection.Left:
                if (LastDirectionMoved != SnakeDirection.Right) {
                    Direction = direction;
                }
                break;
            case SnakeDirection.Up:
                if (LastDirectionMoved != SnakeDirection.Down) {
                    Direction = direction;
                }
                break;
            case SnakeDirection.Right:
                if (LastDirectionMoved != SnakeDirection.Left) {
                    Direction = direction;
                }
                break;
            case SnakeDirection.Down:
                if (LastDirectionMoved != SnakeDirection.Up) {
                    Direction = direction;
                }
                break;
        }
    }
    
    public void MoveSnake(Coordinate nextCell) {
        // Game over!
        if (nextCell.State == CoordinateState.OccupiedBySnaked) {
            OnCollision?.Invoke(this, new());
            return;
        }

        // We initialize EventArgs, and give it the next coordinate it will move to
        SnakePositionChangedArgs snakePositionChangedArgs = new(nextCell);

        // We add the new position (head) to the front of the list
        Positions = Positions.Prepend(nextCell).ToList();
        // If it is not a gift, we delete the last position (tail)
        if (nextCell.State != CoordinateState.OccupiedByGift) {
            // We provide the eventargs with a coordinate that is no longer snake
            snakePositionChangedArgs.PositionToDelete = Positions.Last();
            // We remove the last coordinate, as the snake has moved past it
            Positions.RemoveAt(Positions.Count - 1);
        }

        // We update the snake last direction moved
        LastDirectionMoved = Direction;

        // Publishing the event
        OnPositionChanged?.Invoke(this, snakePositionChangedArgs);
    }


    public Snake(Coordinate startPosition) {
        Positions.Add(startPosition);
    }


}

public enum SnakeDirection {
    Left,
    Up,
    Right,
    Down
}

public class SnakePositionChangedArgs : EventArgs {
    public Coordinate PositionToAdd { get; set; }
    public Coordinate? PositionToDelete { get; set; }

    public SnakePositionChangedArgs(Coordinate positionToAdd) {
        PositionToAdd = positionToAdd;
    }
}