using PapasPapbar.Appli;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PapasPapbar.Domain;


namespace PapasPapbar.Appli
{

    public class BoardgameRepos
    {
        private Boardgame boardgame = new Boardgame();

        public void InsertBoardgame(Boardgame boardgame)
        {
            boardgame.InsertBoardgame(boardgame.BoardgameName, boardgame.PlayerCount, 
            boardgame.Audience, boardgame.GameTime, boardgame.Distributor, boardgame.GameTag);
        }

        public void UpdateBoardgame(Boardgame boardgame)
        {
            boardgame.UpdateBoardgame(boardgame.BoardgameName, boardgame.PlayerCount, boardgame.Audience,
            boardgame.GameTime, boardgame.Distributor, boardgame.GameTag, boardgame.BoardgameId);
        }

        public void DeleteBoardgame(int boardgameId)
        {
            boardgame.DeleteBoardgame(boardgameId);
        }
        public void GetBoardgame(Boardgame boardgame)
        {
            boardgame.GetBoardgame();
        }
    }
}
