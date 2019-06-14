using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PapasPapbar;
using PapasPapbar.Domain;
using PapasPapbar.Appli;

namespace UnitTestProjectPapas
{
    [TestClass]
    public class UnitTest1
    {
        public int Count { get; private set; }
        //Boardgame boardgame = new Boardgame();
        public class Boardgame
        {
            public string BoardgameName { get; set; }
            public string PlayerCount { get; set; }
            public string Audience { get; set; }
            public string GameTime { get; set; }
            public string Distributor { get; set; }
            public string GameTag { get; set; }
            public int BoardgameId { get; set; }
            public override string ToString()
            {
                return $"{BoardgameName}, {PlayerCount}, {Audience}, ({GameTime}, {Distributor}, {GameTag}, {BoardgameId})";
            }
        }
        Boardgame b1, b2, b3;
        [TestInitialize]
        public void Initialize()
        {
            b1 = new Boardgame { BoardgameName = "Matador", PlayerCount = "4", Audience = "7+", GameTime = "45", Distributor = "HashBro", GameTag = "Family", BoardgameId = 1};
            b2 = new Boardgame { BoardgameName = "Uno", PlayerCount = "2-4", Audience = "10+", GameTime = "30", Distributor = "HashBro", GameTag = "Family", BoardgameId = 2 };
            b3 = new Boardgame { BoardgameName = "Monsterslayer", PlayerCount = "4", Audience = "15+", GameTime = "120", Distributor = "HashBro", GameTag = "Roleplay", BoardgameId = 3 };
        }
        [TestMethod]
        public void TestEmptyList()
        {
            List<Boardgame> boardgames = new List<Boardgame>();

            Assert.AreEqual(1, boardgames);
        }

    }
}
