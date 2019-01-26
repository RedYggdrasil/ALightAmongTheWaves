using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum Consequence
{
    NOTHING = 0,
    REDUCE_FOOD = 1,
    REDUCE_SURVIVORS = 2,
    REDUCE_WOOD = 3,
    INCREASE_FOOD = 4,
    INCREASE_SURVIVORS = 5,
    INCREASE_WOOD = 6
}