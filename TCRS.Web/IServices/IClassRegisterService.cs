using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;

namespace TCRS.Web.IServices
{
    public interface IClassRegisterService
    {
        Task<bool> Create(ClassRegister model);
        Task<bool> Update(ClassRegister model);
        Task<ClassRegister> GetById(int Id);
        Task<IEnumerable<ClassRegister>> GetAll();
        Task<IEnumerable<ClassRegister>> GetAllByCondition(Expression<Func<ClassRegister, bool>> where);
        Task<bool> DisableEnable(int Id);
    }

    public class ClassRegisterService : IClassRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassRegisterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(ClassRegister model)
        {
            await _unitOfWork.ClassRegister.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.ClassRegister.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<ClassRegister>> GetAll()
        {
            return await _unitOfWork.ClassRegister.FindAllAsync();
        }

        public async Task<IEnumerable<ClassRegister>> GetAllByCondition(Expression<Func<ClassRegister, bool>> where)
        {
            return await _unitOfWork.ClassRegister.FindAllByCondition(where);
        }

        public async Task<ClassRegister> GetById(int Id)
        {
            return await _unitOfWork.ClassRegister.FindByIdAsync(Id);
        }

        public async Task<bool> Update(ClassRegister model)
        {
            _unitOfWork.ClassRegister.UpdateClassRegister(model);
            var result = await _unitOfWork.CommitAsync();
            return true;
        }
    }
}
