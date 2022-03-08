using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IServices
{
    public interface IAcademicYearService
    {
        Task<bool> Create(AcademicYear model);
        Task<bool> Update(AcademicYear model);
        Task<AcademicYear> GetById(int Id);
        Task<bool> GetByName(string name);
        Task<AcademicYear> GetByCondition(Expression<Func<AcademicYear, bool>> expression);
        Task<IEnumerable<AcademicYear>> GetAll();
        Task<IEnumerable<AcademicYear>> GetAllByCondition(Expression<Func<AcademicYear, bool>> expression);
        Task<bool> AnyByCondition(Expression<Func<AcademicYear, bool>> expression);
        Task<bool> DisableEnable(int Id);
    }

    public class AcademicYearService : IAcademicYearService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AcademicYearService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(AcademicYear model)
        {
            await _unitOfWork.AcademicYear.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> AnyByCondition(Expression<Func<AcademicYear, bool>> expression)
        {
            return await _unitOfWork.AcademicYear.AnyByCondition(expression);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.AcademicYear.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }



        public async Task<IEnumerable<AcademicYear>> GetAll()
        {
            return await _unitOfWork.AcademicYear.FindAllAsync();
        }

        public async Task<IEnumerable<AcademicYear>> GetAllByCondition(Expression<Func<AcademicYear, bool>> expression)
        {
            return await _unitOfWork.AcademicYear.FindAllByCondition(expression);
        }

        public async Task<AcademicYear> GetByCondition(Expression<Func<AcademicYear, bool>> expression)
        {
            return await _unitOfWork.AcademicYear.FirstOrDefaultAsync(expression);
        }

        public async Task<AcademicYear> GetById(int Id)
        {
            return await _unitOfWork.AcademicYear.FindByIdAsync(Id);
        }

        public async Task<bool> GetByName(string name)
        {
            var resultFind = await _unitOfWork.AcademicYear.FirstOrDefaultAsync(x => x.YearTitle == name);
            return Convert.ToBoolean(resultFind);
        }

        public async Task<bool> Update(AcademicYear model)
        {
            _unitOfWork.AcademicYear.UpdateAcademicYear(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);

        }
    }
}