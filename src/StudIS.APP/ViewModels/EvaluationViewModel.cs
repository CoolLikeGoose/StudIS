using StudIS.BL.Facades;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels
{
    public class EvaluationViewModel
    {
        private readonly EvaluationFacade _evaluationFacade;

        public EvaluationViewModel(EvaluationFacade evaluationFacade)
        {
            _evaluationFacade = evaluationFacade;
        }

        public async Task<IEnumerable<EvaluationListModel>> GetEvaluationsByStudent(Guid studentId)
        {
            return await _evaluationFacade.GetByStudent(studentId);
        }

        public async Task<EvaluationDetailModel> GetEvaluationById(Guid id)
        {
            return await _evaluationFacade.GetAsync(id);
        }

        public async Task AddOrUpdateEvaluation(EvaluationDetailModel evaluation)
        {
            await _evaluationFacade.SaveAsync(evaluation);
        }

        public async Task DeleteEvaluation(Guid id)
        {
            await _evaluationFacade.DeleteAsync(id);
        }
    }

}

