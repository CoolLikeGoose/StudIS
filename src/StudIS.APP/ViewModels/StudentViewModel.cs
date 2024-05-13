using StudIS.BL.Facades;
using StudIS.BL.Models;

namespace StudIS.APP.ViewModels
{
    public class StudentViewModel
    {
        private readonly StudentFacade _studentFacade;

        public StudentViewModel(StudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
        }

        public async Task<IEnumerable<StudentListModel>> GetAllStudents()
        {
            return await _studentFacade.GetAsync();
        }

        public async Task<StudentDetailModel> GetStudentById(Guid id)
        {
            return await _studentFacade.GetAsync(id);
        }

        public async Task AddOrUpdateStudent(StudentDetailModel student)
        {
            await _studentFacade.SaveAsync(student);
        }

        public async Task DeleteStudent(Guid id)
        {
            await _studentFacade.DeleteAsync(id);
        }
    }

}

