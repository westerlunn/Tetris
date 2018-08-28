﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Infrastructure.DataModel;
using Infrastructure.Repositories;
using TetrisUI;

namespace TheGame.EFRepository

{

    public class GameStateRepository : IRepository<GameState>
    {
        //public void Update(GameState gameState)
        //{
        //    using (var context = new GameContext())
        //    {
        //        var entity = context.GameStates.FirstOrDefault(g => g.GameStateId == gameState.GameStateId);
        //        if (entity != null)
        //        {
        //            context.Entry(entity).CurrentValues.SetValues(gameState);
        //        }
        //        //context.GameStates.Update(gameState);
        //        context.SaveChanges();
        //    }
        //}

        public void Update(GameState gameState)
        {
            var l = new List<Block>()
            {
                new Block(6, 7, ShapeColor.Blue),
                new Block(8, 13, ShapeColor.Blue)

            };
            //try
            //{
                using (var context = new GameContext())
                {
                    var entity = context.GameStates
                        .Include(g => g.ActiveShape)
                        .Include(g => g.DeadBlocks)
                        .Include(g => g.Player)
                        .FirstOrDefault(g => g.GameStateId == gameState.GameStateId);

                    if (entity != null)
                    {
                        entity.ActiveShape = gameState.ActiveShape;
                        entity.DeadBlocks = new List<Block>(gameState.DeadBlocks);
                        entity.Player = gameState.Player;
                        entity.Score = gameState.Score;
                        entity.Time = gameState.Time;
                    }

                    context.SaveChanges();
                }
            //}
            //catch (Exception e)
            //{

            //}

        }

        public void Save(GameState gameState)
        {
            using (var context = new GameContext())
            {
                context.GameStates.Add(gameState);
                context.SaveChanges();
            }
        }

        //public void Seed(GameState gameState)
        //{
        //    using (var context = new GameContext())
        //    {
        //        context.Database.EnsureDeleted();
        //        context.Database.EnsureCreated();
        //    }
        //}

        public GameState GetById(int id)
        {
            using (var context = new GameContext())
            {
                return context.GameStates
                    .Include(g => g.DeadBlocks)
                    .Include(g => g.ActiveShape)
                    .FirstOrDefault(g => g.GameStateId == id);
            }
        }

        public ICollection<GameState> GetAll()
        {
            using (var context = new GameContext())
            {
                return context.GameStates
                    .Include(g => g.DeadBlocks)
                    .Include(g => g.ActiveShape)
                    .ToList();
            }
        }
    }
}
