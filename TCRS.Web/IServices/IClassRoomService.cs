using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;
using TCRS.Web.ViewModels.ClassRoomViewModel;

namespace TCRS.Web.IServices
{
    public interface IClassRoomService
    {
        Task<bool> Create(ClassRoom model);
        Task<bool> Update(ClassRoom model);
        Task<ClassRoom> GetById(int Id);
        Task<bool> GetByName(string name);
        Task<ClassRoom> GetByCondition(Expression<Func<ClassRoom, bool>> expression);
        Task<IEnumerable<ClassRoom>> GetAll();
        Task<IEnumerable<ClassRoom>> GetAllByCondition(Expression<Func<ClassRoom, bool>> expression);
        Task<bool> AnyByCondition(Expression<Func<ClassRoom, bool>> expression);
        Task<bool> DisableEnable(int Id);
        Task<IEnumerable<ClassRoomIndexViewModel>> GetClassRoomIndex();
    }

    public class ClassRoomService : IClassRoomService
    {

        private readonly IUnitOfWork _unitOfWork;
        public ClassRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ClassRoom model)
        {
            await _unitOfWork.ClassRoom.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> AnyByCondition(Expression<Func<ClassRoom, bool>> expression)
        {
            return await _unitOfWork.ClassRoom.AnyByCondition(expression);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.ClassRoom.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<ClassRoomIndexViewModel>> GetClassRoomIndex()
        {
            var result = await _unitOfWork.ClassRoom.FindAllAsync();

            var resultIndex = new List<ClassRoomIndexViewModel>();
            foreach (var item in result)
            {
                resultIndex.Add(new ClassRoomIndexViewModel
                {
                    ClassID = item.ClassID,
                    LessonCode = item.Lesson.LessonCode,
                    LessonTitle = item.Lesson.LessonTitle,
                    ProfessorCount = item.LessonID_FK
                    IsActive = false
                });
            }
        }

        public async Task<IEnumerable<ClassRoom>> GetAll()
        {
            return await _unitOfWork.ClassRoom.FindAllAsync();
        }

        public async Task<IEnumerable<ClassRoom>> GetAllByCondition(Expression<Func<ClassRoom, bool>> expression)
        {
            return await _unitOfWork.ClassRoom.FindAllByCondition(expression);
        }

        public async Task<ClassRoom> GetByCondition(Expression<Func<ClassRoom, bool>> expression)
        {
            return await _unitOfWork.ClassRoom.FirstOrDefaultAsync(expression);
        }

        public async Task<ClassRoom> GetById(int Id)
        {
            return await _unitOfWork.ClassRoom.FindByIdAsync(Id);
        }

        public async Task<bool> GetByName(string name)
        {
            var resultFind = await _unitOfWork.ClassRoom.FirstOrDefaultAsync(x => x. == name);
            return Convert.ToBoolean(resultFind);
        }

        public async Task<bool> Update(ClassRoom model)
        {
            await _unitOfWork.ClassRoom.UpdateClassRoom(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);

        }
    }
}