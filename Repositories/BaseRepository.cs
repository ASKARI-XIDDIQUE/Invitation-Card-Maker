using Invitation_Card_Maker.Data;
using Invitation_Card_Maker.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Invitation_Card_Maker.Repositories
{
    public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly InvitationDbContext _context;
        public BaseRepository(InvitationDbContext context)
        {
            _context= context;
        }
        public async Task<TEntity> Create(TEntity entity)
        {
            try{
                var Model=await _context.Set<TEntity>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return Model.Entity;

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            try {
                var Model = _context.Set<TEntity>().Remove(entity);
                await _context.SaveChangesAsync();
                return Model.Entity;

            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public async Task<List<TEntity>> Get()
        {
            try
            {
                return await _context.Set<TEntity>().Where(x=>true).ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            try
            {
                var Model = _context.Set<TEntity>().Update(entity);
                await _context.SaveChangesAsync();
                return Model.Entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
