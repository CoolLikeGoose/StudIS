using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Facades.Interfaces;

public interface IActivityFacade : IFacade<ActivityEntity, ActivityListModel, ActivityDetailModel>
{
    Task<IEnumerable<ActivityListModel>> GetByName(string searchTerm);
}