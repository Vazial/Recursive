using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Recursive.Maze
{
    // セル情報
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    // 通路・壁情報
    public enum CellInfo
    {
        Path = 0,
        Wall,
        InCollect,
        Collect,
        Start,
        End
    }

    public class MazeGenerator
    {
        // 参考 : https://algoful.com/Archive/Algorithm/MazeDig
        public static readonly Point StartPos = new Point(1, 1);

        // 方向
        private enum Direction
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3
        }

        // 2次元配列の迷路情報
        private CellInfo[,] Maze;
        private int Width { get; set; }
        private int Height { get; set; }

        // 穴掘り開始候補座標
        private List<Cell> StartCells;

        private int RootMax = 0;
        private Cell EndBuf = new Cell();

        // コンストラクタ
        public MazeGenerator(int width, int height)
        {
            // 5未満のサイズや偶数では生成できない
            if (width < 5 || height < 5) throw new ArgumentOutOfRangeException("5未満のサイズは生成不可");
            if (width % 2 == 0) width++;
            if (height % 2 == 0) height++;

            // 迷路情報を初期化
            this.Width = width;
            this.Height = height;
            Maze = new CellInfo[width, height];
            StartCells = new List<Cell>();
        }

        // 生成処理
        public CellInfo[,] CreateMaze()
        {
            // 全てを壁で埋める
            // 穴掘り開始候補(x,yともに偶数)座標を保持しておく
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    if (x == 0 || y == 0 || x == this.Width - 1 || y == this.Height - 1)
                    {
                        Maze[x, y] = CellInfo.Path;  // 外壁は判定の為通路にしておく(最後に戻す)
                    }
                    else
                    {
                        Maze[x, y] = CellInfo.Wall;
                    }
                }
            }

            // 穴掘り開始
            Dig(StartPos.X, StartPos.Y);
            Maze[StartPos.X, StartPos.Y] = CellInfo.Start;

            // 外壁を戻す
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    if (x == 0 || y == 0 || x == this.Width - 1 || y == this.Height - 1)
                    {
                        Maze[x, y] = CellInfo.Wall;
                    }
                }
            }
            return Maze;
        }

        // 座標(x, y)に穴を掘る
        private void Dig(int x, int y)
        {
            // 指定座標から掘れなくなるまで堀り続ける
            var rnd = new Random();
            int RootCnt = 0;
            while (true)
            {
                // 掘り進めることができる方向のリストを作成
                var directions = new List<Direction>();
                if (this.Maze[x, y - 1] == CellInfo.Wall && this.Maze[x, y - 2] == CellInfo.Wall)
                    directions.Add(Direction.Up);
                if (this.Maze[x + 1, y] == CellInfo.Wall && this.Maze[x + 2, y] == CellInfo.Wall)
                    directions.Add(Direction.Right);
                if (this.Maze[x, y + 1] == CellInfo.Wall && this.Maze[x, y + 2] == CellInfo.Wall)
                    directions.Add(Direction.Down);
                if (this.Maze[x - 1, y] == CellInfo.Wall && this.Maze[x - 2, y] == CellInfo.Wall)
                    directions.Add(Direction.Left);

                // 掘り進められない場合、ループを抜ける
                if (directions.Count == 0) break;

                // 指定座標を通路とし穴掘り候補座標から削除
                SetPath(x, y);
                ++RootCnt;
                // 掘り進められる場合はランダムに方向を決めて掘り進める
                var dirIndex = rnd.Next(directions.Count);
                // 決まった方向に先2マス分を通路とする
                switch (directions[dirIndex])
                {
                    case Direction.Up:
                        SetPath(x, --y);
                        SetPath(x, --y);
                        break;
                    case Direction.Right:
                        SetPath(++x, y);
                        SetPath(++x, y);
                        break;
                    case Direction.Down:
                        SetPath(x, ++y);
                        SetPath(x, ++y);
                        break;
                    case Direction.Left:
                        SetPath(--x, y);
                        SetPath(--x, y);
                        break;
                }
            }

            // どこにも掘り進められない場合、穴掘り開始候補座標から掘りなおし
            // 候補座標が存在しないとき、穴掘り完了
            var cell = GetStartCell();
            if (cell != null)
            {
                if (RootCnt > RootMax) 
                {
                    EndBuf.X = x;
                    EndBuf.Y = y;
                    RootMax = RootCnt;
                }
                Dig(cell.X, cell.Y);
            }
            Maze[EndBuf.X, EndBuf.Y] = CellInfo.End;
        }

        // 座標を通路とする(穴掘り開始座標候補の場合は保持)
        private void SetPath(int x, int y)
        {
            this.Maze[x, y] = (int)CellInfo.Path;
            if (x % 2 == 1 && y % 2 == 1)
            {
                // 穴掘り候補座標
                StartCells.Add(new Cell() { X = x, Y = y });
            }
        }

        // 穴掘り開始位置をランダムに取得する
        private Cell GetStartCell()
        {
            if (StartCells.Count == 0) return null;

            // ランダムに開始座標を取得する
            var rnd = new Random();
            var index = rnd.Next(StartCells.Count);
            var cell = StartCells[index];
            StartCells.RemoveAt(index);

            return cell;
        }

        // デバッグ用処理
        public static void DebugPrint(CellInfo[,] maze)
        {
            Console.WriteLine($"Width: {maze.GetLength(0)}");
            Console.WriteLine($"Height: {maze.GetLength(1)}");
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                for (int x = 0; x < maze.GetLength(0); x++)
                {
                    switch (maze[x, y])
                    {
                        case CellInfo.Wall:
                            Console.Write("■");
                            break;
                        case CellInfo.Path:
                        case CellInfo.InCollect:
                            Console.Write("　");
                            break;
                        case CellInfo.Collect:
                            Console.Write("〇");
                            break;
                        case CellInfo.Start:
                            Console.Write("St");
                            break;
                        case CellInfo.End:
                            Console.Write("Ed");
                            break;
                        default:
                            throw new Exception();
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
