using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectTextRPG1
{
    internal class Game
    {
        private bool IsRuning = true;
        private Scene curScene;
        private MainMenuScene mainMenuScene;
        private MapScene mapScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;


        public void Run()
        {
            // 시작할 때 가져와야할 정보
            Init();

            while (IsRuning)
            {
                Render();
                Update();
            }
            Release();
        }

        private void Init()
        {
            Console.CursorVisible = false;
            Data.Init();

            battleScene = new BattleScene(this);
            inventoryScene = new InventoryScene(this);
            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);

            curScene = mainMenuScene;
        }
        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }

        private void Update()
        {
            curScene.Update();
        }
        public void GameStart()
        {
            Data.StartMap1();
            curScene = mapScene;
        }
        public void GameOver()
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("게임을 종료합니다. 텍스트 이미지");
            sb.AppendLine("게임을 종료합니다. 텍스트 이미지");
            sb.AppendLine("게임을 종료합니다. 텍스트 이미지");
            sb.AppendLine("게임을 종료합니다. 텍스트 이미지");
            sb.AppendLine("게임을 종료합니다. 텍스트 이미지");

            Console.WriteLine(sb.ToString());

            IsRuning = false;
        }

        private void Release()
        {
            
        }
    }
}
