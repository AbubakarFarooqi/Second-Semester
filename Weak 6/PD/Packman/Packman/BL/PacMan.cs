using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packman.UI;
namespace Packman.BL
{
    class PacMan
    {
        public PacMan(int x, int y, Grid MazeGrid)
        {
            this.x = x;
            this.y = y;
            this.MazeGrid = MazeGrid;
        }
        private int x;
        private int y;
        private int Score;
        Grid MazeGrid;
        public void Remove()
        {
            MazeGrid.setCellValue(' ', x, y);
            PacManUI.RemoveFromScreen(x, y);
        }
        public void Draw()
        {
            MazeGrid.setCellValue('P', x, y);
            PacManUI.DrawPacMan(MazeGrid.getCellByCoordinates(x, y));
            PacManUI.DrawScores(Score);
        }
        public bool MoveLeft(Cell CellNext)
        {
            if (CellNext.getValue() != '#' && CellNext.getValue() != '%' && CellNext.getValue() != '|')
            {
                Remove();
                if (MazeGrid.isGhostThere(CellNext.getValue()))
                    return true;
                if (CellNext.getValue() == '.')
                    Score++;
                CellNext.setValue('P');
                x = CellNext.getX();
                y = CellNext.getY();
                return false;
            }
            return false;

        }
        public bool MoveRight(Cell CellNext)
        {
            if (CellNext.getValue() != '#' && CellNext.getValue() != '%' && CellNext.getValue() != '|')
            {
                Remove();
                if (MazeGrid.isGhostThere(CellNext.getValue()))
                    return true;
                if (CellNext.getValue() == '.')
                    Score++;
                CellNext.setValue('P');
                x = CellNext.getX();
                y = CellNext.getY();
                return false;
            }
            return false;
        }
        public bool MoveUp(Cell CellNext)
        {
            if (CellNext.getValue() != '#' && CellNext.getValue() != '%' && CellNext.getValue() != '|')
            {
                Remove();
                if (MazeGrid.isGhostThere(CellNext.getValue()))
                    return true;
                if (CellNext.getValue() == '.')
                    Score++;
                CellNext.setValue('P');
                x = CellNext.getX();
                y = CellNext.getY();
                return false;

            }
            return false;
        }
        public bool MoveDown(Cell CellNext)
        {
            if (CellNext.getValue() != '#' && CellNext.getValue() != '%' && CellNext.getValue() != '|')
            {
                Remove();
                if (MazeGrid.isGhostThere(CellNext.getValue()))
                    return true;
                if (CellNext.getValue() == '.')
                    Score++;
                CellNext.setValue('P');
                x = CellNext.getX();
                y = CellNext.getY();
                return false;
            }
            return false;
        }

    }
}
