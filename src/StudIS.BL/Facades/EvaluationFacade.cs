using StudIS.BL.Facades.Interfaces;
using StudIS.BL.Mappers;
using StudIS.BL.Models;
using StudIS.DAL.Entities;
using StudIS.DAL.Mappers;
using StudIS.DAL.UnitOfWork;

namespace StudIS.BL.Facades;

public class EvaluationFacade(IUnitOfWorkFactory unitOfWorkFactory, EvaluationModelMapper evaluationModelMapper) 
    : FacadeBase<EvaluationEntity, EvaluationListModel, EvaluationDetailModel, EvaluationEntityMapper>
    (unitOfWorkFactory, evaluationModelMapper), IEvaluationFacade
{
    
}