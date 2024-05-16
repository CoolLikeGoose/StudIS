using StudIS.BL.Facades;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels
{
    public class SubjectViewModel
    {
        private readonly SubjectFacade _subjectFacade;

        public SubjectViewModel(SubjectFacade subjectFacade)
        {
            _subjectFacade = subjectFacade;
        }

        public async Task<IEnumerable<SubjectListModel>> GetAllSubjects()
        {
            return await _subjectFacade.GetAsync();
        }

        public async Task<SubjectDetailModel> GetSubjectById(Guid id)
        {
            return await _subjectFacade.GetAsync(id);
        }

        public async Task AddOrUpdateSubject(SubjectDetailModel subject)
        {
            await _subjectFacade.SaveAsync(subject);
        }

        public async Task DeleteSubject(Guid id)
        {
            await _subjectFacade.DeleteAsync(id);
        }
    }

}

