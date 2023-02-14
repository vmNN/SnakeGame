using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame; 
public class Coordinate {
    public int X { get; set; }
    public int Y { get; set; }
    public CoordinateState State = CoordinateState.Unoccupied;

    public Coordinate(int _x, int _y) {
        X = _x;
        Y = _y;
    }
}

public enum CoordinateState {
    OccupiedBySnaked,
    OccupiedByGift,
    Unoccupied
}
