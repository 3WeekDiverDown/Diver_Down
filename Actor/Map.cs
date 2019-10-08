﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using Diver_Down.Device;
using Diver_Down.Utility;
//using Diver_Down.Actor.Block;

namespace Diver_Down.Actor
{
    class Map
    {
        private List<List<GameObject>> mapList;
        private GameDevice gameDevice;
        //List<Enemy> enemys;
        public Map(GameDevice gameDevice)
        {
            mapList = new List<List<GameObject>>();
            //enemys = new List<Enemy>();
            this.gameDevice = gameDevice;
        }
        private List<GameObject> addBlock(int lineCnt, string[] line)
        {
            Dictionary<string, GameObject> objctDict = new Dictionary<string, GameObject>();
            //objctDict.Add("0", new Space(Vector2.Zero, gameDevice));
            
            List<GameObject> workList = new List<GameObject>();
            int colCnt = 0;
            foreach (var s in line)
            {
                try
                {
                    GameObject work = (GameObject)objctDict[s].Clone();
                    work.SetPosition(new Vector2(colCnt * work.GetHeight(), lineCnt * work.GetWidth()));
                    //if(work is Enemy)
                    //{
                    //    enemys.Add((Enemy)work);
                    //}
                    //else
                        workList.Add(work);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                colCnt += 1;
            }
            return workList;
        }
        public void Load(string filename, string path = "./")
        {
            CSVReader csvRreader = new CSVReader();
            csvRreader.Read(filename, path);
            var data = csvRreader.GetData();
            for (int lineCnt = 0; lineCnt < data.Count(); lineCnt++)
            {
                mapList.Add(addBlock(lineCnt, data[lineCnt]));
            }
        }
        public void Unload()
        {
            mapList.Clear();
        }
        public void Update(GameTime gameTime)
        {
            foreach (var list in mapList)
            {
                foreach (var obj in list)
                {
                    //if (obj is Space)
                    //{
                    //    continue;
                    //}
                    obj.Updata(gameTime);
                }
            }
        }
        public void Hit(GameObject gameObject)
        {
            Point work = gameObject.getRectangle().Location;
            int x = work.X / 128;
            int y = work.Y / 128;
            if (x < 1)
            {
                x = 1;
            }
            if (y < 1)
            {
                y = 1;
            }

            Range yRange = new Range(0, mapList.Count() - 1);
            Range xRange = new Range(0, mapList[0].Count() - 1);

            for (int row = y - 1; row <= (y + 1); row++)
            {
                for (int col = x - 1; col <= (x + 1); col++)
                {
                    if (xRange.IsOutOfRange(col) || yRange.IsOutOfRange(row))
                    {
                        continue;
                    }
                    GameObject obj = mapList[row][col];
                    //if (obj is Space)
                    //{
                    //    continue;
                    //}
                    if (obj.IsCollision(gameObject))
                    {
                        gameObject.Hit(obj);
                    }
                }
            }
        }
        public void Draw(Renderer renderer)
        {
            foreach (var list in mapList)
            {
                foreach (var obj in list)
                {
                    //if (obj is Space||obj is NextSpace)
                    //{
                    //    continue;
                    //}
                    obj.Draw(renderer);
                }
            }
        }
        public int GetMapX()
        {
            return mapList[0].Count;
        }
        //public List<Enemy> EnemyAdd()
        //{
        //    return enemys;
        //}
    }
}
