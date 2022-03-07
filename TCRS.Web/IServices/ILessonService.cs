﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TCRS.Web.IRepositories;
using TCRS.Web.Models.Entities;


namespace TCRS.Web.IServices
{
    public interface ILessonService
    {
        Task<bool> Create(Lesson model);
        Task<bool> Update(Lesson model);
        Task<Lesson> GetById(int Id);
        Task<bool> GetByName(string name);
        Task<Lesson> GetByCondition(Expression<Func<Lesson, bool>> where);
        Task<IEnumerable<Lesson>> GetAll();
        Task<IEnumerable<Lesson>> GetAllByCondition(Expression<Func<Lesson, bool>> where);
        Task<bool> DisableEnable(int Id);
    }

    public class LessonService : ILessonService
    {

        private readonly IUnitOfWork _unitOfWork;
        public LessonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Create(Lesson model)
        {
            await _unitOfWork.Lesson.AddAsync(model);
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<bool> DisableEnable(int Id)
        {
            var resultFind = await _unitOfWork.Lesson.FindByIdAsync(Id);
            var lastStatus = resultFind.IsActive;
            resultFind.IsActive = !lastStatus;
            var result = await _unitOfWork.CommitAsync();
            return Convert.ToBoolean(result);
        }

        public async Task<IEnumerable<Lesson>> GetAll()
        {
            return await _unitOfWork.Lesson.FindAllAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllByCondition(Expression<Func<Lesson, bool>> where)
        {
            return await _unitOfWork.Lesson.FindAllByCondition(where);
        }

        public async Task<Lesson> GetByCondition(Expression<Func<Lesson, bool>> where)
        {
            return await _unitOfWork.Lesson.FirstOrDefaultAsync(where);
        }

        public async Task<Lesson> GetById(int Id)
        {
            return await _unitOfWork.Lesson.FindByIdAsync(Id);
        }

        public async Task<bool> GetByName(string name)
        {
            var resultFind = await _unitOfWork.Lesson.FirstOrDefaultAsync(x => x.LessonTitle == name);
            return Convert.ToBoolean(resultFind);
        }

        public async Task<bool> Update(Lesson model)
        {
            //_unitOfWork.Lesson.UpdateClassType(model);
            //var result = await _unitOfWork.CommitAsync();
            //return Convert.ToBoolean(result);
            return true;
        }
    }
}
