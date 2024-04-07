using StudIS.BL.Models;
using StudIS.DAL.Entities;

namespace StudIS.BL.Facades.Interfaces;

public interface IStudentFacade : IFacade<StudentEntity, StudentListModel, StudentDetailModel>
{
    
}