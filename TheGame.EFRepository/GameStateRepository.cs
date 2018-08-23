using System.Linq;
using Microsoft.EntityFrameworkCore;
using TheGame.Infrastructure.DataModel;
using TheGame.Infrastructure.Repositories;

namespace TheGame.EFRepository
{
    
    public class GameStateRepository : IRepository<GameState>
    {
        public void Update(GameState gameState)
        {
            using (var context = new GameContext())
            {
                context.GameStates.Update(gameState);
                context.SaveChanges();
            }
        }

        public void Save(GameState gameState)
        {
            using (var context = new GameContext())
            {
                context.GameStates.Add(gameState);
                context.SaveChanges();
            }
        }

        public void Seed(GameState gameState)
        {
            using (var context = new GameContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }

        public GameState GetById(int id)
        {
            using (var context = new GameContext())
            {
                var latestGameState = context.GameStates
                    .Include(g => g.DeadBlocks)
                    .Include(g => g.ActiveShape)
                    .OrderByDescending(g => g.GameStateId == id).FirstOrDefault();
                return latestGameState;
            }
        }
    }
}
