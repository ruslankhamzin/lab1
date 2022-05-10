using System;
using System.Collections.Generic;
using System.Text;

namespace lab1
{
    public class Maze
    {
        private  int nx;
        private  int ny;
        private  Room[,] rooms;
        private  Wall[,] horizontal;
        private  Wall[,] vertical;

        public override string ToString()
        {
            var s = new StringBuilder();

            for (int j = 0; j <= ny*2; j += 1)
            {
                s.Append(horizontal[0, j]);
            }
            s.Append('\n');

            for (int i = 0; i < nx; i += 1)
            {
                s.Append(vertical[i, 0]);
                for (int j = 0; j < ny; j += 1)
                {
                    s.Append(rooms[i, j]);
                    if (vertical[i, j + 1] != null)
                    {
                        s.Append(vertical[i, j + 1]);
                    }
                    else
                    {
                        s.Append(' ');
                    }
                }
                s.Append('\n');

                for (int j = 0; j <= ny*2; j += 1)
                {
                    if (horizontal[i + 1, j] != null)
                    {
                        s.Append(horizontal[i + 1, j]);
                    }
                    else
                    {
                        s.Append(' ');
                    }
                }
                s.Append('\n');
            }
            return s.ToString();
        }

        public class Builder
        {
            private Maze maze;
            private Random random;
            public static int point = 0;

            public Builder (int nx, int ny)
            {
                maze = new Maze();
                random = new Random();
                maze.nx = nx;
                maze.ny = ny;
                maze.rooms = new Room[nx, ny];
                maze.horizontal = new Wall[nx + 1, ny*2+1];
                maze.vertical = new Wall[nx, ny + 1];
            }

            public Builder FillRoom()
            {
                for (int i = 0; i < maze.nx; i += 1)
                    for (int j = 0; j < maze.ny; j += 1)
                        if (random.Next(0, 10) == 5)
                        {
                            maze.rooms[i, j] = new Room('@');
                            point++;
                        }
                        else
                            maze.rooms[i, j] = new Room(' ');
                return this;
            }

            public Builder FillHorizontal()
            {
                maze.horizontal[0, 0] = new Wall('╔');
                for (int j = 1; j < maze.ny * 2; j += 2) {
                    maze.horizontal[0, j] = new Wall('═');
                    maze.horizontal[0, j + 1] = new Wall('╤');
                }
                maze.horizontal[0, maze.ny*2] = new Wall('╗');
                for (int i = 1; i < maze.nx; i += 1)
                    for (int j = 0; j < maze.ny*2; j += 2)
                    {
                        maze.horizontal[i, 0] = new Wall('╟');
                        if (random.Next(0, 2) == 1)
                            maze.horizontal[i, j+1] = new Wall('─');
                        maze.horizontal[i, j] = new Wall('┼');
                        maze.horizontal[i, maze.ny*2] = new Wall('╢');
                    }
                for (int j = 1; j < maze.ny * 2; j += 2)
                {
                    maze.horizontal[maze.nx, j] = new Wall('═');
                    maze.horizontal[maze.nx, j + 1] = new Wall('╧');
                }
                maze.horizontal[maze.nx, 0] = new Wall('╚');
                maze.horizontal[maze.nx, maze.ny*2] = new Wall('╝');
                return this;
            }

            public Builder FillVertical()
            {
                for (int i = 0; i < maze.nx; i += 1)
                {
                    maze.vertical[i, 0] = new Wall('║');
                    for (int j = 1; j < maze.ny; j += 1)
                        if (random.Next(0, 2) == 1)
                            maze.vertical[i, j] = new Wall('│');
                    maze.vertical[i, maze.ny] = new Wall('║');
                }
                return this;
            }

            public Maze Build() => maze;
        }

    }
}
