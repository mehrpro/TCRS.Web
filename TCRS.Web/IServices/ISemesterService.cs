using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IServices
{
    public interface ISemesterService
    {

        Task<bool> Create(Semester model);
        Task<bool> Update(Semester model);
        Task<Semester> GetById(int Id);
        Task<bool> GetByName(string name);
        Task<Semester> GetByCondition(Expression<Func<Semester, bool>> expression);
        Task<IEnumerable<Semester>> GetAll();
        Task<IEnumerable<Semester>> GetAllByCondition(Expression<Func<Semester, bool>> expression);
        Task<bool> AnyByCondition(Expression<Func<Semester, bool>> expression);
        Task<bool> DisableEnable(int Id);
    }

    public class SemesterService : ISemesterService
    {

        private readonly IUnitOfWork _unitOfWork;
        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Semester model)
        {
            await _unitOfWork.Semester.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> AnyByCondition(Expression<Func<Semester, bool>> expression)
        {
            return await _unitOfWork.Semester.AnyByCondition(expression);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.Semester.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }



        public async Task<IEnumerable<Semester>> GetAll()
        {
            return await _unitOfWork.Semester.FindAllAsync();
        }

        public async Task<IEnumerable<Semester>> GetAllByCondition(Expression<Func<Semester, bool>> expression)
        {
            return await _unitOfWork.Semester.FindAllByCondition(expression);
        }

        public async Task<Semester> GetByCondition(Expression<Func<Semester, bool>> expression)
        {
            return await _unitOfWork.Semester.FirstOrDefaultAsync(expression);
        }

        public async Task<Semester> GetById(int Id)
        {
            return await _unitOfWork.Semester.FindByIdAsync(Id);
        }

        public async Task<bool> GetByName(string name)
        {
            var resultFind = await _unitOfWork.Semester.FirstOrDefaultAsync(x => x.SemesterTitle == name);
            return Convert.ToBoolean(resultFind);
        }

        public async Task<bool> Update(Semester model)
        {
            _unitOfWork.Semester.UpdateSemester(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);

        }
    }
}