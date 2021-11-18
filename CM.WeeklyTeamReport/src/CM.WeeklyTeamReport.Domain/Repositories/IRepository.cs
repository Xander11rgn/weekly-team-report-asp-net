using System;
using System.Collections.Generic;
using System.Text;

namespace CM.WeeklyTeamReport.Domain
{
    interface IRepository<TEntity>
    {
        TEntity Create(TEntity entity);
        TEntity Read(int entityId);
        TEntity Update(TEntity entity);
        void Delete(int entityId);
    }
}
