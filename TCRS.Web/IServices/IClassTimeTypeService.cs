using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IServices
{
    public interface IClassTimeTypeService
    {
        Task<bool> Create(ClassTimeType model);
        Task<bool> Update(ClassTimeType model);
        Task<ClassTimeType> GetById(int Id);
        Task<bool> GetByName(string name);
        Task<ClassTimeType> GetByCondition(Expression<Func<ClassTimeType, bool>> where);
        Task<IEnumerable<ClassTimeType>> GetAll();
        Task<IEnumerable<ClassTimeType>> GetAllByCondition(Expression<Func<ClassTimeType, bool>> where);
        Task<bool> DisableEnable(int Id);
    }

    public class ClassTimeTypeService : IClassTimeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassTimeTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ClassTimeType model)
        {
            await _unitOfWork.ClassTimeType.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.ClassTimeType.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<ClassTimeType>> GetAll()
        {
            return await _unitOfWork.ClassTimeType.FindAllAsync();
        }

        public async Task<IEnumerable<ClassTimeType>> GetAllByCondition(Expression<Func<ClassTimeType, bool>> where)
        {
            return await _unitOfWork.ClassTimeType.FindAllByCondition(where);
        }

        public async Task<ClassTimeType> GetByCondition(Expression<Func<ClassTimeType, bool>> where)
        {
            return await _unitOfWork.ClassTimeType.FirstOrDefaultAsync(where);
        }

        public async Task<ClassTimeType> GetById(int Id)
        {
            return await _unitOfWork.ClassTimeType.FindByIdAsync(Id);
        }

        public async Task<bool> GetByName(string name)
        {
            var resultFind = await _unitOfWork.ClassTimeType.FirstOrDefaultAsync(x => x.ClassTimeTypeTitle == name);
            return Convert.ToBoolean(resultFind);
        }

        public async Task<bool> Update(ClassTimeType model)
        {
            _unitOfWork.ClassTimeType.UpdateClassType(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }
    }
}
