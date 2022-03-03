using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IServices
{
    public interface IClassTypeService
    {
        Task<bool> Create(ClassType model);
        Task<bool> Update(ClassType model);
        Task<ClassType> GetById(int Id);
        Task<bool> GetByName(string name);
        Task<IEnumerable<ClassType>> GetAll();
        Task<IEnumerable<ClassType>> GetAllByCondition(Expression<Func<ClassType, bool>> where);
        Task<bool> DisableEnable(int Id);
    }


    public class ClassTypeService : IClassTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ClassType model)
        {
            await _unitOfWork.ClassType.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.ClassType.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<ClassType>> GetAll()
        {
            return await _unitOfWork.ClassType.FindAllAsync();
        }

        public async Task<IEnumerable<ClassType>> GetAllByCondition(Expression<Func<ClassType, bool>> where)
        {
            return await _unitOfWork.ClassType.FindAllByCondition(where);
        }

        public async Task<ClassType> GetById(int Id)
        {
            return await _unitOfWork.ClassType.FindByIdAsync(Id);
        }

        public async Task<bool> GetByName(string name)
        {
            var resultFind = await _unitOfWork.ClassType.FirstOrDefaultAsync(x => x.ClassTypeTitle == name);
            return Convert.ToBoolean(resultFind);
        }

        public async Task<bool> Update(ClassType model)
        {
            _unitOfWork.ClassType.UpdateDisconected(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }
    }

}
