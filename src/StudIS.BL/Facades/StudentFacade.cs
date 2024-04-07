using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Mappers;
using StudIS.BL.Models;
using StudIS.DAL.Entities;
using StudIS.DAL.Mappers;
using StudIS.DAL.UnitOfWork;

namespace StudIS.BL.Facades;

public class StudentFacade(IUnitOfWorkFactory unitOfWorkFactory, StudentModelMapper evaluationModelMapper) 
    : FacadeBase<StudentEntity, StudentListModel, StudentDetailModel, StudentEntityMapper>
        (unitOfWorkFactory, evaluationModelMapper), IStudentFacade
{
    
}